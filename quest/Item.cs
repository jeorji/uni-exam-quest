namespace UniExamQuest
{
    class Item : Activity
    {
        public double Price { get; set; }

        public Item(string name, double price) : base(name)
        {
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name}: {Price}";
        }
    }
}
