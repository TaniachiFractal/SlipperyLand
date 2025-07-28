using GameTypes.Cells;

namespace GameTypes.Layers
{
    /// <summary>
    /// The map layer
    /// </summary>
    public class MapLayer : BasicLayer<MapCellType>
    {
        /// <inheritdoc/>
        public MapLayer(int rows, int cols) : base(rows, cols)
        {
        }

        /// <summary>
        /// Fill the entire map with slippery tiles
        /// </summary>
        public void FillWithSlippery()
        {
            for (var row = 0; row < Rows; row++)
            {
                for (var col = 0; col < Cols; col++)
                {
                    SetCell(row, col, MapCellType.Slippery);
                }
            }
        }
    }
}
