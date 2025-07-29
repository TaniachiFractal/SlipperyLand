using GameTypes.Cells;
using GameTypes.Layers;

namespace GameTypes.Extensions
{
    /// <summary>
    /// Extensions for  <see cref="MapLayer"/>
    /// </summary>
    public static class MapExtensions
    {
        /// <summary>
        /// Set a cell on a map
        /// </summary>
        public static void SetCell(this MapLayer map, int row, int col, MapCellType cell)
            => map.Grid[row, col] = cell;

        /// <summary>
        /// Read a cell on the map
        /// </summary>
        public static MapCellType ReadCell(this MapLayer map, int row, int col)
            => map.Grid[row, col];
    }
}
