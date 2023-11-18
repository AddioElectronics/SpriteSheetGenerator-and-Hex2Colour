#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable IDE0090 // Use 'new(...)'
#pragma warning disable IDE1006 // Naming Styles
using System.Collections.Specialized;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Text.RegularExpressions;
using static Hex2Colour.Settings;

namespace Hex2Colour
{
    public partial class Hex2ColourForm : Form
    {
        #region Fields/Properties/Constants

        private const string settingsFilename = "settings" + Settings.EXTENSION;

        readonly string? spriteSheetGeneratorPath;
        #endregion

        #region Constructor

        public Hex2ColourForm()
        {
            InitializeComponent();
            LoadLastSettings();

            spriteSheetGeneratorPath = Directory.EnumerateFiles(Environment.CurrentDirectory).FirstOrDefault(x => Path.GetFileName(x) == "SpriteSheetGenerator.exe");
            spriteSheetGeneratorToolStripMenuItem.Enabled = spriteSheetGeneratorPath != null;

            Icon = Util.MakeTransparentIcon(Resource.icon);
            ShowIcon = true;
        }

        #endregion

        #region Methods

        private void LoadLastSettings()
        {
            if (!File.Exists(settingsFilename))
            {
                Hex2Colour.Settings = new Settings();
                return;
            }

            try
            {
                Settings? settings = Settings.Load(settingsFilename);
                Hex2Colour.Settings = settings;
                Hex2Colour.Settings.FileName = settingsFilename;
                ApplySettings(settings);
            }
            catch
            {
                Hex2Colour.Settings = new Settings();
            }
        }

        private void SaveLastSettings()
        {
            Hex2Colour.Settings.NameFormat = textBox_NameFormat.Text;
            try
            {
                if (File.Exists(settingsFilename))
                {
                    Settings? settings = Settings.Load(settingsFilename);

                    //No changes
                    if (settings == Hex2Colour.Settings)
                        return;
                }
            }
            catch
            {
                Hex2Colour.Settings.Save(settingsFilename);
            }

            Hex2Colour.Settings.Save(settingsFilename);
        }

        private void ApplySettings(Settings settings)
        {
            Hex2Colour.Settings = settings;
            textBox_NameFormat.Text = settings.NameFormat;
        }


        #endregion

        #region Events

        private void button_Convert_Click(object sender, EventArgs e)
        {
            Hex2Colour.colourCount = 0;
            string code = Hex2Colour.ConvertStings(textIn.Text);
            textOut.Text = code;
        }

        private void button_Append_Click(object sender, EventArgs e)
        {
            string code = Hex2Colour.ConvertStings(textIn.Text);
            textOut.AppendText(code);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

            HelpForm help = new HelpForm();
            help.ShowDialog();
        }


        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm(Hex2Colour.Settings);
            //form.ApplySettings += ApplySettings;
            DialogResult result = form.ShowDialog();

            if (result != DialogResult.OK)
                return;

            ApplySettings(form.Value);
        }



        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void importSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = Settings.openFileDialog.ShowDialog();

                if (result != DialogResult.OK) return;

                Settings settings = Settings.Load(Settings.openFileDialog.FileName);
                ApplySettings(settings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Settings failed to load");
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textIn.Text = string.Empty;
        }

        private void Hex2ColourForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveLastSettings();
        }

        private void textBox_NameFormat_TextChanged(object sender, EventArgs e)
        {
            Hex2Colour.NameFormat = textBox_NameFormat.Text;
        }


        private void spriteSheetGeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(spriteSheetGeneratorPath);
            }
            catch
            {
                spriteSheetGeneratorToolStripMenuItem.Enabled = false;
            }
        }

        private void colourHarvestorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColourHarvesterForm grabber = new ColourHarvesterForm();

            DialogResult result = grabber.ShowDialog();

            if (result != DialogResult.OK)
                return;


            string joined = string.Join("\r\n", grabber.GrabbedStrings);
            textIn.Text = joined;
        }

        #endregion
    }
}
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore IDE0090 // Use 'new(...)'
#pragma warning restore IDE1006 // Naming Styles
