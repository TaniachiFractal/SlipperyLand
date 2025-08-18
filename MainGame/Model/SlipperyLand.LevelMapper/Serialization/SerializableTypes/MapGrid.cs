using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using SlipperyLand.GameTypes.Cells.Map;
using SlipperyLand.LevelMapper.Serialization.Helpers;

namespace SlipperyLand.LevelMapper.Serialization.SerializableTypes
{
    /// <summary>
    /// An XML serializable grid of <see cref="MapCell"/>
    /// </summary>
    public class MapGrid : IXmlSerializable
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
        /// The array of <see cref="MapCell"/>
        /// </summary>
        public MapCell[,] Array;

        /// <summary>
        /// ctor
        /// </summary>
        public MapGrid(int rows, int cols)
        {
            Rows = rows;
            Cols = cols;
            Array = new MapCell[rows, cols];
        }

        /// <summary>
        /// Basic ctor
        /// </summary>
        public MapGrid()
        { }

        /// <inheritdoc/>
        public XmlSchema GetSchema() => null;

        /// <inheritdoc/>
        public void WriteXml(XmlWriter writer)
        {
            this.WriteXmlData(writer);
        }

        /// <inheritdoc/>
        public void ReadXml(XmlReader reader)
        {
            this.ReadXmlData(reader);
        }

    }
}
