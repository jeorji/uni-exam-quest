namespace UniExamQuest
{
    [Serializable]
    public abstract class Activity
    {
        public string Name { get; set; }

        public int Health { get; set; }
        public int Satiation { get; set; }
        public int Happiness { get; set; }
        public int Mind { get; set; }

        protected Activity(string name)
        {
            Name = name;
        }
    }
}
