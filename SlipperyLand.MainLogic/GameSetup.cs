using SlipperyLand.GameTypes.Cells.Map;
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
        /// Setup the character layer
        /// </summary>
        public static void Setup(this CharaLayer charaLayer, int spriteSize, int tileSize)
        {
            var mc = charaLayer.MainChara;
            mc.SetSpriteSize(spriteSize);
            mc.SetupHitbox();
            mc.SetCharaRowColPos(1, 1, tileSize);
        }

        /// <summary>
        /// Setup the map layer
        /// </summary>
        public static void Setup(this MapLayer mapLayer)
        {
            mapLayer.FillWithSlippery();
            mapLayer.SetWallBorder();
        }

        private static void FillWithSlippery(this MapLayer mapLayer)
        {
            for (var row = 0; row < mapLayer.Rows; row++)
            {
                for (var col = 0; col < mapLayer.Cols; col++)
                {
                    mapLayer.SetCell(row, col, MapCellType.Slippery);
                }
            }
        }

        private static void SetWallBorder(this MapLayer mapLayer)
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
