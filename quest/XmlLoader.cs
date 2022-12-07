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
                    Console.Write(element.Name + ": " + element.InnerText + " ");

                    foreach (XmlAttribute xmlAttribute in element.Attributes)
                    {
                        Console.Write(xmlAttribute.Name + " " + xmlAttribute.Value + " ");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}

