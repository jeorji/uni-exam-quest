using System.Xml;

namespace UniExamQuest
{
    public interface IDeserializable<T> where T: new()
    {
        T Deserialize(string xmlString);
    }

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

        public List<T> Parse<T>() where T: IDeserializable<T>, new()
        {
            XmlDocument itemsDoc = new XmlDocument();
            itemsDoc.Load(Path);
            var resultList = new List<T>();

            XmlElement? rootElement = itemsDoc.DocumentElement;

            if (rootElement != null)
            {
                foreach (XmlElement element in rootElement)
                {
                    T singelItem = new T();
                    resultList.Add(singelItem.Deserialize(element.InnerXml));
                }
            }
            return resultList;
        }
    }

}

