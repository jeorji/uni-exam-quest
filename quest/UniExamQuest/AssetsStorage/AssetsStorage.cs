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
                throw new NotImplementedException("File not found");         
            if (System.IO.Path.GetExtension(path) != Loader.FileExtension)
                throw new NotImplementedException("File has another extension");   

            

            try
            {
                string text = System.IO.File.ReadAllText(path);
                try
                {
                    return Loader.Deserialize<T>(text);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("Error when reading the file");
            }
            

        }

        public void SaveToFile<T>(T value, string path)
        {
            string data = Loader.Serialize<T>(value);
            try   
            {
                using (StreamWriter writer = new StreamWriter(path))
                    writer.WriteLine(data);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }        
        }
    }
}
