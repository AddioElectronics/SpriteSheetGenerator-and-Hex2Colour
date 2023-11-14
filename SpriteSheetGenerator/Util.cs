#pragma warning disable IDE0090 // Use 'new(...)'
using System.Diagnostics;

namespace Hex2Colour
{
    public static class Util
    {
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

        public static Point PositionOnForm(this Form form, Control control)
        {
            Point screen = form.PointToScreen(control.Location);
            Point formPos = new Point(screen.X - form.Location.X, screen.Y - form.Location.Y);
            return formPos;
        }

    }
}
#pragma warning restore IDE0090 // Use 'new(...)'