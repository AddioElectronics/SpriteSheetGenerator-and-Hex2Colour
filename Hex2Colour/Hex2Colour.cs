using System.Globalization;
using System.Text.RegularExpressions;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace Hex2Colour
{
    public static class Hex2Colour
    {
        //This shit is messy!

        public enum ParseResult
        {
            None = 0,
            Variable,
            Array,
            ArrayStart,
            EmptyLine 
        }

        const string langApiFilename = "langs.json";
        const string americanColour = "color";
        const string canadianColour = "colour";
        const string validNamePattern = "\\b[_a-zA-Z]?[a-zA-Z0-9_]+\\b";

        static readonly Regex validNameRegex = new Regex(validNamePattern);
        static readonly string[] newLines = new string[] { "\r\n", "\r", "\n", };

        static bool displayedInvalidNameFormat;
        private static string _nameFormat;

        static Hex2Colour()
        {
            ParseLanguageApiFile();
        }

        public static readonly List<LanguageAPI> formats = new List<LanguageAPI>();
        public static LanguageAPI format => formats[LangApi];

        /// <summary>
        /// Colour count for the current input, not including arrays.
        /// </summary>
        internal static int colourCount;

        public static Settings Settings { get; set; }
        public static int LangApi => Settings.LangApi;
        static string ColourString => Settings.AmericanSpelling ? americanColour : canadianColour;
        static string DefaultNameFormat => ColourString + "{0}";   
        static bool GenerateArrays => Settings.GenerateArrays;
        static bool AlwaysFormatName => Settings.AlwaysFormatName;


        public static string NameFormat
        {
            get
            {
                if (_nameFormat == null || _nameFormat == string.Empty)
                    return DefaultNameFormat;
                else
                {
                    try
                    {
                        string.Format(_nameFormat, 0xFFFFFF, 1, 0xFF0000, 0xFF);
                    }
                    catch
                    {
                        if(!displayedInvalidNameFormat)
                        MessageBox.Show("Invalid Name Format");
                        displayedInvalidNameFormat = true;
                        return DefaultNameFormat;
                    }

                    return _nameFormat;
                }
            }
            set
            {
                _nameFormat = value;
            }
        }

        public static string ConvertStings(string input)
        {
            displayedInvalidNameFormat = false;
            ArrayGenerator.Clear();
            string[] lines = input.Split("\r\n");

            List<string> values = new List<string>();

            ParseResult lastOuput = ParseResult.None;

            for (int i = 0; i < lines.Length; i++)
            {
                ParseResult pResult = ParseLine(lines[i], colourCount, out uint colour, out string? name, out string? comment);

                if (pResult == ParseResult.Variable)
                {
                    string code = FormatCode(LangApi, name, colour, comment);
                    values.Add(code);
                    colourCount++;
                }
                else if (pResult == ParseResult.ArrayStart)
                {
                }
                else if (pResult == ParseResult.Array)
                {
                }
                else if (pResult == ParseResult.EmptyLine)
                {
                    if (lastOuput == ParseResult.Variable)
                        values.Add("\r\n");
                }

                lastOuput = pResult;
            }

            string result = string.Empty;
            values.ForEach(x => result += x);

            if (GenerateArrays && ArrayGenerator.arrays.Count > 0)
            {
                result += ArrayGenerator.GenerateAllArrays();
            }



            if (result != string.Empty && Settings.AddToClipboard)
            {
                Clipboard.SetText(result);
            }
            return result;
        }

        public static ParseResult ParseLine(string line, int index, out uint colour, out string? name, out string? comment)
        {
            ParseResult result = ParseResult.None;
            string[] lsplit = line.Split(' ');

            //Skip line
            if (IsEmptyLine(line))
            {
                //Array has ended, unless a new array is defined, colours will be created normally.
                ArrayGenerator.currentArray = null;
                result = ParseResult.EmptyLine;
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
                return ParseResult.Array;
            }

            colour = col.Value;

            //String or int
            object nameObj;

            //If name null or # use index
            if(lsplit.Length > 1 && lsplit[1] != "#")
            {
                nameObj = validNameRegex.Match(lsplit[1]).Success ? lsplit[1] : "INVALID_NAME";
            }
            else
            {
                nameObj = index;
            }

            name = FormatName(nameObj, index, colour, origColour);                      //Format name

            if (!validNameRegex.Match(name).Success)
            {
                name = "INVALID_NAME_FORMAT";
            }

            comment = lsplit.Length > 2 ? string.Join(' ', lsplit.Skip(2)) : null;      //Add comment
            return ParseResult.Variable;

        ReturnFalse:
            name = null;
            comment = null;
            colour = 0;
            return result;
        }

        private static void ParseLanguageApiFile()
        {
            string text = File.ReadAllText(langApiFilename);

            var jsonArray = JsonNode.Parse(text);
            LanguageAPI[]? langs = (LanguageAPI[]?)JsonSerializer.Deserialize(jsonArray, typeof(LanguageAPI[]));

            if (langs.All(x => x.format == null))
            {
                throw new NullReferenceException($"Failed to parse {langApiFilename}");
            }

            formats.AddRange(langs);
        }

        private static uint ChangeEndianess(uint value, bool hasAlpha)
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

        private static uint? ParseValue(string str, out uint origColour)
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

        private static bool IsEmptyLine(string line)
        {
            Regex regex = new Regex("^\\s*$");
            return regex.IsMatch(line);
        }

        private static string FormatName(object name, int index, uint colour, uint origColour)
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



        private static string FormatCode(int lang, string name, uint colour, string? comment)
        {
            return string.Format(format.format, name, colour) + GetEndLine(comment);
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

        static string RemoveSpecifier(string str)
        {
            if (str.StartsWith("0x"))
                return str.Substring(2);
            else if (str.StartsWith('#'))
                return str.Substring(1);
            else
                return str;
        }
    }
}
