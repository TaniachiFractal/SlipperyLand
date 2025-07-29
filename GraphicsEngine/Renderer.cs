using System.Drawing;
using GameTypes.Cells;
using GameTypes.Layers;
using GameTypes.TileSpriteSetTypes;
using GraphicalResources.Map;
using GameTypes.Extensions;

namespace GraphicsEngine
{
    /// <summary>
    /// Renders images
    /// </summary>
    public static class Renderer
    {
        private const byte Ups = 2;
        private const byte CharaMarginDiv = 3;

        /// <summary>
        /// Get the image of a map layer
        /// </summary>
        /// <param name="map">The map layer to render</param>
        /// <param name="tileSetType">The tile set to render the map with</param>
        public static Bitmap Render(this MapLayer map, MapTileSetType tileSetType)
        {
            var tileSet = MapTileSetDict.Get(tileSetType);
            var slp = tileSet.Get(MapCellType.Slippery);
            var tileSize = slp.Width;

            var outWidth = map.Cols * tileSize;
            var outHeight = map.Rows * tileSize;

            var output = new Bitmap(outWidth, outHeight);

            using (var canvas = Graphics.FromImage(output))
            {
                for (var col = 0; col < map.Cols; col++)
                {
                    for (var row = 0; row < map.Rows; row++)
                    {
                        var tile = tileSet.Get(map.ReadCell(row, col));
                        canvas.DrawImageUnscaled(tile, col * tileSize, row * tileSize);
                    }
                }
            }

            return output.Scale(Ups);
        }

        /// <summary>
        /// Render the character layer
        /// </summary>
        public static Bitmap Render(this CharaLayer charas, Chara mainChara, int outWidth, int outHeight)
        {
            var output = new Bitmap(outWidth, outHeight);

            using (var canvas = Graphics.FromImage(output))
            {
            }

            return output.Scale(Ups);
        }

        private static Bitmap Scale(this Bitmap originalImage, int scale)
        {
            var newWidth = originalImage.Width * scale;
            var newHeight = originalImage.Height * scale;

            var scaledImage = new Bitmap(newWidth, newHeight);

            using (var canvas = Graphics.FromImage(scaledImage))
            {
                canvas.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                canvas.DrawImage(originalImage, 0, 0, newWidth, newHeight);
            }

            return scaledImage;
        }
    }
}
