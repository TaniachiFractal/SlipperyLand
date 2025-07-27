using GameTypes.Cells;

namespace CellTypes.Layers
{
    /// <summary>
    /// The character layer
    /// </summary>
    internal class CharacterLayer : BasicLayer<CharacterCells>
    {
        /// <inheritdoc/>
        public CharacterLayer(int rows, int cols) : base(rows, cols)
        {
        }
    }
}
