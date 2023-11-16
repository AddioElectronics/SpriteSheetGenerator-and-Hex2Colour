#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning disable IDE0090 // Use 'new(...)'
#pragma warning disable IDE1006 // Naming Styles <- dumb when winforms auto-generates function names that ignore the convention

using System.Data;
using System.Media;
using System.Reflection;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Collections.Specialized;
using Image = System.Drawing.Image;

namespace SpriteSheetGenerator
{
    public partial class MainForm : Form
    {
        #region Definitions

        class ImagePath
        {
            public Image image;
            public string path;
            public string filename;
            public PictureBox pb;

            public override string ToString()
            {
                return filename;
            }

            public static implicit operator Image(ImagePath imgPath) => imgPath.image;
            public static implicit operator PictureBox(ImagePath imgPath) => imgPath.pb;
        }

        #endregion

        #region Fields

        readonly OpenFileDialog ofd = new OpenFileDialog();
        readonly SaveFileDialog sfd = new SaveFileDialog();

        /// <summary>
        /// Imported images.
        /// </summary>
        readonly List<ImagePath> images = new List<ImagePath>();

        /// <summary>
        /// Generated sprite sheet.
        /// </summary>
        Image sheet;

        /// <summary>
        /// Current scale for images.
        /// </summary>
        double scaleImages = 1.0;

        /// <summary>
        /// Current scale for sprite sheet
        /// </summary>
        double scaleSheet = 1.0;

        /// <summary>
        /// Was the last generated sheet saved?
        /// </summary>
        bool sheetUnsaved;

        readonly List<CheckBox> rotationControls = new List<CheckBox>();

        readonly string? hex2ColourPath;

        static readonly string[] outputFormats = Util.GetAllImageFormats().Select(x => x.ToString()).Where(x => x != "MemoryBMP").ToArray();


        #endregion

        #region Constructors

        public MainForm()
        {
            InitializeComponent();

            // Combo Boxes
            comboBox_PixelFormat.Items.AddRange(Enum.GetNames<PixelFormat>());
            comboBox_PixelFormat.Text = Enum.GetName(PixelFormat.Format32bppPArgb);

            // Rotation Checkboxes
            rotationControls.Add(checkBox_Rotate90);
            rotationControls.Add(checkBox_Rotate180);
            rotationControls.Add(checkBox_Rotate270);
            rotationControls.Add(checkBox_Rotate90MX);
            rotationControls.Add(checkBox_Rotate270MX);
            rotationControls.Add(checkBox_MirrrorX);
            rotationControls.Add(checkBox_MirrorY);


            // External tools
            hex2ColourPath = Directory.EnumerateFiles(Environment.CurrentDirectory).FirstOrDefault(x => Path.GetFileName(x) == "Hex2Colour.exe");
            hex2ColourToolStripMenuItem.Enabled = hex2ColourPath != null;

            // File Dialogs
            var codecs = ImageCodecInfo.GetImageEncoders();
            string sep = string.Empty;

            foreach (var c in codecs)
            {
                string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
                ofd.Filter = String.Format("{0}{1}{2} ({3})|{3}", ofd.Filter, sep, codecName, c.FilenameExtension);
                sep = "|";
            }
            ofd.Filter = String.Format("{0}{1}{2} ({3})|{3}", ofd.Filter, sep, "All Files", "*.*");
            ofd.Multiselect = true;


            sep = string.Empty;
            foreach (string format in outputFormats)
            {
                sfd.Filter = String.Format("{0}{1}{2} (*.{3})|*.{3}", sfd.Filter, sep, format, format.ToLower());
                sep = "|";
            }

            //Events
            panel_SpriteSheet.MouseWheel += Trackbar_MouseWheel;
            trackBar_ScaleSheet.MouseWheel += Trackbar_MouseWheel;
            flowLayoutPanel_Sprites.MouseWheel += Trackbar_MouseWheel;
            trackBar_ScaleImages.MouseWheel += Trackbar_MouseWheel;
        }

        #endregion

        #region Methods

        private void AddPreviewImage(ImagePath imgPath)
        {
            if (imgPath.pb == null)
            {
                PictureBox pb = new PictureBox
                {
                    BackgroundImageLayout = ImageLayout.Stretch,
                    BackgroundImage = imgPath,
                    Size = Util.ScaleSize(imgPath.image.Size, scaleImages)
                };

                imgPath.pb = pb;
            }

            if (flowLayoutPanel_Sprites.Controls.Contains(imgPath))
                flowLayoutPanel_Sprites.Controls.Remove(imgPath);

            flowLayoutPanel_Sprites.Controls.Add(imgPath);
        }

        private void SetControlsEnabled()
        {
            button_Generate.Enabled = images.Count > 0;
            exportToolStripMenuItem1.Enabled = pictureBox_SpriteSheet.BackgroundImage != null;
        }

        private void OpenImage(string filename)
        {
            //Dont allow duplicates
            if (images.Any(x => x.filename == filename))
                return;

            Image image;

            try
            {
                image = Image.FromFile(filename);
            }
            catch
            {
                return;
            }

            ImagePath imgPath = new ImagePath()
            {
                image = image,
                path = filename,
                filename = Path.GetFileName(filename),
            };

            listBox_Paths.Items.Add(imgPath);
            images.Add(imgPath);
            AddPreviewImage(imgPath);
            SetControlsEnabled();
        }

        private void OpenImages(string[] images)
        {
            foreach (string path in images)
            {
                OpenImage(path);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldIndex"></param>
        /// <param name="newIndex"></param>
        /// <remarks>Moves the item in the listbox and list, but not the preview panel.</remarks>
        private void MoveImageOrder(int oldIndex, int newIndex)
        {

            ImagePath imgPath = (ImagePath)listBox_Paths.Items[oldIndex];
            listBox_Paths.Items.RemoveAt(oldIndex);
            listBox_Paths.Items.Insert(newIndex, imgPath);
            listBox_Paths.SelectedIndex = newIndex;

            images.Remove(imgPath);
            images.Insert(newIndex, imgPath);
        }

        private void RefreshPreviewPanel()
        {
            flowLayoutPanel_Sprites.Controls.Clear();

            foreach (var image in images)
            {
                AddPreviewImage(image);
            }
        }

        private PixelFormat? ParsePixelFormat()
        {
            if (Enum.TryParse<PixelFormat>(comboBox_PixelFormat.Text, true, out PixelFormat pixelFormat))
            {
                return pixelFormat;
            }

            return null;
        }

        private RotateFlipType[] GetRotationTypes()
        {
            List<RotateFlipType> types = new List<RotateFlipType>();

            if (checkBox_Rotate90.Checked)
                types.Add(RotateFlipType.Rotate90FlipNone);

            if (checkBox_Rotate180.Checked)
                types.Add(RotateFlipType.Rotate180FlipNone);

            if (checkBox_Rotate270.Checked)
                types.Add(RotateFlipType.Rotate270FlipNone);

            if (checkBox_Rotate90MX.Checked)
                types.Add(RotateFlipType.Rotate90FlipX);

            if (checkBox_Rotate270MX.Checked)
                types.Add(RotateFlipType.Rotate270FlipX);

            if (checkBox_MirrrorX.Checked)
                types.Add(RotateFlipType.RotateNoneFlipX);

            if (checkBox_MirrorY.Checked)
                types.Add(RotateFlipType.RotateNoneFlipY);

            return types.ToArray();
        }

        private void DeleteSelectedImages()
        {
            if (listBox_Paths.SelectedIndex == -1) return;

            var selected = listBox_Paths.SelectedItems;

            for (int i = selected.Count - 1; i >= 0; i--)
            {
                ImagePath item = (ImagePath)selected[i];

                listBox_Paths.Items.Remove(selected[i]);
                images.Remove(item);
                flowLayoutPanel_Sprites.Controls.Remove(item.pb);
            }
        }

        private void SaveSheet()
        {
            DialogResult result = sfd.ShowDialog();

            if (result != DialogResult.OK) return;

            ImageFormat? format = Util.GetImageFormat(Path.GetExtension(sfd.FileName).Trim('.'));

            if (format == null)
            {
                MessageBox.Show("Invalid Image Format");
                return;
            }

            sheet.Save(sfd.FileName, format);
            sheetUnsaved = false;
        }

        #endregion

        #region Events

        private void button_AllRotations_Click(object sender, EventArgs e)
        {
            int @checked = rotationControls.Count(x => x.Checked);
            bool check = @checked < rotationControls.Count / 2;

            checkBox_Rotate90.Checked = check;
            checkBox_Rotate180.Checked = check;
            checkBox_Rotate270.Checked = check;
            checkBox_Rotate90MX.Checked = check;
            checkBox_Rotate270MX.Checked = check;
            checkBox_MirrrorX.Checked = check;
            checkBox_MirrorY.Checked = check;
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = ofd.ShowDialog();

            if (result != DialogResult.OK)
                return;

            OpenImages(ofd.FileNames);
        }

        private void button_MoveTop_Click(object sender, EventArgs e)
        {
            var items = listBox_Paths.SelectedItems;

            if (items.Count == 0) return;

            for (int i = 0; i < items.Count; i++)
            {
                int index = listBox_Paths.Items.IndexOf(items[i]);
                int newIndex = 0 + i;

                if (index == -1 || newIndex == listBox_Paths.Items.Count) continue;

                MoveImageOrder(index, newIndex);
            }

            RefreshPreviewPanel();
        }

        private void button_MoveBottom_Click(object sender, EventArgs e)
        {
            var items = listBox_Paths.SelectedItems;

            if (items.Count == 0) return;

            for (int i = items.Count - 1; i >= 0; i--)
            {
                int index = listBox_Paths.Items.IndexOf(items[i]);
                int newIndex = listBox_Paths.Items.Count - 1 - (items.Count - i);

                if (index == -1 || newIndex == listBox_Paths.Items.Count) continue;

                MoveImageOrder(index, newIndex);
            }

            RefreshPreviewPanel();
        }

        private void button_MoveUp_Click(object sender, EventArgs e)
        {
            var items = listBox_Paths.SelectedItems;
            if (items.Count == 0) return;

            for (int i = 0; i < items.Count; i++)
            {
                int index = listBox_Paths.Items.IndexOf(items[i]);
                int newIndex = index - 1;

                if (newIndex < 0) continue;

                MoveImageOrder(index, newIndex);
            }

            RefreshPreviewPanel();
        }

        private void button_MoveDown_Click(object sender, EventArgs e)
        {
            var items = listBox_Paths.SelectedItems;

            if (items.Count == 0) return;

            for (int i = 0; i < items.Count; i++)
            {
                int index = listBox_Paths.Items.IndexOf(items[i]);
                int newIndex = index + 1;

                if (index == -1 || newIndex == listBox_Paths.Items.Count) continue;

                MoveImageOrder(index, newIndex);
            }

            RefreshPreviewPanel();
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            listBox_Paths.Items.Clear();
            images.Clear();
            flowLayoutPanel_Sprites.Controls.Clear();
        }

        private void listBox_Paths_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                DeleteSelectedImages();
            else if (e.Control)
            {
                if (e.KeyCode == Keys.C)
                {
                    var paths = listBox_Paths.SelectedItems.OfType<ImagePath>().Select(x => x.path).ToArray();
                    StringCollection strings = new StringCollection();
                    strings.AddRange(paths);
                    Clipboard.SetFileDropList(strings);
                }
                else if (e.KeyCode == Keys.X)
                {
                    var imagePaths = listBox_Paths.SelectedItems.OfType<ImagePath>().ToArray();
                    StringCollection strings = new StringCollection();
                    strings.AddRange(imagePaths.Select(x => x.path).ToArray());
                    Clipboard.SetFileDropList(strings);
                    DeleteSelectedImages();
                }
                else if (e.KeyCode == Keys.V)
                {
                    var files = Clipboard.GetFileDropList();

                    if (files == null || files.Count == 0)
                        return;

                    OpenImages(files.Cast<string>().ToArray());
                }
                else if (e.KeyCode == Keys.A)
                {
                    var items = listBox_Paths.Items;

                    for (int i = 0; i < items.Count; i++)
                    {
                        if (!listBox_Paths.SelectedItems.Contains(items[i]))
                            listBox_Paths.SelectedItems.Add(items[i]);
                    }
                }
            }
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[]? files = (string[]?)e.Data.GetData(DataFormats.FileDrop);

            if (files == null || files.Length == 0)
                return;

            OpenImages(files);
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            DeleteSelectedImages();
        }

        private void trackBar_ScaleImages_ValueChanged(object sender, EventArgs e)
        {
            scaleImages = trackBar_ScaleImages.Value / 10.0;

            foreach (ImagePath imgPath in images)
            {
                imgPath.pb.Size = Util.ScaleSize(imgPath.image.Size, scaleImages);
            }
        }

        private void trackBar_ScaleSheet_ValueChanged(object sender, EventArgs e)
        {
            scaleSheet = trackBar_ScaleSheet.Value / 10.0;

            if (sheet != null)
            {
                pictureBox_SpriteSheet.Size = Util.ScaleSize(sheet.Size, scaleSheet);
            }
        }

        private void button_CreateSpriteSheet_Click(object sender, EventArgs e)
        {
            if (images.Count == 0)
            {
                MessageBox.Show("No images");
                return;
            }

            SpriteSheetGenerator generator = new SpriteSheetGenerator(images.Select(x => x.image).ToArray(), GetRotationTypes());

            PixelFormat? pixelFormat = ParsePixelFormat();

            if (pixelFormat == null)
            {
                SystemSounds.Beep.Play();
                MessageBox.Show("Invalid PixelFormat", "Invalid PixelFormat", MessageBoxButtons.OK);
                return;
            }

            generator.PixelFormat = pixelFormat.Value;
            generator.AlignVertically = checkBox_AlignVert.Checked;

            Image image = generator.CreateSheet();
            sheet = image;
            pictureBox_SpriteSheet.BackgroundImage = image;
            pictureBox_SpriteSheet.Size = Util.ScaleSize(sheet.Size, scaleSheet);
            sheetUnsaved = true;
            label_SheetWidth.Text = $"Width : {sheet.Width}";
            label_SheetHeight.Text = $"Height : {sheet.Height}";

            exportToolStripMenuItem1.Enabled = true;
            pictureBox_SpriteSheet.BorderStyle = BorderStyle.FixedSingle;
        }

        private void button_Export_Click(object sender, EventArgs e)
        {
            if (sheet == null) return;

            SaveSheet();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PalettizerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sheetUnsaved)
            {
                DialogResult result = MessageBox.Show("Do you want to save before quitting?", "Sheet was not saved", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    SaveSheet();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Util.OpenUrl("https://github.com/AddioElectronics/Hex2Colour");
        }

        private void hex2ColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(hex2ColourPath);
            }
            catch
            {
                hex2ColourToolStripMenuItem.Enabled = false;
            }

        }

        private void Trackbar_MouseWheel(object? sender, MouseEventArgs e)
        {
            TrackBar trackbar;

            if (sender.GetType() == typeof(TrackBar))
            {
                trackbar = (TrackBar)sender;
            }
            else
            {
                if (sender == panel_SpriteSheet)
                    trackbar = trackBar_ScaleSheet;
                else if (sender == flowLayoutPanel_Sprites)
                    trackbar = trackBar_ScaleImages;
                else
                    return;
            }

            int dir = e.Delta > 0 ? 1 : -1;
            int newValue = trackbar.Value + (dir * trackbar.SmallChange /*trackbar.TickFrequency*/);

            if (newValue > trackbar.Maximum)
            {
                trackbar.Value = trackbar.Maximum;
            }
            else if (newValue < trackbar.Minimum)
            {
                trackbar.Value = trackbar.Minimum;
            }
            else
            {
                trackbar.Value = newValue;
            }
        }

        #endregion
    }
}
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore IDE0090 // Use 'new(...)'
#pragma warning restore IDE1006 // Naming Styles