using SlipperyLand.GameTypes.Cells.Map;

namespace SlipperyLand.GameTypes.Layers
{
    /// <summary>
    /// The map layer
    /// </summary>
    public class MapLayer
    {
        /// <summary>
        /// Col count of the grid
        /// </summary>
        public readonly int Cols;
        /// <summary>
        /// Row count of the grid
        /// </summary>
        public readonly int Rows;

        /// <summary>
        /// The cell grid of the layer
        /// </summary>
        public MapCell[,] Grid;

        /// <summary>
        /// Empty grid constructor
        /// </summary>
        /// <param name="cols">Grid Cols</param>
        /// <param name="rows">Grid Rows</param>
        public MapLayer(int rows, int cols)
        {
            Cols = cols;
            Rows = rows;

            Grid = new MapCell[rows, cols];
        }
    }
}
