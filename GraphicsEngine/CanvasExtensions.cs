using System.Drawing;
using System.Drawing.Drawing2D;

namespace GraphicsEngine
{
    /// <summary>
    /// Extensions for <see cref="Graphics"/> canvases
    /// </summary>
    static internal class CanvasExtensions
    {
        /// <summary>
        /// Upscale a <see cref="Bitmap"/> onto another <see cref="Graphics"/> canvas
        /// </summary>
        public static void UpscaleTo(this Bitmap sourceBmp, Graphics targetCanvas, int upsWidth, int upsHeight)
            => targetCanvas.DrawImage(sourceBmp, 0, 0, upsWidth, upsHeight);

        /// <summary>
        /// Set the <see cref="Graphics.InterpolationMode"/> of a <see cref="Graphics"/> canvas to <see cref="InterpolationMode.NearestNeighbor"/>
        /// </summary>
        /// <param name="canvas"></param>
        public static void SetNearInterMode(this Graphics canvas)
            => canvas.InterpolationMode = InterpolationMode.NearestNeighbor;
    }
}
