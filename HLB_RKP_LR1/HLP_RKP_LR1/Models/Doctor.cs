using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace HLP_RKP_LR1.Models
{
    internal class Doctor
    {
        private static List<Doctor> items;
        private static readonly string fileName = "doctors.xml";
        private static readonly string xmlItemName = "doctor";

        public string ID { get; set; }
        public string Name { get; set; }
        public string Birth { get; set; }
        public string DepartmentID { get; set; }
        public string PositionID { get; set; }
        public string Sex { get; set; }
        public Doctor(string id, string name, string birth, string depID, string posID, string sex)
        {
            ID = id;
            Name = name;
            Birth = birth;
            DepartmentID = depID;
            PositionID = posID;
            Sex = sex;
        }

        public static void Init(DataGridView dgv)
        {
            int rowsCounter = 0;
            foreach (Doctor item in items)
            {
                dgv.Rows.Add();
                dgv[0, rowsCounter].Value = item.ID;
                dgv[1, rowsCounter].Value = item.Name;
                dgv[2, rowsCounter].Value = item.Birth;
                dgv[3, rowsCounter].Value = item.DepartmentID;
                dgv[4, rowsCounter].Value = item.PositionID;
                dgv[5, rowsCounter].Value = item.Sex;
                rowsCounter++;
            }
        }

        public static void Load()
        {
            XMLEditor.LoadFile(fileName);
            XmlElement xRoot = XMLEditor.doc.DocumentElement;
            items = new List<Doctor>();

            foreach (XmlNode node in xRoot)
            {
                string id = "";
                string name = "";
                string birth = "";
                string depID = "";
                string posID = "";
                string sex = "";
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
                    if (childNode.Name == "birth")
                    {
                        birth = Convert.ToString(childNode.InnerText);
                    }
                    if (childNode.Name == "departmentID")
                    {
                        depID = Convert.ToString(childNode.InnerText);
                    }
                    if (childNode.Name == "positionID")
                    {
                        posID = Convert.ToString(childNode.InnerText);
                    }
                    if (childNode.Name == "sex")
                    {
                        sex = Convert.ToString(childNode.InnerText);
                    }
                }
                items.Add(new Doctor(id, name, birth, depID, posID, sex));
            }
        }

        public static void Edit(DataGridView dgv, DataGridViewCellEventArgs e)
        {
            if (items.Count - 1 < e.RowIndex)
            {
                items.Add(new Doctor("", "", "", "", "", ""));
            }
            if (e.ColumnIndex == 0)
            {
                items[e.RowIndex].ID = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
            if (e.ColumnIndex == 1)
            {
                items[e.RowIndex].Name = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
            if (e.ColumnIndex == 2)
            {
                items[e.RowIndex].Birth = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
            if (e.ColumnIndex == 3)
            {
                items[e.RowIndex].DepartmentID = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
            if (e.ColumnIndex == 4)
            {
                items[e.RowIndex].PositionID = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
            if (e.ColumnIndex == 5)
            {
                items[e.RowIndex].Sex = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
        }

        public static void Save()
        {
            XMLEditor.CreateBaseDocStructure(fileName);
            foreach (Doctor item in items)
            {
                XmlElement departmentElement = XMLEditor.doc.CreateElement(string.Empty, xmlItemName, string.Empty);

                XmlElement idElement = XMLEditor.doc.CreateElement(string.Empty, "id", string.Empty);
                idElement.InnerText = item.ID;

                XmlElement nameElement = XMLEditor.doc.CreateElement(string.Empty, "name", string.Empty);
                nameElement.InnerText = item.Name;

                XmlElement birthElement = XMLEditor.doc.CreateElement(string.Empty, "birth", string.Empty);
                birthElement.InnerText = item.Birth;

                XmlElement depIDElement = XMLEditor.doc.CreateElement(string.Empty, "departmentID", string.Empty);
                depIDElement.InnerText = item.DepartmentID;

                XmlElement posIDElement = XMLEditor.doc.CreateElement(string.Empty, "positionID", string.Empty);
                posIDElement.InnerText = item.PositionID;

                XmlElement sexElement = XMLEditor.doc.CreateElement(string.Empty, "sex", string.Empty);
                sexElement.InnerText = item.Sex;

                departmentElement.AppendChild(idElement);
                departmentElement.AppendChild(nameElement);
                departmentElement.AppendChild(birthElement);
                departmentElement.AppendChild(depIDElement);
                departmentElement.AppendChild(posIDElement);
                departmentElement.AppendChild(sexElement);
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
