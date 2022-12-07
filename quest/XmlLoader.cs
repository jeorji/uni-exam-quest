using System.Xml;

namespace UniExamQuest
{
    public class XmlLoader
    {
        private string _path = String.Empty;
        private string Path
        {
            get => _path;
            set 
            { 
                _path = value;
                if (!File.Exists(_path))
                {
                    throw new NotImplementedException();
                }

                if (System.IO.Path.GetExtension(_path) != ".xml")
                {
                    throw new NotImplementedException();
                }
            }
        }
        public XmlLoader(string path)
        {
            Path = path;
        }
        public void Parse()
        {
            XmlDocument itemsDoc = new XmlDocument();
            itemsDoc.Load(Path);
            
            XmlElement? rootElement = itemsDoc.DocumentElement;
            if (rootElement != null)
            {
                foreach (XmlElement element in rootElement)
                {
                    if (element.Name == "name")
                    {
                        Console.Write($"Name: {element.InnerText}");
                    }

                    if (element.Name == "price")
                    {
                        Console.Write($"Price: {element.InnerText}");
                    }

                    XmlNode? health = element.Attributes.GetNamedItem("health");
                    Console.Write(health?.Value + " ");
                    XmlNode? satiation = element.Attributes.GetNamedItem("satiation");
                    Console.Write(satiation?.Value + " ");
                    XmlNode? happiness = element.Attributes.GetNamedItem("happiness");
                    Console.Write(happiness?.Value + " ");
                    XmlNode? mind = element.Attributes.GetNamedItem("mind");
                    Console.Write(mind?.Value + " ");
                    
                    Console.WriteLine();
                }
            }
        }
    }
}

