namespace UniExamQuest
{
    public class Inventory
    {
        public Dictionary<Item, int> Content;

        public Inventory()
        {
            Content = new Dictionary<Item, int>();
        }

        public void Add(Item newItem)
        {
            Content.Add(newItem, 1);
        }
    }
}
