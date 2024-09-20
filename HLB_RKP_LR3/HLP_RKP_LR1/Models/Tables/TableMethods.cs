using DocumentFormat.OpenXml.CustomXmlSchemaReferences;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;
using HLP_RKP_LR1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

// 1. инициализация
// 1.1 
//
//
//
//
//
//
//
//
//

namespace HLP_RKP_LR2.Models
{
    internal class TableMethods
    {
        public static void Init(DataGridView dgv, List<TableItem> items, Dictionary<string, ItemTypes> schema, string fileName)
        {
            LoadXML(fileName, schema, items);
            InitDGV(dgv, items, schema);
        }

        public static void LoadXML(string fileName, Dictionary<string, ItemTypes> schema, List<TableItem> items)
        {
            XMLEditor.LoadFile(fileName);
            LoadXMLColumns(schema);
            LoadXMLValues(schema, items);
        }

        public static void LoadXMLColumns(Dictionary<string, ItemTypes> schema)
        {
            XmlNode columnsNode = XMLEditor.FindColumnsNode();
            if (columnsNode != null && columnsNode.HasChildNodes)
            {
                schema.Clear();
                foreach (XmlNode column in columnsNode.ChildNodes)
                {
                    TypedItem.StringToTypeDict.TryGetValue(column.InnerText, out ItemTypes itemType);
                    schema.Add(column.Name, itemType);
                }
            }
        }

        public static void LoadXMLValues(Dictionary<string, ItemTypes> schema, List<TableItem> items)
        {
            items?.Clear();

            XmlNode valuesNode = XMLEditor.FindValuesNode();

            if (valuesNode != null)
            {

                foreach (XmlNode item in valuesNode.ChildNodes)
                {
                    Dictionary<string, string> values = new Dictionary<string, string>();
                    foreach (XmlNode param in item.ChildNodes)
                    {
                        values.Add(param.Name, param.InnerText);
                    }
                    items.Add(new TableItem(schema, values));
                }
            }
        }

        public static void InitDGV(DataGridView dgv, List<TableItem> items, Dictionary<string, ItemTypes> schema)
        {
            InitDGVColumns(dgv, schema);
            InitDGVValues(dgv, items, schema);
        }

        public static void InitDGVValues(DataGridView dgv, List<TableItem> items, Dictionary<string, ItemTypes> schema)
        {
            int rowsCounter = 0;
            foreach (TableItem item in items)
            {
                dgv.Rows.Add();
                int colCounter = 0;
                foreach (KeyValuePair<string, ItemTypes> pair in schema)
                {
                    item.Values.TryGetValue(pair.Key, out TypedItem itemValueByColumn);
                    dgv[colCounter, rowsCounter].Value = itemValueByColumn != null ? itemValueByColumn.Value : "";
                    colCounter++;
                }
                rowsCounter++;
            }
        }

        public static void InitDGVColumns(DataGridView dgv, Dictionary<string, ItemTypes> schema)
        {
            dgv.ColumnCount = schema.Count;
            dgv.RowCount = 1;
            int colCounter = 0;
            foreach (KeyValuePair<string, ItemTypes> pair in schema)
            {
                dgv.Columns[colCounter].HeaderText = pair.Key;
                colCounter++;
            }
        }

        public static void EditCell(DataGridView dgv, DataGridViewCellEventArgs e, List<TableItem> items, Dictionary<string, ItemTypes> schema)
        {
            if (items.Count - 1 < e.RowIndex)
            {
                items.Add(new TableItem(schema));
            }

            int col = e.ColumnIndex;
            int row = e.RowIndex;

            string header = dgv.Columns[col].HeaderText;

            DataGridViewCell cell = dgv[col, row];

            items[row].Values.TryGetValue(header, out TypedItem currentValue);
            currentValue.Value = cell.Value.ToString();
            currentValue.Validate();
            cell.Value = currentValue.Value;
        }

        public static void DeleteRows(DataGridView dgv, List<TableItem> items)
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

        public static void Save(string fileName, string xmlItemName, Dictionary<string, ItemTypes> schema, List<TableItem> items)
        {
            XMLEditor.CreateBaseDocStructure(fileName);

            XMLEditor.doc.DocumentElement.AppendChild(GetColumnsXmlElement(schema));
            XMLEditor.doc.DocumentElement.AppendChild(GetValuesXmlElement(items, xmlItemName));

            XMLEditor.doc.Save(fileName);
        }

        public static XmlElement GetColumnsXmlElement(Dictionary<string, ItemTypes> schema)
        {
            XmlElement columnsElement = XMLEditor.CreateElement(XMLEditor.COLUMNS_TAG);

            foreach (KeyValuePair<string, ItemTypes> pair in schema)
            {
                TypedItem.TypeToStringDict.TryGetValue(pair.Value, out string value);
                XmlElement columnElement = XMLEditor.CreateElement(pair.Key, value);
                columnsElement.AppendChild(columnElement);
            }

            return columnsElement;
        }

        public static XmlElement GetValuesXmlElement(List<TableItem> items, string xmlItemName)
        {
            XmlElement valuesElement = XMLEditor.CreateElement(XMLEditor.VALUES_TAG);

            foreach (TableItem item in items)
            {
                XmlElement positionElement = XMLEditor.CreateElement(xmlItemName);
                foreach (KeyValuePair<string, TypedItem> pair in item.Values)
                {
                    XmlElement paramElement = XMLEditor.CreateElement(pair.Key, pair.Value.Value);
                    positionElement.AppendChild(paramElement);
                }
                valuesElement.AppendChild(positionElement);
            }

            return valuesElement;
        }

        public static void UpdateValuesBySchema(List<TableItem> items, Dictionary<string, ItemTypes> schema)
        {
            foreach (TableItem item in items)
            {
                foreach (KeyValuePair<string, ItemTypes> pair in schema)
                {
                    if (!item.Values.ContainsKey(pair.Key))
                    {
                        item.Values.Add(pair.Key, new TypedItem("", pair.Value));
                    }

                }
            }
        }
    }
}
