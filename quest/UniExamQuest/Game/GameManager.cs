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
            try                                               
            {
                State.Settings = loadFromCurrentDir<GameSettings>("settings.xml");
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }       
        }

        public void SaveGame(string gameName)
        {
            Storage.SaveToFile<GameState>(State, $"./GameSaves/{gameName}.xml");
        }

        public void LoadGame(string gameName)         // *** new ->
        {
            try
            {
                Storage.LoadFromFile<GameState>($"./GameSaves/{gameName}.xml");
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }  // *** <-
        }

        private T loadFromCurrentDir<T>(string fileName)
        {
            var path = $"./{fileName}";
            return Storage.LoadFromFile<T>(path);
        }
    }
}
