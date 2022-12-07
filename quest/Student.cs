namespace UniExamQuest
{
    interface IStudent : IStoreBuyer, IActivityConsumer {}

    class Student : IStudent
    {
        public enum Properties
        {
            Health,
            Satiation,
            Happiness,
            Mind,
        }
        public Dictionary<Properties, int> PropertyValues;
        public Inventory Inventory;
        public string Name { get; set; }
        public bool IsStudy { get; set; }
        public bool IsSick { get; set; }
        public int StipendSize { get; set; }
        public int Day { get; set; }
        public double Money { get; set; }

        public Student(string name)
        {
            Name = name;
            Inventory = new Inventory();
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
                Money += StipendSize;
        }

        public void BuyItem(Item item)
        {
            if (Money < item.Price)
                return;

            Money -= item.Price;
            Inventory.Add(item);
        }

        public void InteractWith(Activity activity)
        {
            foreach (var impactPair in activity.Impact)
                PropertyValues[impactPair.Key] += impactPair.Value;
        }
    }
}
