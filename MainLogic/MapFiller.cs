using GameTypes.Cells;
using GameTypes.Extensions;
using GameTypes.Layers;

namespace MainLogic
{
    /// <summary>
    /// Fills <see cref="MapLayer"/>s with stuff
    /// </summary>
    public static class MapFiller
    {
        /// <summary>
        /// Fill the map with slippery tiles
        /// </summary>
        public static void FillWithSlippery(this MapLayer mapLayer)
        {
            for (var row = 0; row < mapLayer.Rows; row++)
            {
                for (var col = 0; col < mapLayer.Cols; col++)
                {
                    mapLayer.SetCell(row, col, MapCellType.Slippery);
                }
            }
        }

        /// <summary>
        /// Set the wall border around the map
        /// </summary>
        public static void SetWallBorder(this MapLayer mapLayer)
        {
            for (var row = 0; row < mapLayer.Rows; row++)
            {
                mapLayer.SetCell(row, 0, MapCellType.Wall);
            }
            for (var row = mapLayer.Rows - 1; row < mapLayer.Rows; row++)
            {
                mapLayer.SetCell(row, mapLayer.Cols - 1, MapCellType.Wall);
            }
            for (var col = 1; col < mapLayer.Cols - 1; col++)
            {
                mapLayer.SetCell(0, col, MapCellType.Wall);
            }
            for (var col = mapLayer.Cols - 1; col < mapLayer.Cols - 1; col++)
            {
                mapLayer.SetCell(0, col, MapCellType.Wall);
            }
        }
    }
}
