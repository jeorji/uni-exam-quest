namespace UniExamQuest
{

    class GameMananger
    {
        public GameState State { get; set; }

        private AssetsStorage Storage { get; set; }

        public GameMananger()
        {
            State = new GameState();
            Storage = new AssetsStorage(new XmlLoader());
        }

        public void NewGame(string playerName)
        {
            State.Player = new Student(playerName);
            State.Settings = loadFromCurrentDir<GameSettings>("settings.xml");
        }

        public void SaveGame(string gameName)
        {
            Storage.SaveToFile<GameState>(State, $"./GameSaves/{gameName}.xml");
        }

        public void LoadGame(string gameName)
        {
            Storage.LoadFromFile<GameState>($"./GameSaves/{gameName}.xml");
        }

        private T loadFromCurrentDir<T>(string fileName)
        {
            var path = $"./{fileName}";
            return Storage.LoadFromFile<T>(path);
        }
    }
}
