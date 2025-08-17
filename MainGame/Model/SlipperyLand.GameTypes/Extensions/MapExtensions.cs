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

    }
}
