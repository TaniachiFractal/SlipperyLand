using SlipperyLand.GameTypes.Cells;
using SlipperyLand.GameTypes.Extensions;
using SlipperyLand.GameTypes.Layers;

namespace SlipperyLand.MainLogic
{
    /// <summary>
    /// Setups for the game field
    /// </summary>
    public static class GameSetup
    {
        /// <summary>
        /// Set the position of a <see cref="CharaCell"/> based on map row and col
        /// </summary>
        public static void SetCharaRowColPos(this CharaCell chara, int row, int col, int tileSize)
        {
            chara.X = row * tileSize;
            chara.Y = (col * tileSize) - (tileSize / 3);
        }

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
            for (var row = 0; row < mapLayer.Rows - 1; row++)
            {
                mapLayer.SetCell(row, 0, MapCellType.Wall);
            }
            for (var row = 0; row < mapLayer.Rows - 1; row++)
            {
                mapLayer.SetCell(row, mapLayer.Cols - 1, MapCellType.Wall);
            }
            for (var col = 1; col < mapLayer.Cols - 1; col++)
            {
                mapLayer.SetCell(0, col, MapCellType.Wall, 1);
            }
            for (var col = 0; col < mapLayer.Cols; col++)
            {
                mapLayer.SetCell(mapLayer.Rows - 1, col, MapCellType.Wall, 1);
            }
        }
    }
}
