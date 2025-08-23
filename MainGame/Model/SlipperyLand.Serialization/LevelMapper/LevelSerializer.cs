using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using SlipperyLand.GameTypes;
using SlipperyLand.Serialization.LevelMapper.SerializableTypes;

namespace SlipperyLand.Serialization.LevelMapper
{
    /// <summary>
    /// Serialization and Deserialization of <see cref="Level"/>
    /// </summary>
    public static class LevelSerializer
    {
        /// <summary>
        /// Serialize a <see cref="Level"/> to an XML string
        /// </summary>
        public static string Serialize(this Level level)
        {
            var serializer = new XmlSerializer(typeof(LevelDto));
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);
            var settings = new XmlWriterSettings()
            {
                Indent = true,
                OmitXmlDeclaration = true,
            };
            using var strWriter = new StringWriter();
            using var xmlWriter = XmlWriter.Create(strWriter, settings);
            var levelDto = level.ConvertToDto();
            serializer.Serialize(xmlWriter, levelDto, namespaces);
            var output = strWriter.ToString();
            return output;
        }

        /// <summary>
        /// Deserialize an XML string to a <see cref="Level"/>
        /// </summary>
        public static Level Deserialize(string input)
        {
            var deserializer = new XmlSerializer(typeof(LevelDto));
            using var reader = new StringReader(input);
            var levelDto = deserializer.Deserialize(reader) as LevelDto;
            return levelDto.ConvertToNormal();
        }
    }
}
