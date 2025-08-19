using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using SlipperyLand.GameTypes.Cells.Map;
using SlipperyLand.LevelMapper.Serialization.Helpers;
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
                var strRows = input.Split([StrEnd], StringSplitOptions.RemoveEmptyEntries);
                for (var row = 0; row < strRows.Length; row++)
                {
                    var strRow = strRows[row];
                    if (strRow.Count() > 0)
                    {
                        var mapRow = strRow.StrRowToMapRow();
                        for (var col = 0; col < mapRow.Length; col++)
                        {
                            mapGrid.Array ??= new MapCell[strRows.Length, mapRow.Length];
                            mapGrid.Array[row, col] = mapRow[col];
                        }
                    }
                }
            }
            else
            {
                throw new XmlException();
            }
        }

        private static MapCell[] StrRowToMapRow(this string str)
        {
            var blocks = str.Split(BlockEnd);
            var mapRow = new List<MapCell>();
            foreach (var block in blocks)
            {
                if (block.Count() > 0)
                {
                    mapRow.Add(block.ToMapCell());
                }
            }
            return [.. mapRow];
        }

        private static MapCell ToMapCell(this string block)
        {
            var nums = block.Split(Divider);
            if (!nums[0].TryFromBase36(out int num0))
            {
                throw new XmlException();
            }
            if (!nums[1].TryFromBase36(out int num1))
            {
                throw new XmlException();
            }
            return new() { mapCellType = (MapCellType)num0, mapCellLookId = num1 };
        }
    }
}
