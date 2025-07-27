using System.Drawing;
using CellTypes.Layers;
using GameTypes.Cells;
using GameTypes.TileSetTypes;
using GraphicalResources.Map;

namespace GraphicsEngine
{
    /// <summary>
    /// Renders a <see cref="MapLayer"/>
    /// </summary>
    public static class MapRenderer
    {
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

            return output.Scale(2);
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
