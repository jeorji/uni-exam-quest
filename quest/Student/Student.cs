namespace UniExamQuest
{
    interface IStudent : IStoreBuyer, IActivityConsumer, IGamePlayer { }

    class Student : IStudent
    {
        public int Health { get; set; }
        public int Satiation { get; set; }
        public int Happiness { get; set; }
        public int Mind { get; set; }

        public Inventory Inventory { get; set; }
        public string Name { get; set; }
        public bool IsStudy { get; set; }
        public bool IsSick { get; set; }
        public int StipendSize { get; set; }
        public decimal Money { get; set; }

        public Student(string name)
        {
            IsAlive = true;
            Name = name;
            Inventory = new Inventory();
        }
        public void GetStipend()
        {
            if (IsStudy)
                Money += StipendSize;
        }

        public void BuyItem(Item item)
        {
            if (Money < item.Price)
                throw new NotImplementedException();

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
