using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using SlipperyLand.GameTypes.Cells.Map;
using SlipperyLand.LevelMapper.Res;
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
                    str += $"{cellType.ToBase36()}" + Divider + $"{cellLook.ToBase36()}" + BlockEnd;
                }
                writer.WriteString(str + StrEnd + NewLine);
            }
        }

        /// <summary>
        /// Implementation of <see cref="MapGrid.ReadXml(XmlReader)"/>
        /// </summary>
        /// <exception cref="InvalidOperationException">Failed to deserialize data</exception>
        public static void ReadXmlData(this MapGrid mapGrid, XmlReader reader)
        {
            var input = string.Empty;
            if (reader.NodeType == XmlNodeType.Element)
            {
                input = reader.ReadElementContentAsString();
            }
            if (input.Count() > 0)
            {
                input = input.Replace("\n", "");
                input = input.Replace(" ", "");
                input = input.Replace("\t", "");
                var strRows = input.Split([StrEnd], StringSplitOptions.RemoveEmptyEntries);
                var rowCou = strRows.Length;
                var colCou = strRows[0].StrRowToMapRow(0).Length;
                mapGrid.Array = new MapCell[rowCou, colCou];
                for (var row = 0; row < strRows.Length; row++)
                {
                    var strRow = strRows[row];
                    if (strRow.Count() > 0)
                    {
                        var mapRow = strRow.StrRowToMapRow(row);
                        if (mapRow.Length != colCou)
                        {
                            throw new ArgumentOutOfRangeException(reader.Name);
                        }
                        for (var col = 0; col < mapRow.Length; col++)
                        {
                            mapGrid.Array[row, col] = mapRow[col];
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentNullException(reader.Name);
            }
        }

        private static MapCell[] StrRowToMapRow(this string str, int row)
        {
            var blocks = str.Split(BlockEnd);
            var mapRow = new List<MapCell>();
            for (var col = 0; col < blocks.Length; col++)
            {
                var block = blocks[col];
                if (block.Count() > 0)
                {
                    mapRow.Add(block.ToMapCell(row, col));
                }
            }
            return [.. mapRow];
        }

        private static MapCell ToMapCell(this string block, int row, int col)
        {
            void throwEx() => throw new FormatException(string.Format(ErrorText.InvalidCellBlock, row, col));

            var nums = block.Split(Divider);
            if (!nums[0].TryFromBase36(out int num0))
            {
                throwEx();
            }
            if (!nums[1].TryFromBase36(out int num1))
            {
                throwEx();
            }
            return new() { mapCellType = (MapCellType)num0, mapCellLookId = num1 };
        }
    }
}
