using System;
using System.Diagnostics;
using System.Text;

namespace CellTypes.Layers
{
    /// <summary>
    /// Template for a layer class
    /// </summary>
    /// <typeparam name="TCells">Possible cell types</typeparam>
    [DebuggerDisplay("{AsText}")]
    public abstract class BasicLayer<TCells>
    where TCells : Enum
    {
        /// <summary>
        /// Col count of the grid
        /// </summary>
        public readonly int Cols;
        /// <summary>
        /// Row count of the grid
        /// </summary>
        public readonly int Rows;

        private TCells[,] grid;
        /// <summary>
        /// The cell grid of the layer
        /// </summary>
        public TCells[,] Grid
        {
            get => grid;
            private set => grid = value;
        }

        /// <summary>
        /// Represent the layer as a char grid
        /// </summary>
        public string AsText => ToText();

        /// <summary>
        /// Empty grid constructor
        /// </summary>
        /// <param name="cols">Grid Cols</param>
        /// <param name="rows">Grid Rows</param>
        public BasicLayer(int rows, int cols)
        {
            Cols = cols;
            Rows = rows;

            grid = new TCells[rows, cols];
        }

        /// <summary>
        /// Convert grid to text
        /// </summary>
        private string ToText()
        {
            var output = new StringBuilder();

            for (var row = 0; row < Rows; row++)
            {
                for (var col = 0; col < Cols; col++)
                {
                    output.Append(ReadCell(row, col).ToString()[0]);
                }
                output.Append('\n');
            }

            return output.ToString();
        }

        /// <summary>
        /// Set a new grid
        /// </summary>
        public void SetGrid(TCells[,] newGrid)
        {
            Grid = newGrid;
        }

        /// <summary>
        /// Set a new value to a specific cell
        /// </summary>
        /// <param name="row">Row of the cell</param>
        /// <param name="col">Col of the cell</param>
        /// <param name="cellType">New cell value</param>
        public void SetCell(int row, int col, TCells cellType)
        {
            Grid[row, col] = cellType;
        }

        /// <param name="row">Row of the cell</param>
        /// <param name="col">Col of the cell</param>
        /// <returns>Cell value</returns>
        public TCells ReadCell(int row, int col) => grid[row, col];

    }
}
