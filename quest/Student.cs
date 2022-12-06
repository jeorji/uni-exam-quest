namespace UniExamQuest
{
    class Student
    {
        public enum Properties {
            Health,
            Money,
            Satiation,
            Happiness,
            Mind,
        }
        public Dictionary<Properties, int> PropertyValues;
        public string Name { get; set; }
        public bool IsStudy { get; set; }
        public bool IsSick { get; set; }
        public int StipendSize { get; set; }
        public int Day { get; set; }

        public Student(string name)
        {
            Name = name;
            PropertyValues = new Dictionary<Properties, int>();
        }
        public void FallSick()
        {
            IsSick = true;
        }
        public void Recover()
        {
            IsSick = false;
        }
        public void GetStipend()
        {
            if (IsStudy)
                PropertyValues[Properties.Money] += StipendSize;
        }
    }
}
