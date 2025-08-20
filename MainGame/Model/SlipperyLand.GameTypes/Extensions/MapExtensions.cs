using SlipperyLand.Common.Extensions;
using SlipperyLand.GameTypes.Cells.Map;
using SlipperyLand.GameTypes.Layers;

namespace SlipperyLand.GameTypes.Extensions
{
    /// <summary>
    /// Extensions for  <see cref="MapLayer"/>
    /// </summary>
    public static class MapExtensions
    {
        private readonly static MapCell defCell = new();

        /// <summary>
        /// Set a cell on a map
        /// </summary>
        public static void SetCell(this MapLayer map, int row, int col, MapCell cell)
        {
            if (map.Grid.ItemOrDef(row, col, map.Rows, map.Cols, defCell) != defCell)
            {
                map.Grid[row, col] = cell;
            }
        }

        /// <summary>
        /// Set a cell with default looks for its type
        /// </summary>
        public static void SetCell(this MapLayer map, int row, int col, MapCellType cellType)
            => map.SetCell(row, col, new MapCell() { mapCellType = cellType });

        /// <summary>
        /// Set a cell with a specific look for its type
        /// </summary>
        public static void SetCell(this MapLayer map, int row, int col, MapCellType cellType, int lookId)
            => map.SetCell(row, col, new MapCell() { mapCellType = cellType, mapCellLookId = lookId });

        /// <summary>
        /// Read a cell on the map
        /// </summary>
        public static MapCell ReadCell(this MapLayer map, int row, int col)
            => map.Grid.ItemOrDef(row, col, map.Rows, map.Cols, defCell);

        /// <summary>
        /// Get the <see cref="MapCellType"/> on the pixel coordinate
        /// </summary>
        public static MapCellType GetCellTypeOnCoord(this MapLayer map, int X, int Y, int tileSize)
        {
            var col = X / tileSize;
            var row = Y / tileSize;

            return map.ReadCell(row, col).mapCellType;
        }

        private const int DefaultStartCoord = 1;
        /// <summary>
        /// Find the first start cell on the map or return the [1, 1] cell
        /// </summary>
        public static (int row, int col) FindStartCell(this MapLayer map)
        {
            for (var row = 0; row < map.Rows; row++)
            {
                for (var col = 0; col < map.Cols; col++)
                {
                    if (map.ReadCell(row, col).mapCellType == MapCellType.Start)
                    {
                        return (row, col);
                    }
                }
            }
            return (DefaultStartCoord, DefaultStartCoord);
        }
    }
}
