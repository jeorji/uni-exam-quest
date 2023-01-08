namespace UniExamQuest
{
    [Serializable]
    public class Item : Activity
    {
        public decimal Price { get; set; }

        public Item(string name, decimal price) : base(name)
        {
            Price = price;
        }

        // need for xmlSerializer
        private Item() : base("") {}

        public override string ToString()
        {
            return $"{Name}: {Price}";
        }

    }
}
