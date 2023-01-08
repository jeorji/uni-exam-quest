namespace UniExamQuest
{
    [Serializable]
    public class Quest : Activity
    {
        public enum QuestType
        {
            UNIVERSITY,
            WORK,
            REST,
        }
        public QuestType Type { get; set; }
        public decimal Money { get; set; }
        public Quest(string name, QuestType qtype) : base(name)
        {
            Type = qtype;
        }

        // need for xmlSerializer
        private Quest() : base("") {}
    }
}
