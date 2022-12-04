namespace UniExamQuest
{
    class Properties
    {
        public int Health { get; set; }
        public int Satiation { get; set; }
        public int Money { get; set; }
        public int Mind { get; set; }
        public int Happiness { get; set; }

        public Properties()
        {
            
        }

        public void SetDefault()
        {
            Satiation = 100;
            Health = 100;
            Money = 0;
            Mind = 100;
            Happiness = 100;
        }
    }
}

