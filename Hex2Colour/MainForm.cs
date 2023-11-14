#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable IDE0090 // Use 'new(...)'
#pragma warning disable IDE1006 // Naming Styles
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Text.RegularExpressions;
using static Hex2Colour.Settings;

namespace Hex2Colour
{
    public partial class MainForm : Form
    {
        #region Fields/Properties/Constants

        public const string americanColour = "color";
        public const string canadianColour = "colour";
        public const string fmtGDI = "const COLORREF {0} = 0x{1:X6}";
        public const string fmtCSHARP = "Color {0} = Color.FromArgb(0x{1:X6})";
        private const string settingsFilename = "settings" + Settings.EXTENSION;


        static readonly string[] newLines = new string[]
        {
            "\r\n",
            "\r",
            "\n",
        };

        public static readonly Dictionary<LangsApis, string> formats = new Dictionary<LangsApis, string>()
        {
            {LangsApis.C_GDI, fmtGDI},
            {LangsApis.CSHARP_SYSDRAW,  fmtCSHARP}
        };


        public string ColourString => Settings.AmericanSpelling ? americanColour : canadianColour;
        public string DefaultNameFormat => ColourString + "{0}";

        public static Settings Settings { get; set; }

        static LangsApis LangApi => Settings.LangApi;

        static bool GenerateArrays => Settings.GenerateArrays;

        static bool AlwaysFormatName => Settings.AlwaysFormatName;

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


        /// <summary>
        /// Colour count for the current process, not including arrays.
        /// </summary>
        private int colourCount;

        readonly string? spriteSheetGeneratorPath;
        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
            LoadLastSettings();

            spriteSheetGeneratorPath = Directory.EnumerateFiles(Environment.CurrentDirectory).FirstOrDefault(x => Path.GetFileName(x) == "SpriteSheetGenerator.exe");
            spriteSheetGeneratorToolStripMenuItem.Enabled = spriteSheetGeneratorPath != null;
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

                    //No changes
                    if (settings == Settings)
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

        bool IsEmptyLine(string line)
        {
            Regex regex = new Regex("^\\s*$");
            return regex.IsMatch(line);
        }

        string FormatName(object name, int index, uint colour, uint origColour)
        {
            bool formatName = true;
            bool hasName = false;   //False will be replaced with index

            if (name.GetType() == typeof(string))
            {
                hasName = true;
                string sname = (string)name;
                char first = (sname)[0];

                //Check Format symbols
                if ((!AlwaysFormatName && first != '%') ||
                    (AlwaysFormatName && first == '!'))
                    formatName = false;

                //Remove format symbol
                if (first == '!' || first == '%')
                    name = sname.Substring(1);
            }

            string nameFmt = NameFormat != string.Empty && formatName ? NameFormat : "{0}";

            return string.Format(
                nameFmt,
                name,
                !hasName ? string.Empty : index, //Use index if name already used
                origColour,
                colour);
        }

        private bool ParseLine(string line, int index, out uint colour, out string? name, out string? comment)
        {
            string[] lsplit = line.Split(' ');

            //Skip line
            if (IsEmptyLine(line))
            {
                //Array has ended, unless a new array is defined, colours will be created normally.
                ArrayGenerator.currentArray = null;
                goto ReturnFalse;
            }

            uint? col = ParseValue(lsplit[0], out uint origColour);

            if (col == null)
            {
                if (GenerateArrays)
                {
                    //Start new array.
                    string arrayName = lsplit[0];
                    ArrayGenerator.StartArray(arrayName);
                }

                goto ReturnFalse;
            }

            if (GenerateArrays && ArrayGenerator.currentArray != null)
            {
                colour = col.Value;
                comment = lsplit.Length > 1 ? string.Join(' ', lsplit.Skip(1)) : null;
                //Colour is added to array
                ArrayGenerator.AddColour(colour, comment);
                name = null;
                return true;
            }

            colour = col.Value;
            object nameObj = lsplit.Length > 1 && lsplit[1] != "$" ? lsplit[1] : index; //If name null or $ use index
            name = FormatName(nameObj, index, colour, origColour);                      //Format name
            comment = lsplit.Length > 2 ? string.Join(' ', lsplit.Skip(2)) : null;      //Add comment
            return true;

        ReturnFalse:
            name = null;
            comment = null;
            colour = 0;
            return false;
        }

        private string FormatCode(LangsApis lang, string name, uint colour, string? comment)
        {
            return string.Format(formats[lang], name, colour) + GetEndLine(comment);
        }

        private string ConvertStings()
        {
            ArrayGenerator.Clear();
            string[] lines = textIn.Text.Split("\r\n");

            List<string> values = new List<string>();


            for (int i = 0; i < lines.Length; i++)
            {
                if (ParseLine(lines[i], colourCount, out uint colour, out string? name, out string? comment))
                {
                    if (GenerateArrays && ArrayGenerator.currentArray != null)
                    {
                        //Was added to array.
                        continue;
                    }

                    string code = FormatCode(LangApi, name, colour, comment);
                    values.Add(code);
                    colourCount++;
                }
            }

            string result = string.Empty;
            values.ForEach(x => result += x);

            if (GenerateArrays && ArrayGenerator.arrays.Count > 0)
            {
                result += "\r\n\r\n" + ArrayGenerator.GenerateAllArrays();
            }



            if (result != string.Empty && Settings.AddToClipboard)
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
            colourCount = 0;
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

            HelpForm help = new HelpForm();
            help.ShowDialog();
        }


        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm(Settings);
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

        //10 minute array generator
        static class ArrayGenerator
        {
            public const string fmtGDIArray = "const COLORREF {0}[] = \r\n{{";
            public const string fmtGDIItem = "\t0x{0:X6}";
            public const string fmtCSHARPArray = "Color[] {0} = new Color[]\r\n{{";
            public const string fmtCSHARPItem = "\tColor.FromArgb(0x{0:X6})";

            public static List<ColourArray> arrays = new List<ColourArray>();

            public static ColourArray? currentArray;

            public static readonly Dictionary<LangsApis, string> arrayStartFormats = new Dictionary<LangsApis, string>()
            {
                {LangsApis.C_GDI, fmtGDIArray},
                {LangsApis.CSHARP_SYSDRAW,  fmtCSHARPArray}
            };

            public static readonly Dictionary<LangsApis, string> arrayItemFormats = new Dictionary<LangsApis, string>()
            {
                {LangsApis.C_GDI, fmtGDIItem},
                {LangsApis.CSHARP_SYSDRAW,  fmtCSHARPItem}
            };

            public static void Clear()
            {
                arrays.Clear();
            }

            public static void StartArray(string name)
            {
                ColourArray arr = new ColourArray(name);
                arrays.Add(arr);
                currentArray = arr;
            }

            public static void AddColour(uint colour, string? comment)
            {
                if (currentArray == null)
                    throw new NullReferenceException("This should not be null when here");

                ArrayItem item = new ArrayItem()
                {
                    colour = colour,
                    comment = comment
                };

                currentArray.items.Add(item);
            }

            public static string? GenerateAllArrays()
            {
                if (arrays.Count == 0)
                    return null;

                return string.Join("\r\n", arrays.Select(x => x.Generate()));
            }


            public class ArrayItem
            {
                public uint colour;
                public string? comment;
            }

            public class ColourArray
            {

                public List<ArrayItem> items = new List<ArrayItem>();

                public string name;

                public ColourArray(string name)
                {
                    this.name = name;
                }

                static string FormatArrayStart(string name, LangsApis lang)
                {
                    return string.Format(arrayStartFormats[lang], name);
                }

                static string FormatItem(uint colour, LangsApis lang, string? comment)
                {
                    string formatted = string.Format(arrayItemFormats[lang], colour) + ",";

                    //Add comment if exists
                    if (comment != null)
                        formatted += $"\t//{comment}";

                    return formatted;
                }

                public string Generate()
                {
                    //Return empty because it will probably get used in string.join
                    if (items.Count == 0)
                        return string.Empty;

                    string start = FormatArrayStart(name, LangApi);
                    string formattedItems = string.Join("\r\n", items.Select(x => FormatItem(x.colour, LangApi, x.comment)));
                    string end = "\r\n};\r\n\r\n";

                    return string.Join("", start, formattedItems, end);

                }
            }
        }
    }
}
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore IDE0090 // Use 'new(...)'
#pragma warning restore IDE1006 // Naming Styles
