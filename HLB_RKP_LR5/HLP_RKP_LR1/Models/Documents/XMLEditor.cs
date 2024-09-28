using System.IO;
using System.Linq;
using System.Xml;

namespace HLP_RKP_LR3.Models
{
    internal class XMLEditor
    {
        public static XmlDocument doc = new XmlDocument();

        public static string COLUMNS_TAG = "Колонны";
        public static string VALUES_TAG = "Значения";

        public static void CreateBaseDocStructure(string fileName)
        {
            doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);
            XmlElement element = CreateElement(fileName.Split('/').Last().Split('.')[0]);
            doc.AppendChild(element);
        }

        public static void LoadFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                FileStream fs = File.Create(fileName);
                fs.Close();
                CreateBaseDocStructure(fileName);
                doc.Save(fileName);
            }
            doc.Load(fileName);
        }

        public static XmlElement CreateElement(string name, string value = null)
        {
            XmlElement elem = doc.CreateElement(string.Empty, name, string.Empty);
            elem.InnerText = value;
            return elem;
        }

        public static XmlNode FindColumnsNode()
        {
            XmlNodeList nodes = doc.GetElementsByTagName(COLUMNS_TAG);
            return nodes.Count > 0 ? nodes[0] : null;
        }

        public static XmlNode FindValuesNode()
        {
            XmlNodeList nodes = doc.GetElementsByTagName(VALUES_TAG);
            return nodes.Count > 0 ? nodes[0] : null;
        }
    }
}
