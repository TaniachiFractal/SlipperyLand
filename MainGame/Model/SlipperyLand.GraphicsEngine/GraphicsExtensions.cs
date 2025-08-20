using System.Drawing;
using System.Drawing.Drawing2D;

namespace SlipperyLand.GraphicsEngine
{
    /// <summary>
    /// Extensions for <see cref="Graphics"/> canvases
    /// </summary>
    static internal class GraphicsExtensions
    {
        /// <summary>
        /// Upscale a <see cref="Bitmap"/> onto another <see cref="Graphics"/> canvas
        /// </summary>
        public static void UpscaleTo(this Bitmap sourceBmp, Graphics targetCanvas, int upsWidth, int upsHeight)
            => targetCanvas.DrawImage(sourceBmp, 0, 0, upsWidth, upsHeight);

        /// <summary>
        /// Set the <see cref="Graphics.InterpolationMode"/> to <b><u><see cref="InterpolationMode.NearestNeighbor"/></u></b>
        /// </summary>
        public static void SetNearInterMode(this Graphics canvas)
            => canvas.InterpolationMode = InterpolationMode.NearestNeighbor;

    }
}
