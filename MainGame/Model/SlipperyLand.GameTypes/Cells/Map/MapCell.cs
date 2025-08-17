using System.Diagnostics;

namespace SlipperyLand.GameTypes.Cells.Map
{
    /// <summary>
    /// A map cell
    /// </summary>
    [DebuggerDisplay("[{mapCellType};{mapCellLookId}]")]
    public class MapCell
    {
        /// <summary>
        /// The type of the cell
        /// </summary>
        public MapCellType mapCellType;

        /// <summary>
        /// The additional ID for cells with multiple visual styles
        /// </summary>
        public int mapCellLookId;

    }
}
