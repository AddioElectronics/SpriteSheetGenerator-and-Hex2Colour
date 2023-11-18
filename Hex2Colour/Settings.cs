namespace Hex2Colour
{
    public sealed class Settings : IEquatable<Settings>, ICloneable
    {
        public enum LangsApis : int
        {
            C_GDI,
            CSHARP_SYSDRAW
        }

        #region Constants

        public const string EXTENSION = ".hx2col";
        public const uint MAGIC = 0xFE2CFE2C;
        public const uint VERSION = 0x01;
        public const string fileDialogSettingsFilter = "Hex2Colour Files | *.hx2col";

        #endregion

        #region Properties/Fields

        public static SaveFileDialog saveFileDialog = new SaveFileDialog()
        {
            Filter = fileDialogSettingsFilter
        };

        public static OpenFileDialog openFileDialog = new OpenFileDialog()
        {
            Filter = fileDialogSettingsFilter
        };

        internal string? FileName { get; set; }

        public int LangApi { get; set; }
        public bool SwapEndianess { get; set; } = true;
        public bool AlphaMSB { get; set; } = true;
        public bool AmericanSpelling { get; set; }
        public bool AddToClipboard { get; set; }
        public bool GenerateArrays { get; set; } = true;

        public bool AlwaysFormatName { get; set; }

        public string NameFormat { get; set; } = string.Empty;

        public static bool operator ==(Settings? a, Settings? b)
        {
            if ((ReferenceEquals(a, null) || ReferenceEquals(b, null)) && !ReferenceEquals(a, b)) 
                return false;

            return a.AmericanSpelling == b.AmericanSpelling &&
                a.NameFormat == b.NameFormat &&
                a.LangApi == b.LangApi &&
                a.SwapEndianess == b.SwapEndianess &&
                a.AlphaMSB == b.AlphaMSB &&
                a.AddToClipboard == b.AddToClipboard &&
                a.GenerateArrays == b.GenerateArrays;
        }

        public static bool operator !=(Settings? a, Settings? b)
        {
            bool equals = a == b;
            return !equals;
        }

        public bool Equals(Settings? other)
        {
            return this == other;
        }

        public override bool Equals(object? obj)
        {
            if (!(obj is Settings))
                return false;

            return Equals(obj as Settings);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads a settings file and returns the object.
        /// </summary>
        /// <param name="path">File path</param>
        /// <returns>Settings object</returns>
        /// <exception cref="EndOfStreamException"></exception>
        /// <exception cref="IOException"></exception>
        /// <exception cref="FileFormatException"></exception>
        public static Settings Load(string path)
        {
            using FileStream fs = File.OpenRead(path);
            using BinaryReader br = new BinaryReader(fs);

            uint magic = br.ReadUInt32();

            if (magic != MAGIC)
            {
                throw new FileFormatException();
            }

            //Unused
            uint version = br.ReadUInt32();

            Settings settings = new Settings();
            settings.LangApi = br.ReadInt32();
            settings.SwapEndianess = br.ReadBoolean();
            settings.AlphaMSB = br.ReadBoolean();
            settings.AmericanSpelling = br.ReadBoolean();
            settings.AddToClipboard = br.ReadBoolean();
            settings.GenerateArrays = br.ReadBoolean();
            settings.AlwaysFormatName = br.ReadBoolean();
            settings.NameFormat = br.ReadString();

            fs.Close();
            return settings;
        }

        /// <summary>
        /// Saves the settings to <paramref name="path"/>.
        /// </summary>
        /// <param name="path">File path</param>
        /// <exception cref="IOException"></exception>
        public void Save(string path)
        {
            //try
            //{
            using FileStream fs = File.OpenWrite(path);
            using BinaryWriter bw = new BinaryWriter(fs);

            bw.Write(MAGIC);
            bw.Write(VERSION);

            bw.Write((int)LangApi);
            bw.Write(SwapEndianess);
            bw.Write(AlphaMSB);
            bw.Write(AmericanSpelling);
            bw.Write(AddToClipboard);
            bw.Write(GenerateArrays);
            bw.Write(AlwaysFormatName);
            bw.Write(NameFormat);

            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //    return false;
            //}
        }

        public object Clone()
        {
            Settings clone = new Settings();
            clone.AlphaMSB = AlphaMSB;
            clone.AddToClipboard = AddToClipboard;
            clone.NameFormat = NameFormat;
            clone.SwapEndianess = SwapEndianess;
            clone.LangApi = LangApi;
            clone.AmericanSpelling = AmericanSpelling;
            clone.GenerateArrays = GenerateArrays;
            clone.AlwaysFormatName = AlwaysFormatName;
            return clone;
        }

        #endregion
    }
}
