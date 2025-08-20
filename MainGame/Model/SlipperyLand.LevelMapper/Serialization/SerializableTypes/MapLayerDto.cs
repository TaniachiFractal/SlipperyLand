using SlipperyLand.GameTypes.Layers;

namespace SlipperyLand.LevelMapper.Serialization.SerializableTypes
{
    /// <summary>
    /// A <see cref="MapLayer"/> data transfer object 
    /// </summary>
    public class MapLayerDto
    {
        /// <summary>
        /// The cell grid of the layer
        /// </summary>
        public MapGrid Grid;

        /// <summary>
        /// Empty grid constructor
        /// </summary>
        /// <param name="cols">Grid Cols</param>
        /// <param name="rows">Grid Rows</param>
        public MapLayerDto(int rows, int cols)
        {
            Grid = new(rows, cols);
        }

        /// <summary>
        /// Base ctor
        /// </summary>
        public MapLayerDto()
        { }

    }
}
