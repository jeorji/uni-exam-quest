namespace UniExamQuest
{
    interface IStudent : IStoreBuyer, IActivityConsumer {}

    class Student : IStudent
    {
        public int Health { get; set; }
        public int Satiation { get; set; }
        public int Happiness { get; set; }
        public int Mind { get; set; }

        public Inventory Inventory;
        public string Name { get; set; }
        public bool IsStudy { get; set; }
        public bool IsSick { get; set; }
        public int StipendSize { get; set; }
        public int Day { get; set; }
        public decimal Money { get; set; }

        public Student(string name)
        {
            Name = name;
            Inventory = new Inventory();
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
            Happiness += activity.Happiness;
            Satiation += activity.Satiation;
            Mind += activity.Mind;
            Health += activity.Health;
        }
    }
}
