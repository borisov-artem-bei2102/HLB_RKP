using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace HLP_RKP_LR1.Models
{
    internal class Appointment
    {
        private static List<Appointment> items;
        private static readonly string fileName = "appointments.xml";
        private static readonly string xmlItemName = "appointment";

        public string ID { get; set; }
        public string PatientID { get; set; }
        public string DoctorID { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Report { get; set; }
        public Appointment(string id, string patientID, string doctorID, string date, string time, string report)
        {
            ID = id;
            PatientID = patientID;
            DoctorID = doctorID;
            Date = date;
            Time = time;
            Report = report;
        }

        public static void Init(DataGridView dgv)
        {
            int rowsCounter = 0;
            foreach (Appointment item in items)
            {
                dgv.Rows.Add();
                dgv[0, rowsCounter].Value = item.ID;
                dgv[1, rowsCounter].Value = item.PatientID;
                dgv[2, rowsCounter].Value = item.DoctorID;
                dgv[3, rowsCounter].Value = item.Date;
                dgv[4, rowsCounter].Value = item.Time;
                dgv[5, rowsCounter].Value = item.Report;
                rowsCounter++;
            }
        }

        public static void Load()
        {
            XMLEditor.LoadFile(fileName);
            XmlElement xRoot = XMLEditor.doc.DocumentElement;
            items = new List<Appointment>();

            foreach (XmlNode node in xRoot)
            {
                string id = "";
                string patientID = "";
                string doctorID = "";
                string date = "";
                string time = "";
                string report = "";
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if (childNode.Name == "id")
                    {
                        id = Convert.ToString(childNode.InnerText);
                    }
                    if (childNode.Name == "patientID")
                    {
                        patientID = Convert.ToString(childNode.InnerText);
                    }
                    if (childNode.Name == "doctorID")
                    {
                        doctorID = Convert.ToString(childNode.InnerText);
                    }
                    if (childNode.Name == "date")
                    {
                        date = Convert.ToString(childNode.InnerText);
                    }
                    if (childNode.Name == "time")
                    {
                        time = Convert.ToString(childNode.InnerText);
                    }
                    if (childNode.Name == "report")
                    {
                        report = Convert.ToString(childNode.InnerText);
                    }
                }
                items.Add(new Appointment(id, patientID, doctorID, date, time, report));
            }
        }

        public static void Edit(DataGridView dgv, DataGridViewCellEventArgs e)
        {
            if (items.Count - 1 < e.RowIndex)
            {
                items.Add(new Appointment("", "", "", "", "", ""));
            }
            if (e.ColumnIndex == 0)
            {
                items[e.RowIndex].ID = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
            if (e.ColumnIndex == 1)
            {
                items[e.RowIndex].PatientID = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
            if (e.ColumnIndex == 2)
            {
                items[e.RowIndex].DoctorID = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
            if (e.ColumnIndex == 3)
            {
                items[e.RowIndex].Date = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
            if (e.ColumnIndex == 4)
            {
                items[e.RowIndex].Time = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
            if (e.ColumnIndex == 5)
            {
                items[e.RowIndex].Report = dgv[e.ColumnIndex, e.RowIndex].Value.ToString();
            }
        }

        public static void Save()
        {
            XMLEditor.CreateBaseDocStructure(fileName);
            foreach (Appointment item in items)
            {
                XmlElement departmentElement = XMLEditor.doc.CreateElement(string.Empty, xmlItemName, string.Empty);

                XmlElement idElement = XMLEditor.doc.CreateElement(string.Empty, "id", string.Empty);
                idElement.InnerText = item.ID;

                XmlElement patientIDElement = XMLEditor.doc.CreateElement(string.Empty, "patientID", string.Empty);
                patientIDElement.InnerText = item.PatientID;

                XmlElement doctorIDElement = XMLEditor.doc.CreateElement(string.Empty, "doctorID", string.Empty);
                doctorIDElement.InnerText = item.DoctorID;

                XmlElement dateElement = XMLEditor.doc.CreateElement(string.Empty, "date", string.Empty);
                dateElement.InnerText = item.Date;

                XmlElement timeElement = XMLEditor.doc.CreateElement(string.Empty, "time", string.Empty);
                timeElement.InnerText = item.Time;

                XmlElement reportElement = XMLEditor.doc.CreateElement(string.Empty, "report", string.Empty);
                reportElement.InnerText = item.Report;

                departmentElement.AppendChild(idElement);
                departmentElement.AppendChild(patientIDElement);
                departmentElement.AppendChild(doctorIDElement);
                departmentElement.AppendChild(dateElement);
                departmentElement.AppendChild(timeElement);
                departmentElement.AppendChild(reportElement);
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
