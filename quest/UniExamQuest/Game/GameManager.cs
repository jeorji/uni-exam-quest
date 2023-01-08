using System;

namespace UniExamQuest
{

    public class GameMananger
    {
        public GameState State { get; set; }
        public string? LoadedGameName { get; set; }

        private AssetsStorage Storage { get; set; }

        public GameMananger()
        {
            State = new GameState();
            Storage = new AssetsStorage(new XmlLoader());
        }

        public void NewGame(string playerName)
        {
            State.Player = new Student(playerName);
            State.Storage = new Store();
            try                                               
            {
                State.Settings = loadFromCurrentDir<GameSettings>("settings.xml");
                State.Storage.Items = loadFromCurrentDir<List<Item>>("items.xml");
                State.Quests = loadFromCurrentDir<List<Quest>>("quests.xml");
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
            State.SetStartValues();
            LoadedGameName = null;
        }

        public void SaveGame(string gameName)
        {
            var AL = new AssetsStorage(new BinLoader());
            AL.SaveToFile<GameState>(State, $"./GameSaves/{gameName}.bin");
            LoadedGameName = gameName;
        }

        public void LoadGame(string gameName)
        {
            var AL = new AssetsStorage(new BinLoader());
            try
            {
                State = AL.LoadFromFile<GameState>($"./GameSaves/{gameName}.bin");
                LoadedGameName = gameName;
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private T loadFromCurrentDir<T>(string fileName)
        {
            var path = $"./{fileName}";
            return Storage.LoadFromFile<T>(path);
        }
    }
}
