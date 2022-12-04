namespace UniExamQuest
{
    class Item
    {
        public Properties? Prop;
        public double Price { get; set; }
        public string Name { get; set; }
        public Item(double price, string name)
        {
            Price = price;
            Name = name;
            Prop = new Properties();
        }

        public override string ToString()
        {
            return $"{Name}: {Price}";
        }
    }
}
