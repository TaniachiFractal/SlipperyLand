using System.Xml.Serialization;
using SlipperyLand.GameTypes.Layers;

namespace SlipperyLand.LevelMapper.Serialization.SerializableTypes
{
    /// <summary>
    /// A <see cref="MapLayer"/> data transfer object that implements <see cref="IXmlSerializable"/>
    /// </summary>
    public class SerializableMapLayerDto //: IXmlSerializable
    {
        /// <summary>
        /// Col count of the grid
        /// </summary>
        public int Cols;
        /// <summary>
        /// Row count of the grid
        /// </summary>
        public int Rows;

        /// <summary>
        /// The cell grid of the layer
        /// </summary>
        public SerializableMapGrid SerialGrid;

        /// <summary>
        /// Empty grid constructor
        /// </summary>
        /// <param name="cols">Grid Cols</param>
        /// <param name="rows">Grid Rows</param>
        public SerializableMapLayerDto(int rows, int cols)
        {
            Cols = cols;
            Rows = rows;

            SerialGrid = new(rows, cols);
        }

        /// <summary>
        /// Base ctor
        /// </summary>
        public SerializableMapLayerDto()
        { }

    }
}
