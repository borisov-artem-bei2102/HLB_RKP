using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Xml;

namespace HLP_RKP_LR1.Models
{
    internal class XMLEditor
    {
        public static XmlDocument doc = new XmlDocument();

        public static void CreateBaseDocStructure(string fileName)
        {
            doc = new XmlDocument();
            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);
            XmlElement element = doc.CreateElement(string.Empty, fileName.Split('.')[0], string.Empty);
            doc.AppendChild(element);
        }

        public static void LoadFile(string fileName)
        {
            if (!File.Exists(fileName))
            {
                CreateBaseDocStructure(fileName);
                doc.Save(fileName);
            }
            doc.Load(fileName);
        }
    }
}
