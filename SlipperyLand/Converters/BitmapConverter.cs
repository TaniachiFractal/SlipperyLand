using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace SlipperyLand.Converters
{
    /// <summary>
    /// <see cref="Bitmap"/> and <see cref="BitmapSource"/> converter
    /// </summary>
    public class BitmapConverter : IValueConverter
    {
        /// <summary>
        /// <see cref="Bitmap"/> to <see cref="BitmapSource"/>
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Bitmap bmp && bmp != null)
            {
                var bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    bmp.GetHbitmap(),
                    IntPtr.Zero,
                    System.Windows.Int32Rect.Empty,
                    BitmapSizeOptions.FromWidthAndHeight(bmp.Width, bmp.Height));
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
