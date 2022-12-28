using System;

namespace UniExamQuest
{
    public interface IPlayer              
    {
        int Health { get; set; }
        int Satiation { get; set; }
        int Happiness { get; set; }
        int Mind { get; set; }
        bool IsAlive { get; set; }
        void GetStipend();
    }

    public class GameState
    {
        public IPlayer Player { get; set; }
        public GameSettings Settings { get; set; }

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

            try
            {
                if (Player.Happiness + Settings.DailyHappinesChange >= 0)   
                {
                    Player.Happiness += Settings.DailyHappinesChange;
                }
                if (Player.Satiation + Settings.DailySatiationChange >= 0)
                {
                    Player.Satiation += Settings.DailySatiationChange;
                }
                if (Player.Mind + Settings.DailyMindChange >= 0)
                {
                    Player.Mind += Settings.DailyMindChange;
                }
                if (Player.Health + getDailyHealthChange() >= 0)
                {
                    Player.Health += getDailyHealthChange();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        private bool isStipendDay()
        {
            isNotNull();
            return Day % Settings.StipendPayoutFrequency == 0;
        }

        private int getDailyHealthChange()
        {
            isNotNull();
            return Player.Satiation == 0 ? 2 * Settings.DailyHealthChange : Settings.DailyHealthChange;
        }

        private void isNotNull()
        {
            if (Settings is null)
                throw new Exception("Settings: null");   
            
            if (Player is null)
                throw new Exception("Player: null");      
        }
    }
}