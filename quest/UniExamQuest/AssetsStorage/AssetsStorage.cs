using System;
using System.IO;
using System.Runtime;

namespace UniExamQuest
{
    interface ILoader
    {
        string FileExtension { get; }
        string Serialize<T>(T value);
        T Deserialize<T>(string sourceData);
    }

    class AssetsStorage
    {
        public ILoader Loader { get; set; }

        public AssetsStorage(ILoader loader)
        {
            Loader = loader;
        }

        public T LoadFromFile<T>(string path)
        {
            if (!File.Exists(path))
                throw new Exception("File not found");
            
            if (Path.GetExtension(path) != Loader.FileExtension)
                throw new Exception("File has another extension");
            
            try
            {
                string text = File.ReadAllText(path);
                return Loader.Deserialize<T>(text);
            }
            
            catch (Exception ex)
            {
                throw new Exception("Error in file reading");
            }
            

        }

        public void SaveToFile<T>(T value, string path)
        {
            string data = Loader.Serialize(value);
            
            try   
            {
                using (StreamWriter writer = new StreamWriter(path)) 
                    writer.WriteLine(data);
            }
            
            catch (Exception ex)
            {
                throw new Exception("Error when saving to file");
            }
        }
    }
}
