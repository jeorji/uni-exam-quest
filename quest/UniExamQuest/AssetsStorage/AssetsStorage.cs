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
                throw new NotImplementedException();
            if (System.IO.Path.GetExtension(path) != Loader.FileExtension)
                throw new NotImplementedException();

            string text = System.IO.File.ReadAllText(path);

            return Loader.Deserialize<T>(text);
        }

        public void SaveToFile<T>(T value, string path)
        {
            string data = Loader.Serialize<T>(value);
            using (StreamWriter writer = new StreamWriter(path))
                writer.WriteLine(data);
        }
    }
}
