using System.Xml;

namespace UniExamQuest
{
    class Item : Activity, IDeserializable<Item>
    {
        public double Price { get; set; }

        public Item(string name, double price) : base(name)
        {
            Price = price;
        }

        // test
        public Item() : base("") { }

        public override string ToString()
        {
            return $"{Name}: {Price}";
        }

        public Item Deserialize(string xmlString)
        {
            XmlDocument itemsDoc = new XmlDocument();

            var iProp = typeof(Item);
            Item resultItem = new Item();

            // test
            itemsDoc.LoadXml("<root>" + xmlString + "</root>");
            XmlElement? rootElement = itemsDoc.DocumentElement;

            if (rootElement is null)
                throw new NotImplementedException();

            foreach (XmlElement node in rootElement)
            {
                var prop = iProp.GetProperty(node.Name);
                if (prop is null)
                    throw new NotImplementedException();

                var propType = prop.PropertyType;

                if (propType == typeof(double))
                {
                    double doubleValue;
                    double.TryParse(node.InnerText, out doubleValue);
                    prop.SetValue(resultItem, doubleValue, null);
                }
                else
                    prop.SetValue(resultItem, node.InnerText, null);
            }
            return resultItem;
        }
    }
}
