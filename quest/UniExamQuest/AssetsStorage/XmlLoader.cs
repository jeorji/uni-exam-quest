using System;
using System.Xml.Serialization;
using System.IO;

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
            if (sourceData == null)                                    
            {
                throw new NotImplementedException("The string for deserialization is null");
            }
            TextReader reader = new StringReader(sourceData);

            try
            {
                T result = (T)xmlSerializer.Deserialize(reader);
                if (result == null)
                    throw new NotImplementedException("The result of deserialization is null"); 
                return result;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Cannot deserialize: " + sourceData);
            }

        }
    }
}
