using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Hex2Colour.Settings;

namespace Hex2Colour
{
    public partial class SettingsForm : Form
    {
        #region Delegates
        /// <summary>
        /// Handler used to pass settings to other forms.
        /// </summary>
        /// <param name="settings"></param>
        public delegate void SettingsHandler(Settings settings);

        /// <summary>
        /// Event called when user hits the apply button.
        /// </summary>
        public event SettingsHandler ApplySettings;

        #endregion

        #region Properties/Fields

        internal static readonly Dictionary<string, LangsApis> langs = new Dictionary<string, LangsApis>()
        {
            {"C/C++ GDI", LangsApis.C_GDI},
            {"C# System.Drawing",  LangsApis.CSHARP_SYSDRAW}
        };


        /// <summary>
        /// Result
        /// </summary>
        public Settings Value { get; private set; }

        /// <summary>
        /// Path to the last settings file that was opened or saved.
        /// </summary>
        public string? FileName
        {
            get => _fileName;
            set
            {
                _fileName = value;
                saveToolStripMenuItem.Enabled = value != null;
            }
        }

        private string? _fileName;
        private Settings? _original;
        private bool ChangesMade => Value != _original;

        #endregion

        #region Constructors

        public SettingsForm()
        {
            InitializeComponent();
            comboBox_Language.Items.AddRange(langs.Keys.ToArray());
            comboBox_Language.SelectedIndex = 0;
            comboBox_Language.SelectedIndexChanged += comboBox_Language_SelectedIndexChanged;
        }

        public SettingsForm(Settings settings) : this()
        {
            Value = (Settings)settings.Clone();
            _original = (Settings)settings.Clone();
            SetControls(Value);
        }

        #endregion

        void SetControls(Settings settings)
        {
            comboBox_Language.SelectedIndex = (int)settings.LangApi;
            checkBox_AlphaMSB.Checked = settings.AlphaMSB;
            checkBox_Clipboard.Checked = settings.AddToClipboard;
            checkBox_Murica.Checked = settings.AmericanSpelling;
            checkBox_SwapEndian.Checked = settings.SwapEndianess;
            checkBox_GenerateArrays.Checked = settings.GenerateArrays;
            checkBox_AlwaysFormatName.Checked = settings.AlwaysFormatName;
            textBox_NameFormat.Text = settings.NameFormat;
        }

        #region Events

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = Settings.openFileDialog.ShowDialog();

            if (result != DialogResult.OK)
                return;

            try
            {
                Settings settings = Settings.Load(Settings.openFileDialog.FileName);

                Value = settings;
                FileName = Settings.openFileDialog.FileName;
                _original = (Settings)settings.Clone();
                SetControls(Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Settings failed to load");
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //If no changes do not save
            if (FileName == null ||
                (Value.FileName != null && Value.FileName == FileName && Value == _original))
                return;

            try
            {
                Value.Save(FileName);
                Value.FileName = FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Settings failed to save");
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog.ShowDialog();

            if (result != DialogResult.OK)
                return;

            try
            {
                //If no changes do not save
                if (Value.FileName != null && Value.FileName == Settings.saveFileDialog.FileName && Value == _original)
                    return;

                Value.Save(Settings.saveFileDialog.FileName);
                Value.FileName = Settings.saveFileDialog.FileName;
                FileName = Settings.saveFileDialog.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Settings failed to save");
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void okTStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void applyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.None;
            ApplySettings?.Invoke(Value);
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }



        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == checkBox_AlphaMSB)
            {
                Value.AlphaMSB = checkBox_AlphaMSB.Checked;
            }
            else if (sender == checkBox_SwapEndian)
            {
                Value.SwapEndianess = checkBox_SwapEndian.Checked;
            }
            else if (sender == checkBox_Clipboard)
            {
                Value.AddToClipboard = checkBox_Clipboard.Checked;
            }
            else if (sender == checkBox_Murica)
            {
                Value.AmericanSpelling = checkBox_Murica.Checked;

                if (Value.AmericanSpelling)
                {
                    Random random = new Random((int)DateTime.Now.Ticks);

                    if (random.Next(100) >= 97)
                    {
                        //Just a joke! Dont take it personally
                        Stream stream = Resource.easteregg;
                        System.Media.SoundPlayer sound = new System.Media.SoundPlayer(stream);
                        sound.Play();
                    }
                }
            }
            else if (sender == checkBox_GenerateArrays)
            {
                Value.GenerateArrays = checkBox_GenerateArrays.Checked;
            }
            else if (sender == checkBox_AlwaysFormatName)
            {
                Value.AlwaysFormatName = checkBox_AlwaysFormatName.Checked;
            }
        }


        private void comboBox_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox_Language.SelectedIndex;
            Value.LangApi = (LangsApis)index;// Enum.GetValues<Settings.LangsApis>()[index];
        }

        private void textBox_NameFormat_TextChanged(object sender, EventArgs e)
        {
            Value.NameFormat = textBox_NameFormat.Text;
        }

        #endregion
    }
}
