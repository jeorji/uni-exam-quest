namespace UniExamQuest
{
    interface IPlayer
    {
        int Health { get; set; }
        int Satiation { get; set; }
        int Happiness { get; set; }
        int Mind { get; set; }
        bool IsAlive { get; set; }
        void GetStipend();
    }

    class GameMananger
    {
        public int Day { get; set; }
        public GameSettings? Settings { get; set; }
        public IPlayer Player { get; set; }

        public GameMananger(IPlayer player)
        {
            Player = player;
        }

        public void InitGame()
        {
            Settings = loadSettingsFromDefaultPath();
        }

        public void NextDay()
        {
            doDailyPlayerUpdate();
            Day++;
        }

        private void doDailyPlayerUpdate()
        {
            if (Settings is null)
                throw new NotImplementedException();

            if (isStipendDay())
                Player.GetStipend();

            Player.Health += getDailyHealthChange();
            Player.Satiation += Settings.DailySatiationChange;
            Player.Happiness += Settings.DailyHappinesChange;
            Player.Mind += Settings.DailyMindChange;
        }

        private bool isStipendDay()
        {
            if (Settings is null)
                throw new NotImplementedException();

            return Day % Settings.StipendPayoutFrequency == 0;
        }

        private int getDailyHealthChange()
        {
            if (Settings is null)
                throw new NotImplementedException();

            return Player.Satiation switch
            {
                0 => 2 * Settings.DailyHealthChange,
                _ => Settings.DailyHealthChange,
            };
        }

        private GameSettings loadSettingsFromDefaultPath()
        {
            var defaultPath = "./settgins.xml";
            var AS = new AssetsStorage(new XmlLoader());
            return AS.LoadFromFile<GameSettings>(defaultPath);
        }
    }
}
