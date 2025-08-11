using System.Diagnostics;
using System.Text;
using SlipperyLand.GameTypes.Cells.Map;

namespace SlipperyLand.GameTypes.Layers
{
    /// <summary>
    /// The map layer
    /// </summary>
    [DebuggerDisplay("{String}")]
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

        private MapCell[,] grid;
        /// <summary>
        /// The cell grid of the layer
        /// </summary>
        public MapCell[,] Grid
        {
            get => grid;
            set => grid = value;
        }

        /// <summary>
        /// Empty grid constructor
        /// </summary>
        /// <param name="cols">Grid Cols</param>
        /// <param name="rows">Grid Rows</param>
        public MapLayer(int rows, int cols)
        {
            Cols = cols;
            Rows = rows;

            grid = new MapCell[rows, cols];
        }

        private string String => ToString();

        /// <inheritdoc/>
        public override string ToString()
        {
            var output = new StringBuilder();
            for (var row = 0; row < Rows; row++)
            {
                for (var col = 0; col < Cols; col++)
                {
                    output.Append(Grid[row, col].mapCellType.ToString().Substring(0, 1));
                }
                output.AppendLine();
            }
            return output.ToString();
        }
    }
}
