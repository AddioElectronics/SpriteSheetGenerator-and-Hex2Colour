#pragma warning disable IDE0090 // Use 'new(...)'
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Reflection;

namespace SpriteSheetGenerator
{
    public static class Util
    {

        public static Size GetAverageSize(params Size[] sizes)
        {
            int width = 0;
            int height = 0;

            foreach(Size s in sizes)
            {
                width += s.Width;
                height += s.Height;
            }

            return new Size(width / sizes.Length, height / sizes.Length);
        }

        public static ImageFormat[] GetAllImageFormats()
        {
            List<ImageFormat> formats = new List<ImageFormat>();

            var imageFormatFields = typeof(ImageFormat).GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.SuppressChangeType);

            foreach (var item in imageFormatFields)
            {
                ImageFormat format = (ImageFormat)item.GetValue(null);
                formats.Add(format);
            }

            return formats.ToArray();
        }

        public static ImageFormat? GetImageFormat(string extension)
        {
            var formats = Util.GetAllImageFormats();
            return formats.FirstOrDefault(x => x.ToString().ToLower() == extension.ToLower());
        }

        public static bool IsPowerOfTwo(ulong x)
        {
            return (x & (x - 1)) == 0;
        }

        public static Size ScaleSize(this Size size, double scale)
        {
            return new Size((int)(size.Width * scale), (int)(size.Height * scale));
        }

        public static void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                url = url.Replace("&", "^&");
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true, CreateNoWindow = true });
            }
        }

    }
}
#pragma warning restore IDE0090 // Use 'new(...)'