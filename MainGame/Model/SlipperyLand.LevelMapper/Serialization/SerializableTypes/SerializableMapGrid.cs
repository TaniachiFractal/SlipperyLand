using System;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using SlipperyLand.GameTypes.Cells.Map;

namespace SlipperyLand.LevelMapper.Serialization.SerializableTypes
{
    /// <summary>
    /// An xml serializable grid of <see cref="MapCell"/>
    /// </summary>
    public class SerializableMapGrid : IXmlSerializable
    {
        private readonly int rows;
        private readonly int cols;

        /// <summary>
        /// The array of <see cref="MapCell"/>
        /// </summary>
        public MapCell[,] Array;

        /// <summary>
        /// ctor
        /// </summary>
        public SerializableMapGrid(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            Array = new MapCell[rows, cols];
        }

        /// <summary>
        /// Basic ctor
        /// </summary>
        public SerializableMapGrid()
        { }

        /// <inheritdoc/>
        public XmlSchema GetSchema() => null;

        /// <inheritdoc/>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString("\n");
            for (var row = 0; row < rows; row++)
            {
                var str = "";
                for (var col = 0; col < cols; col++)
                {
                    var cell = Array[row, col];
                    var cellType = (int)cell.mapCellType;
                    var cellLook = cell.mapCellLookId;
                    str += $"[{cellType:D2};{cellLook:D2}]";
                }
                writer.WriteString(str + "\n");
            }
        }

        /// <inheritdoc/>
        public void ReadXml(XmlReader reader)
        {

        }

    }
}
