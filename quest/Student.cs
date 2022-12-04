namespace UniExamQuest
{
    class Student
    {
        public int Health { get; set; }
        public bool IsStudy { get; set; }
        public int Money { get; set; }
        public int Mind { get; set; }
        public int Happiness { get; set; }
        public bool IsSick { get; set; }
        public int StipendSize { get; set; }
        public Student()
        {
            Happiness = 100;
            Health = 100;
            Mind = 100;
            StipendSize = 0;
            Money = 0;
            IsStudy = false;
            IsSick = false;
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
            {
                Money += StipendSize;  
            }
        }
    }
}
