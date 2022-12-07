namespace UniExamQuest
{
    interface IStoreBuyer
    {
        double Money { get; set; }
        void BuyItem(Item item);
    }

    class Store
    {
        public List<Item> Items;
        
        public Store()
        {
            Items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (Items != null)
            {
                Items.Add(item);
            }
        }

        public List<Item> GetItems()
        {
            return Items.OrderBy(i => i.Price).ToList();
        }
    }
}
