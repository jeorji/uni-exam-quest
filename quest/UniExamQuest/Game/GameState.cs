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

    class GameState
    {
        public IPlayer? Player { get; set; }
        public GameSettings? Settings { get; set; }

        public int Day { get; set; }

        public void NextDay()
        {
            isNotNull();

            doDailyPlayerUpdate();
            Day++;
        }

        private void doDailyPlayerUpdate()
        {
            isNotNull();

            if (isStipendDay())
                Player.GetStipend();

            Player.Health += getDailyHealthChange();
            Player.Satiation += Settings.DailySatiationChange;
            Player.Happiness += Settings.DailyHappinesChange;
            Player.Mind += Settings.DailyMindChange;
        }

        private bool isStipendDay()
        {
            isNotNull();
            return Day % Settings.StipendPayoutFrequency == 0;
        }

        private int getDailyHealthChange()
        {
            isNotNull();

            return Player.Satiation switch
            {
                0 => 2 * Settings.DailyHealthChange,
                _ => Settings.DailyHealthChange,
            };
        }

        private void isNotNull()
        {
            if (Settings is null)
                throw new NotImplementedException();
            if (Player is null)
                throw new NotImplementedException();
        }
    }
}
