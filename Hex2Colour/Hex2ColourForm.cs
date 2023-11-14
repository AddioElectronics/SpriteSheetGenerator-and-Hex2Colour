#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable IDE0090 // Use 'new(...)'
#pragma warning disable IDE1006 // Naming Styles
using System.Drawing;
using System.Globalization;
using System.Resources;
using static Hex2Colour.Settings;

namespace Hex2Colour
{
    public partial class Hex2ColourForm : Form
    {
        #region Fields/Properties/Constants

        public const string americanColour = "color";
        public const string canadianColour = "colour";
        public const string fmtGDI = "const COLORREF {0} = 0x{1:X6}";
        public const string fmtCSHARP = "Color {0} = Color.FromArgb(0x{1:X6})";
        private const string settingsFilename = "settings" + Settings.EXTENSION;

        public static readonly Dictionary<LangsApis, string> formats = new Dictionary<LangsApis, string>()
        {
            {LangsApis.C_GDI, fmtGDI},
            {LangsApis.CSHARP_SYSDRAW,  fmtCSHARP}
        };

        public string ColourString => Settings.AmericanSpelling ? americanColour : canadianColour;
        public string DefaultNameFormat => ColourString + "{0}";

        public Settings Settings { get; set; }

        private LangsApis LangApi => Settings.LangApi;

        public string NameFormat
        {
            get
            {
                if (textBox_NameFormat.Text == string.Empty)
                    return DefaultNameFormat;
                else
                {
                    try
                    {
                        string.Format(textBox_NameFormat.Text, 0xFFFFFF, 1, 0xFF0000, 0xFF);
                    }
                    catch
                    {
                        MessageBox.Show("Invalid Name Format");
                        return DefaultNameFormat;
                    }

                    return textBox_NameFormat.Text;
                }
            }
        }

        #endregion

        #region Constructor

        public Hex2ColourForm()
        {
            InitializeComponent();
            LoadLastSettings();
        }

        #endregion

        #region Methods

        private void LoadLastSettings()
        {
            if (!File.Exists(settingsFilename))
            {
                Settings = new Settings();
                return;
            }

            try
            {
                Settings? settings = Settings.Load(settingsFilename);
                Settings = settings;
                Settings.FileName = settingsFilename;
            }
            catch
            {
                Settings = new Settings();
            }
        }

        private void SaveLastSettings()
        {
            Settings.NameFormat = textBox_NameFormat.Text;
            try
            {
                if (File.Exists(settingsFilename))
                {
                    Settings? settings = Settings.Load(settingsFilename);

                    //Only save if different
                    if (settings != Settings)
                        return;
                }
            }
            catch
            {
                Settings.Save(settingsFilename);
            }

            Settings.Save(settingsFilename);
        }

        private void ApplySettings(Settings settings)
        {
            Settings = settings;
            textBox_NameFormat.Text = settings.NameFormat;
        }


        private uint ChangeEndianess(uint value, bool hasAlpha)
        {
            if (Settings.SwapEndianess || !hasAlpha)
            {
                return (value & 0xFF000000) | ((value >> 16) & 0xFF) | (value & 0x00FF00) | ((value << 16) & 0xFF0000);
            }
            else
            {
                return ((value >> 24) & 0xFF) | ((value >> 8) & 0xFF00) | ((value << 8) & 0xFF0000) | ((value << 24) & 0xFF000000);
            }
        }

        private uint? ParseValue(string str, out uint origColour)
        {
            str = RemoveSpecifier(str);
            origColour = 0;
            if (uint.TryParse(str, NumberStyles.HexNumber, CultureInfo.CurrentCulture, out uint value))
            {
                origColour = value;
                bool hasALpha = str.Length == 6;
                uint colour = Settings.SwapEndianess ? ChangeEndianess(value, hasALpha) : value;
                return colour;
            }
            return null;
        }

        private bool ParseLine(string line, int index, out uint colour, out string? name, out string? comment)
        {
            string[] lsplit = line.Split(' ');
            uint? col = ParseValue(lsplit[0], out uint origColour);

            if (col == null)
            {
                name = null;
                comment = null;
                colour = 0;
                return false;
            }

            object nameObj = lsplit.Length > 1 ? lsplit[1] : index;
            string nameFmt = NameFormat != string.Empty ? NameFormat : "{0}";

            colour = col.Value;
            name = string.Format(nameFmt, nameObj, lsplit.Length == 1 ? string.Empty : index, origColour, colour);
            comment = lsplit.Length > 2 ? string.Join(' ', lsplit.Skip(2)) : null;
            return true;
        }

        private string FormatCode(LangsApis lang, string name, uint colour, string? comment)
        {
            return string.Format(formats[lang], name, colour) + GetEndLine(comment);
        }

        private string ConvertStings()
        {
            string[] lines = textIn.Text.Split("\r\n");

            List<string> values = new List<string>();

            for (int i = 0; i < lines.Length; i++)
            {
                if (ParseLine(lines[i], i, out uint colour, out string? name, out string? comment))
                {
                    string code = FormatCode(LangApi, name, colour, comment);
                    values.Add(code);
                }
            }

            string result = string.Empty;
            values.ForEach(x => result += x);

            if (Settings.AddToClipboard)
            {
                Clipboard.SetText(result);
            }
            return result;
        }

        static string GetEndLine(string? comment)
        {
            if (comment == null || comment.Length == 0)
            {
                return ";\r\n";
            }
            else
            {
                return $"; //{comment}\r\n";
            }
        }

        private static string RemoveSpecifier(string str)
        {
            if (str.StartsWith("0x"))
                return str.Substring(2);
            else if (str.StartsWith('#'))
                return str.Substring(1);
            else
                return str;
        }

        #endregion

        #region Events

        private void button_Convert_Click(object sender, EventArgs e)
        {
            string code = ConvertStings();
            textOut.Text = code;

        }

        private void button_Append_Click(object sender, EventArgs e)
        {
            string code = ConvertStings();
            textOut.AppendText(code);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Hex2ColourHelp help = new Hex2ColourHelp();
            help.ShowDialog();
        }


        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hex2ColourSettings form = new Hex2ColourSettings(Settings);
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

        }

        private void webGrabberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColourHarvester grabber = new ColourHarvester();

            DialogResult result = grabber.ShowDialog();

            if (result != DialogResult.OK)
                return;



        }

        #endregion


    }
}
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore IDE0090 // Use 'new(...)'
#pragma warning restore IDE1006 // Naming Styles
