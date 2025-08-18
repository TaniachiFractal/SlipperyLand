using System.Linq;
using System.Xml;
using SlipperyLand.LevelMapper.Serialization.SerializableTypes;

namespace SlipperyLand.LevelMapper.Serialization.Helpers
{
    /// <summary>
    /// Serialization helper for <see cref="MapGrid"/>
    /// </summary>
    public static class MapGridSerializationHelper
    {
        private const char StrEnd = '%';
        private const char BlockEnd = '|';
        private const char Divider = ';';
        private const char NewLine = '\n';

        /// <summary>
        /// Implementation of <see cref="MapGrid.WriteXml(XmlWriter)"/>
        /// </summary>
        public static void WriteXmlData(this MapGrid mapGrid, XmlWriter writer)
        {
            writer.WriteString("\n");
            for (var row = 0; row < mapGrid.Rows; row++)
            {
                var str = "";
                for (var col = 0; col < mapGrid.Cols; col++)
                {
                    var cell = mapGrid.Array[row, col];
                    var cellType = (int)cell.mapCellType;
                    var cellLook = cell.mapCellLookId;
                    str += $"{cellType:D2}" + Divider + $"{cellLook:D2}" + BlockEnd;
                }
                writer.WriteString(str + StrEnd + NewLine);
            }
        }

        /// <summary>
        /// Implementation of <see cref="MapGrid.ReadXml(XmlReader)"/>
        /// </summary>
        public static void ReadXmlData(this MapGrid mapGrid, XmlReader reader)
        {
            var input = reader.ReadContentAsString();
            if (input.Count() > 0)
            {
                var inputIter = 0;
                while (inputIter < input.Count())
                {
                    var readSymbol = input[0];
                    while (readSymbol != StrEnd)
                    {
                        while (readSymbol != BlockEnd)
                        {
                            readSymbol = input[inputIter++];
                            if (readSymbol == NewLine)
                            {
                                continue;
                            }
                        }
                    }
                }
            }
            else
            {
                throw new XmlException();
            }
        }
    }
}
