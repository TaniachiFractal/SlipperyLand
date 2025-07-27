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
    /// <see cref="Bitmap"/> and <see cref="BitmapImage"/> converter
    /// </summary>
    public class BitmapConverter : IValueConverter
    {
        /// <summary>
        /// <see cref="Bitmap"/> to <see cref="BitmapImage"/>
        /// </summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            { return null; }

            var bitmap = (Bitmap)value;
            using var memory = new MemoryStream();
            bitmap.Save(memory, ImageFormat.Png);
            memory.Position = 0;

            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = memory;
            bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            bitmapImage.EndInit();
            bitmapImage.Freeze();

            return bitmapImage;
        }

        /// <summary>
        /// <see cref="BitmapImage"/> to <see cref="Bitmap"/>
        /// </summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new Bitmap(((BitmapImage)value).StreamSource);
        }
    }
}
