using System.IO;
using System.Xml.Serialization;
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
        /// Serialize a <see cref="MapLayer"/> to an XML string
        /// </summary>
        public static string Serialize(this MapLayer mapLayer)
        {
            var serializer = new XmlSerializer(typeof(MapLayerDto));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            using var writer = new StringWriter();
            var mapDto = mapLayer.ConvertToDto();
            serializer.Serialize(writer, mapDto, namespaces);
            var output = writer.ToString();
            return output;
        }

        /// <summary>
        /// Deserialize an XML string to a <see cref="MapLayer"/>
        /// </summary>
        public static MapLayer Deserialize(string input)
        {
            var deserializer = new XmlSerializer(typeof(MapLayerDto));
            using var reader = new StringReader(input);
            var mapDto = deserializer.Deserialize(reader) as MapLayerDto;
            return mapDto.ConvertToNormal();
        }
    }
}
