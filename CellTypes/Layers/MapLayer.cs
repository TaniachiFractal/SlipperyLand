using System.Text;
using GameTypes.Cells;

namespace CellTypes.Layers
{
    /// <summary>
    /// The map layer
    /// </summary>
    public class MapLayer : BasicLayer<MapCells>
    {
        /// <inheritdoc/>
        public MapLayer(int rows, int cols) : base(rows, cols)
        {
        }
    }
}
