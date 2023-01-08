using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Serialization.Formatters.Binary;

namespace UniExamQuest
{
    public class BinLoader : ILoader
    {
        public string FileExtension { get; } = ".bin";
        public string Serialize<T>(T value)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, value);
                string binaryString = Convert.ToBase64String(stream.ToArray());
                return binaryString;
            }
        }
        public T Deserialize<T>(string sourceData)
        {
            byte[] bytes = Convert.FromBase64String(sourceData);

            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                T result = (T)formatter.Deserialize(stream);
                return result;
            }
        }

    }
}
