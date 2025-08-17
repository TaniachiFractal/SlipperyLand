using System.IO;
using System.Text;
using System.Xml.Serialization;
using SlipperyLand.GameTypes.Cells.Map;
using SlipperyLand.GameTypes.Extensions;
using SlipperyLand.GameTypes.Layers;
using SlipperyLand.LevelMapper.Serialization.SerializableTypes;

namespace SlipperyLand.LevelMapper.Serialization
{
    /// <summary>
    /// Serialization and Deserialization of <see cref="MapLayer"/>
    /// </summary>
    public static class MapSerializer
    {
        /// <summary>
        /// Serialize a <see cref="MapLayer"/> to a xml string
        /// </summary>
        public static string Serialize(this MapLayer mapLayer)
        {
            var serializer = new XmlSerializer(typeof(SerializableMapLayerDto));
            using var writer = new StringWriter();
            var mapDto = mapLayer.ConvertToDto();
            serializer.Serialize(writer, mapDto);
            var output = writer.ToString();
            return output;
        }
    }
}
