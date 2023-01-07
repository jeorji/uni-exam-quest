using System;
using System.Xml.Serialization;
using System.IO;

namespace UniExamQuest
{
    public class XmlLoader : ILoader
    {
        public string FileExtension { get; } = ".xml";

        public string Serialize<T>(T value)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            StringWriter textWriter = new StringWriter();
            
            try
            { 
                xmlSerializer.Serialize(textWriter, value);
                return textWriter.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot serialize" + value);
            }
        }

        public T Deserialize<T>(string sourceData)
        {
            var xmlSerializer = new XmlSerializer(typeof(T));
            
            if (sourceData == null)                                    
            {
                throw new Exception("The string for deserialization is null");
            }
            
            TextReader reader = new StringReader(sourceData);

            try
            {
                T? result = (T?)xmlSerializer.Deserialize(reader);
                if (result == null)
                    throw new Exception("The result of deserialization is null"); 
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot deserialize: " + sourceData);
            }
        }
    }
}
