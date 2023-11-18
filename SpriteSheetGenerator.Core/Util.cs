#pragma warning disable IDE0090 // Use 'new(...)'
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Reflection;

namespace SpriteSheetGenerator
{
    public static class Util
    {

        ///<summary>
        /// Manipulates the background of an Icon
        ///</summary>
        ///<param name="icon">Icon source</param>
        ///<param name="disposeIcon">Icon dispose</param>
        ///<returns><see cref="Icon"/> or <see cref="T:null"/></returns>
        public static Icon MakeTransparentIcon(Icon icon, bool disposeIcon = true)
        {
            if (icon != null)
            {
                using (Bitmap bm = icon.ToBitmap())
                {
                    bm.MakeTransparent(Color.Transparent); // define the background as transparent
                                                           // you need to align the color to your needs
                    if (disposeIcon)
                    {
                        icon.Dispose();
                    }
                    return Icon.FromHandle(bm.GetHicon());
                }
            }
            return null;
        }

        public static bool AllImagesSameSize(params Image[] images)
        {
            if (images.Length == 1)
                return true;

            int width = images[0].Width;
            int height = images[0].Height;
            return images.All(x => x.Width == width || x.Height == height);
        }

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
#pragma warning disable 8604
            List<ImageFormat> formats = new List<ImageFormat>();

            var imageFormatFields = typeof(ImageFormat).GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.SuppressChangeType);

            foreach (var item in imageFormatFields)
            {
                ImageFormat format = (ImageFormat)item.GetValue(null);

                formats.Add(format);
            }

            return formats.ToArray();
#pragma warning restore 8604
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
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.