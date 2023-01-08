using System;

namespace UniExamQuest
{
    public interface IActivityConsumer
    {
        void InteractWith(Activity activity);
    }
    public interface IStoreBuyer
    {
        decimal Money { get; set; }
        void BuyItem(Item item);
    }
    public interface IPlayer : IStoreBuyer, IActivityConsumer
    {
        string Name { get; set; }
        int Health { get; set; }
        int Satiation { get; set; }
        int Happiness { get; set; }
        int Mind { get; set; }
        Inventory Inventory { get; set; }
        bool IsAlive { get; }
        void GetStipend();
    }

    [Serializable]
    public class GameState
    {
        public IPlayer Player { get; set; }
        public GameSettings Settings { get; set; }
        public Store Storage { get; set; }
        public List<Quest> Quests { get; set; }

        public int Day { get; set; }

        public void SetStartValues()
        {
            isNotNull();
            // put in settings
            Player.Health = 100;
            Player.Happiness = 50;
            Player.Satiation = 100;
            Player.Mind = 0;
            Day = 0;
        }

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
                Player.Happiness += Settings.DailyHappinesChange;
                Player.Satiation += Settings.DailySatiationChange;
                Player.Mind += Settings.DailyMindChange;
                Player.Health += getDailyHealthChange();
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