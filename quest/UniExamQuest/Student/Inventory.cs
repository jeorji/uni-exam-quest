namespace UniExamQuest
{
    [Serializable]
    public class Inventory
    {
        public Dictionary<Item, int> Content;

        public Inventory()
        {
            Content = new Dictionary<Item, int>();
        }
        public void Add(Item newItem)
        {
            if (Content.ContainsKey(newItem))
                Content[newItem] += 1;
            else
                Content.Add(newItem, 1);
        }
        public void Remove(Item newItem)
        {
            if (!Content.ContainsKey(newItem))
                throw new Exception();

            if (Content[newItem] > 1)
                Content[newItem] -= 1;
            else
                Content.Remove(newItem);
        }
    }
}
