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
        /// Serialize a <see cref="MapLayer"/> to a xml string
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
    }
}
