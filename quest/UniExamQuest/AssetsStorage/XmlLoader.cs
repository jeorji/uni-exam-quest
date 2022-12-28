using System.Xml.Serialization;

namespace UniExamQuest
{
    class XmlLoader : ILoader
    {
        public string FileExtension { get; } = ".xml";

        public string Serialize<T>(T value)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            StringWriter textWriter = new StringWriter();
            xmlSerializer.Serialize(textWriter, value);

            return textWriter.ToString();
        }

        public T Deserialize<T>(string sourceData)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            TextReader reader = new StringReader(sourceData);

            T? result = (T?)xmlSerializer.Deserialize(reader);
            if (result is null)
                throw new NotImplementedException();

            return result;
        }
    }
}
