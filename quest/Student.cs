namespace UniExamQuest
{
    class Student
    {
        public Properties? Prop;
        public string Name { get; set; }
        public bool IsStudy { get; set; }
        public bool IsSick { get; set; }
        public int StipendSize { get; set; }
        public int Day { get; set; }
        public Student(string name)
        {
            Name = name;
            Prop = new Properties();
            Prop.SetDefault();
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
