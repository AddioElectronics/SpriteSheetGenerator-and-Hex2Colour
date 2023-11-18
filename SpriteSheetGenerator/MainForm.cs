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
        #region Fields

        readonly OpenFileDialog ofd = new OpenFileDialog();
        readonly SaveFileDialog sfd = new SaveFileDialog();
        readonly FolderBrowserDialog fbd = new FolderBrowserDialog();

        /// <summary>
        /// Imported images.
        /// </summary>
        readonly List<ImagePath> images = new List<ImagePath>();

        /// <summary>
        /// Generated sprite sheet.
        /// </summary>
        ImagePath? sheet;

        /// <summary>
        /// Individually generated variants.
        /// </summary>
        ImagePath[]? imageVariants;

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
        bool genImagesUnsaved;

        bool notificationsEnabled = true;

        readonly List<CheckBox> rotationControls = new List<CheckBox>();

        readonly string? hex2ColourPath;

        static readonly string[] outputFormats = Util.GetAllImageFormats().Select(x => x.ToString()).Where(x => x != "MemoryBMP").ToArray();

        bool AlignVertically => checkBox_AlignVert.Checked;
        bool PackSprites => checkBox_Pack.Checked;
        bool EqualSpacing => checkBox_EqualSpacing.Checked;
        PixelFormat SelectedPixelFormat => Enum.Parse<PixelFormat>(comboBox_PixelFormat.Text, true);

        /// <summary>
        /// Names added to filename for individual variants.
        /// </summary>
#warning Reminder to add ability to modify from form.
        internal static Dictionary<RotateFlipType, string> rotateFlipNames = new Dictionary<RotateFlipType, string>()
        {
            {RotateFlipType.Rotate90FlipNone, "90" },
            {RotateFlipType.Rotate180FlipNone, "180" },
            {RotateFlipType.Rotate270FlipNone, "270" },
            {RotateFlipType.Rotate90FlipX, "90XM" },
            {RotateFlipType.Rotate270FlipX, "270XM" },
            {RotateFlipType.RotateNoneFlipX, "XM" },
            {RotateFlipType.RotateNoneFlipY, "YM" },
        };

        RotateFlipType[] RotationsAndFlips
        {
            get
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
        }

        #endregion

        #region Constructors

        public MainForm()
        {
            InitializeComponent();

            // Combo Boxes
            comboBox_PixelFormat.Items.AddRange(SpriteSheetGenerator.validPixelFormats.Select(x => Enum.GetName(x)).ToArray());
            comboBox_PixelFormat.Text = Enum.GetName(PixelFormat.Format32bppArgb);

            // Rotation Checkboxes
            rotationControls.Add(checkBox_Rotate90);
            rotationControls.Add(checkBox_Rotate180);
            rotationControls.Add(checkBox_Rotate270);
            rotationControls.Add(checkBox_Rotate90MX);
            rotationControls.Add(checkBox_Rotate270MX);
            rotationControls.Add(checkBox_MirrrorX);
            rotationControls.Add(checkBox_MirrorY);


            //Set notifications controls
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            notificationsToolStripMenuItem_Click(null, null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.


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
            flowLayoutPanel_Generated.MouseWheel += Trackbar_MouseWheel;
            trackBar_ScaleSheet.MouseWheel += Trackbar_MouseWheel;
            flowLayoutPanel_Sprites.MouseWheel += Trackbar_MouseWheel;
            trackBar_ScaleImages.MouseWheel += Trackbar_MouseWheel;
        }

        #endregion

        #region Methods

        private void AddPreviewImage(ImagePath imgPath, FlowLayoutPanel flowPanel)
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

            if (flowPanel.Controls.Contains(imgPath))
                flowPanel.Controls.Remove(imgPath);

            flowPanel.Controls.Add(imgPath);
        }

        private void SetControlsEnabled()
        {
            button_GenerateVariations.Enabled =
                button_CreateSheet.Enabled =
                (images.Count > 0);

            exportToolStripMenuItem1.Enabled =
                (sheet != null && sheet.pb.BackgroundImage != null) ||
                (imageVariants != null && imageVariants.Length > 0);

            exportToolStripMenuItem1.Enabled =
                tableLayoutPanel_Images.Visible =
                tableLayoutPanel_Generated.Visible =
                (sheet != null || imageVariants != null);

        }

        private void AddImage(string filename)
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
            AddPreviewImage(imgPath, flowLayoutPanel_Sprites);
            SetControlsEnabled();
            UpdateImageLabels();
        }

        private void AddImages(string[] images)
        {
            foreach (string path in images)
            {
                AddImage(path);
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
                AddPreviewImage(image, flowLayoutPanel_Sprites);
            }
        }

        private void UpdateImageLabels()
        {
            if (images.Count == 0)
            {
                label_ImageCount.Text = $"Count : 0";
                label_Area.Text = $"Area : 0px";
            }
            else
            {
                label_ImageCount.Text = $"Count : {images.Count}";
                label_Area.Text = $"Area : {images.Sum(x => x.image.Width * x.image.Height)}px";
            }
        }

        private void DeleteSelectedImages()
        {
#pragma warning disable 8600
            if (listBox_Paths.SelectedIndex == -1) return;

            var selected = listBox_Paths.SelectedItems;

            for (int i = selected.Count - 1; i >= 0; i--)
            {
                ImagePath item = (ImagePath)selected[i];

                listBox_Paths.Items.Remove(selected[i]);
                images.Remove(item);
                flowLayoutPanel_Sprites.Controls.Remove(item.pb);
                item.Dispose();
            }

            UpdateImageLabels();
#pragma warning restore 8600
        }

        private void SaveGenerated()
        {
            if (sheet != null)
            {
                SaveSheet();
            }
            else if (imageVariants != null && imageVariants.Length > 0)
            {
                SaveVariants();
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

            sheet.image.Save(sfd.FileName, format);
            genImagesUnsaved = false;
        }

        private void SaveVariants()
        {
            /// Save file dialog is not ideal for saving multiple files,
            /// but the FolderBrowserDialog is just too shit, and
            /// I'd like to be able to select the image format directly from the dialog.
            /// For now will have to use temporary name to ignore, until custom form is created.
            sfd.FileName = "temp";
            DialogResult result = sfd.ShowDialog();


            if (result != DialogResult.OK)
            {
                sfd.FileName = string.Empty;
                return;
            }

            ImageFormat? format = Util.GetImageFormat(Path.GetExtension(sfd.FileName).Trim('.'));

            if (format == null)
            {
                sfd.FileName = string.Empty;
                MessageBox.Show("Invalid Image Format");
                return;
            }

            string? directory = Path.GetDirectoryName(sfd.FileName);
            string? extension = Path.GetExtension(sfd.FileName);

            if (directory == null || extension == null)
            {
                return;
            }

            foreach (ImagePath imgPath in imageVariants)
            {
                string filename = Path.Combine(directory, imgPath.filename + extension);
                imgPath.image.Save(filename, format);
            }

            genImagesUnsaved = false;
            sfd.FileName = string.Empty;
        }

        /// <summary>
        /// Updates controls change depending on the generated images (sheet/variants).
        /// </summary>
        private void UpdateControlsGenerated()
        {
            if (sheet != null)
            {
                label_Gen0.Text = $"Width : {sheet.image.Width}px";
                label_Gen1.Text = $"Height : {sheet.image.Height}px";
            }
            else if (imageVariants != null)
            {
                label_Gen0.Text = $"Count : {imageVariants.Length}";
                label_Gen1.Text = $"Area : {imageVariants.Sum(x => x.Width * x.Height)}px";
            }

            SetControlsEnabled();
        }

        private void DeleteImageVariants()
        {
            if (imageVariants == null) return;

            foreach (ImagePath image in imageVariants)
            {
                flowLayoutPanel_Generated.Controls.Remove(image.pb);
                image.Dispose();
            }

            imageVariants = null;
        }

        private void DeleteSpriteSheet()
        {
            if (sheet == null) return;

            flowLayoutPanel_Generated.Controls.Remove(sheet.pb);
            sheet.Dispose();
            sheet = null;
        }

        private void DeleteGeneratedImages()
        {
            DeleteSpriteSheet();
            DeleteImageVariants();
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

            AddImages(ofd.FileNames);
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
            images.ForEach(x => x.Dispose());
            images.Clear();
            flowLayoutPanel_Sprites.Controls.Clear();
            UpdateImageLabels();
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

                    AddImages(files.Cast<string>().ToArray());
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

            AddImages(files);
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            DeleteSelectedImages();
        }

        private void trackBar_ScaleImages_ValueChanged(object sender, EventArgs e)
        {
            scaleImages = trackBar_ScaleImages.Value / 10.0;
            label_ZoomImages.Text = $"Zoom : {scaleImages:0.0}x";

            foreach (ImagePath imgPath in images)
            {
                imgPath.pb.Size = Util.ScaleSize(imgPath.image.Size, scaleImages);
            }
        }

        private void trackBar_ScaleSheet_ValueChanged(object sender, EventArgs e)
        {
            scaleSheet = trackBar_ScaleSheet.Value / 10.0;
            label_ZoomGen.Text = $"Zoom : {scaleSheet:0.0}x";

            if (sheet != null)
            {
                sheet.pb.Size = Util.ScaleSize(sheet.image.Size, scaleSheet);
            }

            if (imageVariants != null && imageVariants.Length > 0)
            {
                foreach (ImagePath imgPath in imageVariants)
                {
                    imgPath.pb.Size = Util.ScaleSize(imgPath.image.Size, scaleSheet);
                }
            }
        }

        private void button_GenerateVariations_Click(object sender, EventArgs e)
        {
            if (images.Count == 0)
            {
                MessageBox.Show("No images");
                return;
            }

            if (genImagesUnsaved)
            {
                DialogResult result = MessageBox.Show("Do you want to save before generating?", "Generated images not saved", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    SaveGenerated();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            DeleteGeneratedImages();

            List<ImagePath> genVariants = new List<ImagePath>();
            PixelFormat pixelFormat = SelectedPixelFormat;
            RotateFlipType[] flipTypes = RotationsAndFlips;

            foreach (ImagePath imgPath in images)
            {
                Bitmap[]? variants = SpriteSheetGenerator.GenerateBitmapVariations(imgPath, pixelFormat, flipTypes);

                for (int i = 0; i < variants.Length; i++)
                {
                    ImagePath vip = new ImagePath(
                        variants[i],
                        imgPath.filename,
                        flipTypes[i]
                        );

                    AddPreviewImage(vip, flowLayoutPanel_Generated);
                    genVariants.Add(vip);
                }
            }

            imageVariants = genVariants.ToArray();
            genImagesUnsaved = true;
            UpdateControlsGenerated();
        }

        private void button_CreateSpriteSheet_Click(object sender, EventArgs e)
        {
            if (images.Count == 0)
            {
                MessageBox.Show("No images");
                return;
            }

            if (notificationsEnabled && genImagesUnsaved)
            {
                DialogResult result = MessageBox.Show("Do you want to save before generating?\r\n\r\nNotifications can be disabled in Tools->Options", "Generated images not saved", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    SaveGenerated();
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            if (notificationsEnabled && PackSprites == Util.AllImagesSameSize(images.Select(x => x.image).ToArray()))
            {
                DialogResult result;
                if (PackSprites)
                    result = MessageBox.Show("All your images are the same size.\r\nYou may get better results with \"Pack Sprites\" turned off.\r\n\r\nDo you want to disable before generating?\r\n\r\nNotifications can be disabled in Tools->Options", "Disabling \"Pack Sprites\" may produce better results", MessageBoxButtons.YesNoCancel);
                else
                    result = MessageBox.Show("Your images contain different sizes.\r\nYou may get better results with \"Pack Sprites\" turned on.\r\n\r\nDo you want to enable before generating?\r\n\r\nNotifications can be disabled in Tools->Options", "Enabling \"Pack Sprites\" may produce better results", MessageBoxButtons.YesNoCancel);


                if (result == DialogResult.Yes)
                {
                    checkBox_Pack.Checked = !checkBox_Pack.Checked;
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }

            }

            DeleteGeneratedImages();
            Image sheetImage;

            try
            {
                /// Attempt to create the sprite sheet.
                /// May fail when using a lot of images with CreateSheetPacked().
                sheetImage = PackSprites ?
                    SpriteSheetGenerator.CreateSheetPacked(images.Select(x => x.image).ToArray(), SelectedPixelFormat, RotationsAndFlips) :
                    SpriteSheetGenerator.CreateSheet(images.Select(x => x.image).ToArray(), AlignVertically, EqualSpacing, SelectedPixelFormat, RotationsAndFlips);
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException)
                {
                    ArgumentException argumentException = ex as ArgumentException;

                    if (argumentException.ParamName == "destinationArray")
                    {
                        MessageBox.Show(
                            "There is not enough room to pack the images.\r\n" +
                            "Please remove some images and try again.",
                            "Failed to pack images"
                            );
                        return;
                    }
                }

                MessageBox.Show(ex.Message, "Failed to create sprite sheet");
                SetControlsEnabled();
                return;
            }


            sheet = new ImagePath()
            {
                image = sheetImage,
                pb = new PictureBox()
                {
                    BackgroundImage = sheetImage,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackgroundImageLayout = ImageLayout.Stretch,
                    Size = Util.ScaleSize(sheetImage.Size, scaleSheet)
                },
            };
            flowLayoutPanel_Generated.Controls.Add( sheet );
            genImagesUnsaved = true;
            UpdateControlsGenerated();
        }

        private void button_Export_Click(object sender, EventArgs e)
        {
            SaveGenerated();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PalettizerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!notificationsEnabled)
                return;

            if (genImagesUnsaved)
            {
                DialogResult result = MessageBox.Show("Do you want to save before quitting?", "Generated images not saved", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    SaveGenerated();
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
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
            int dir = e.Delta > 0 ? 1 : -1;

            if (sender.GetType() == typeof(TrackBar))
            {
                trackbar = (TrackBar)sender;
            }
            else
            {
                if (sender == flowLayoutPanel_Generated)
                {
                    var vscroll = flowLayoutPanel_Generated.VerticalScroll;

                    if (vscroll.Visible)
                    {
                        //Only zoom in direction when scrollbar at maximum.
                        if ((dir == 1 && vscroll.Value != vscroll.Minimum) ||
                            (dir == -1 && vscroll.Value != vscroll.Maximum - vscroll.LargeChange + 1))
                            return;
                    }

                    trackbar = trackBar_ScaleSheet;
                }
                else if (sender == flowLayoutPanel_Sprites)
                {
                    var vscroll = flowLayoutPanel_Sprites.VerticalScroll;

                    if (vscroll.Visible)
                    {
                        //Only zoom in direction when scrollbar at maximum.
                        if ((dir == 1 && vscroll.Value != vscroll.Minimum) ||
                            (dir == -1 && vscroll.Value != vscroll.Maximum - vscroll.LargeChange + 1))
                            return;
                    }
                    trackbar = trackBar_ScaleImages;
                }
                else
                    return;
            }

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

        private void checkBox_Pack_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_AlignVert.Enabled = !checkBox_Pack.Checked;
            checkBox_EqualSpacing.Enabled = !checkBox_Pack.Checked;
        }

        private void notificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender == enableNotificationsToolStripMenuItem)
                notificationsEnabled = true;
            else if (sender == disableNotificationsToolStripMenuItem)
                notificationsEnabled = false;
            else if (sender == notificationsToolStripMenuItem)
                notificationsEnabled = !notificationsEnabled;

            if (notificationsEnabled)
            {
                enableNotificationsToolStripMenuItem.Enabled = false;
                disableNotificationsToolStripMenuItem.Enabled = true;
                notificationsToolStripMenuItem.Text = "Notifications (ON)";
            }
            else
            {
                enableNotificationsToolStripMenuItem.Enabled = true;
                disableNotificationsToolStripMenuItem.Enabled = false;
                notificationsToolStripMenuItem.Text = "Notifications (OFF)";
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