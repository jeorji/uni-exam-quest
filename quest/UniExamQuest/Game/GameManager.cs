using System;

namespace UniExamQuest
{

    public class GameMananger
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
        }

        public void SaveGame(string gameName)
        {
            var AL = new AssetsStorage(new BinLoader());
            AL.SaveToFile<GameState>(State, $"./GameSaves/{gameName}.bin");
        }

        public void LoadGame(string gameName)
        {
            try
            {
                Storage.LoadFromFile<GameState>($"./GameSaves/{gameName}.bin");
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
