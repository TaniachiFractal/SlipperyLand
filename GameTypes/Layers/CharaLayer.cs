using GameTypes.Cells;

namespace GameTypes.Layers
{
    /// <summary>
    /// The character layer
    /// </summary>
    public class CharaLayer : BasicLayer<CharaCellGroup>
    {
        /// <inheritdoc/>
        public CharaLayer(int rows, int cols) : base(rows, cols)
        {
        }
    }
}
