using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace SlipperyLand.Converters
{
    /// <summary>
    /// <see cref="Bitmap"/> and <see cref="BitmapSource"/> converter
    /// </summary>
    public class BitmapConverter : IValueConverter
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

        /// <summary>
        /// <see cref="Bitmap"/> to <see cref="BitmapSource"/>
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Bitmap bitmap && bitmap != null)
            {
                //https://stackoverflow.com/a/96470/
                var hBitmap = bitmap.GetHbitmap(Color.Transparent);
                var bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    System.Windows.Int32Rect.Empty,
                    BitmapSizeOptions.FromWidthAndHeight(bitmap.Width, bitmap.Height));
                DeleteObject(hBitmap);
                return bitmapSource;
            }
            return null;
        }

        /// <summary>
        /// <see cref="BitmapSource"/> to <see cref="Bitmap"/>
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new Bitmap(0, 0);
        }
    }
}
