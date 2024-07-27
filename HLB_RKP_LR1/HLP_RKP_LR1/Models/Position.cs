using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace HLP_RKP_LR1.Models
{
    internal class Position
    {
        private static List<Position> items;
        private static readonly string fileName = "positions.xml";
        private static readonly string xmlItemName = "position";

        public string ID { get; set; }
        public string Name { get; set; }
        public Position(string id, string name)
        {
            ID = id;
            Name = name;
        }

        public static void Init(DataGridView dgv)
        {
            int rowsCounter = 0;
            foreach (Position item in items)
            {
                dgv.Rows.Add();
                dgv[0, rowsCounter].Value = item.ID;
                dgv[1, rowsCounter].Value = item.Name;
                rowsCounter++;
            }
        }

        public static void Load()
        {
            XMLEditor.LoadFile(fileName);
            XmlElement xRoot = XMLEditor.doc.DocumentElement;
            items = new List<Position>();

            foreach (XmlNode node in xRoot)
            {
                string id = "";
                string name = "";
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if (childNode.Name == "id")
                    {
                        id = Convert.ToString(childNode.InnerText);
                    }
                    if (childNode.Name == "name")
                    {
                        name = Convert.ToString(childNode.InnerText);
                    }
                }
                items.Add(new Position(id, name));
            }
        }

        public static void Edit(DataGridView dgv, DataGridViewCellEventArgs e)
        {
            if (items.Count - 1 < e.RowIndex)
            {
                items.Add(new Position("", ""));
            }
            if (e.ColumnIndex == 0)
            {
                items[e.RowIndex].ID = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
            if (e.ColumnIndex == 1)
            {
                items[e.RowIndex].Name = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
        }

        public static void Save()
        {
            XMLEditor.CreateBaseDocStructure(fileName);
            foreach (Position item in items)
            {
                XmlElement departmentElement = XMLEditor.doc.CreateElement(string.Empty, xmlItemName, string.Empty);

                XmlElement idElement = XMLEditor.doc.CreateElement(string.Empty, "id", string.Empty);
                idElement.InnerText = item.ID;

                XmlElement nameElement = XMLEditor.doc.CreateElement(string.Empty, "name", string.Empty);
                nameElement.InnerText = item.Name;

                departmentElement.AppendChild(idElement);
                departmentElement.AppendChild(nameElement);
                XMLEditor.doc.DocumentElement.AppendChild(departmentElement);
            }
            XMLEditor.doc.Save(fileName);
        }

        public static void DeleteRows(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                if (items.Count - 1 >= row.Index)
                {
                    items.Remove(items[row.Index]);
                    dgv.Rows.RemoveAt(row.Index);
                }
            }
        }
    }
}
