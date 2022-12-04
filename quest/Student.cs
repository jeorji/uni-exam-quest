namespace UniExamQuest
{
    class Student
    {
        public Properties? Prop;
        public bool IsStudy { get; set; }
        public bool IsSick { get; set; }
        public int StipendSize { get; set; }
        public Student()
        {
            StipendSize = 0;
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
            if (IsStudy && Prop is not null)
                Prop.Money += StipendSize;  
        }
    }
}
