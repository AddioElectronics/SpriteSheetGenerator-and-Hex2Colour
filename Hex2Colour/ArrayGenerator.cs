namespace Hex2Colour
{
    static class ArrayGenerator
    {
        public static List<ColourArray> arrays = new List<ColourArray>();
        public static ColourArray? currentArray;

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

        public static void Clear()
        {
            currentArray = null;
            arrays.Clear();
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

            public string Generate()
            {
                //Return empty because it will probably get used in string.join
                if (items.Count == 0)
                    return string.Empty;

                string start = string.Format(Hex2Colour.format.arrayStart, name);
                string formattedItems = string.Join("\r\n", items.Select(x => FormatItem(x.colour, Hex2Colour.LangApi, x.comment)));
                string end = Hex2Colour.format.arrayEnd;

                return string.Join("", start, formattedItems, end);
            }

            static string FormatItem(uint colour, int lang, string? comment)
            {
                string formatted = string.Format(Hex2Colour.format.arrayItem, colour) + ",";

                //Add comment if exists
                if (comment != null)
                    formatted += $"\t//{comment}";

                return formatted;
            }
        }
    }
}
