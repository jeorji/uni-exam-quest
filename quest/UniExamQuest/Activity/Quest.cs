namespace UniExamQuest
{
    public class Quest : Activity
    {
        public enum QuestType
        {
            UNIVERSIRTY,
            WORK,
            REST,
        }
        public QuestType Type { get; set; }

        public Quest(string name, QuestType qtype) : base(name)
        {
            Type = qtype;
        }

        // need for xmlSerializer
        private Quest() : base("") {}
    }
}
