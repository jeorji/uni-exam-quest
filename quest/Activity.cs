namespace UniExamQuest
{
    abstract class Activity
    {
        public string Name { get; set; }
        public Dictionary<Student.Properties, int> Impact;

        protected Activity(string name)
        {
            Name = name;
            Impact = new Dictionary<Student.Properties, int>();
        }
    }
}
