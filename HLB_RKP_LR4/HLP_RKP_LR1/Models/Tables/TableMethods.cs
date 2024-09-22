using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using HLP_RKP_LR2.Models.Utils;
using HLP_RKP_LR3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace HLP_RKP_LR3.Models
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
            if (!User.IsAbleToMakeAction("Добавление/Изменение данных", ROLES.EMPLOYEE))
            {
                dgv.Rows.RemoveAt(e.RowIndex);
                return;
            }

            if (items.Count - 1 < e.RowIndex)
            {
                items.Add(new TableItem(schema));
                Logger.AddItem(dgv.Name);
            }

            int col = e.ColumnIndex;
            int row = e.RowIndex;

            string header = dgv.Columns[col].HeaderText;

            DataGridViewCell cell = dgv[col, row];

            try
            {
                items[row].Values.TryGetValue(header, out TypedItem currentValue);
                string oldValue = currentValue.Value;
                currentValue.Value = cell.Value.ToString();
                currentValue.Validate();

                Logger.EditCell(dgv.Name, header, oldValue, currentValue.Value);
            }
            catch
            {
                Logger.Error($"{dgv.Name} - Ошибка изменения значения столбца \"{header}\"");
            }
        }

        public static void DeleteRows(DataGridView dgv, List<TableItem> items)
        {
            if (!User.IsAbleToMakeAction("Удаление данных", ROLES.EMPLOYEE))
            {
                return;
            }

            foreach (DataGridViewRow row in dgv.SelectedRows)
            {
                try
                {

                    if (items.Count - 1 >= row.Index)
                    {
                        items.Remove(items[row.Index]);
                        dgv.Rows.RemoveAt(row.Index);
                    }
                    Logger.DeleteItem(dgv.Name);
                }
                catch
                {
                    Logger.Error(dgv.Name);
                }
            }
        }

        public static void Save(string fileName, string xmlItemName, Dictionary<string, ItemTypes> schema, List<TableItem> items)
        {
            try
            {
                XMLEditor.CreateBaseDocStructure(fileName);

                XMLEditor.doc.DocumentElement.AppendChild(GetColumnsXmlElement(schema));
                XMLEditor.doc.DocumentElement.AppendChild(GetValuesXmlElement(items, xmlItemName));

                XMLEditor.doc.Save(fileName);

                Logger.Save(fileName);
            }
            catch
            {
                Logger.Error($"{fileName} - Сохранение данных");
            }
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

        public static void UpdateTableOnAdd(string name, ItemTypes type, List<TableItem> items, Dictionary<string, ItemTypes> schema)
        {
            schema.Add(name, type);

            foreach (TableItem item in items)
            {
                foreach (KeyValuePair<string, ItemTypes> pair in schema)
                {
                    if (!item.Values.ContainsKey(pair.Key))
                    {
                        item.Values.Add(pair.Key, new TypedItem("", pair.Value));
                        break;
                    }
                }
            }
        }

        public static void UpdateTableOnDelete(string name, List<TableItem> items, Dictionary<string, ItemTypes> schema)
        {
            schema.Remove(name);

            foreach (TableItem item in items)
            {
                foreach (KeyValuePair<string, TypedItem> pair in item.Values)
                {
                    if (!schema.ContainsKey(pair.Key))
                    {
                        item.Values.Remove(pair.Key);
                        break;
                    }
                }
            }
        }

        public static void UpdateTableOnEdit(string oldColName, string newColName, ItemTypes newType, List<TableItem> items, Dictionary<string, ItemTypes> schema)
        {
            Dictionary<string, ItemTypes> oldSchema = schema.ToDictionary(entry => entry.Key, entry => entry.Value);
            schema.Clear();
            foreach (KeyValuePair<string, ItemTypes> pair in oldSchema)
            {
                if (pair.Key == oldColName)
                {
                    schema.Add(newColName, newType);
                }
                else
                {
                    schema.Add(pair.Key, pair.Value);
                }
            }

            foreach (TableItem item in items)
            {
                Dictionary<string, TypedItem> oldValues = item.Values.ToDictionary(entry => entry.Key, entry => entry.Value);
                item.Values.Clear();

                foreach (KeyValuePair<string, TypedItem> pair in oldValues)
                {
                    if (pair.Key == oldColName)
                    {
                        TypedItem newItem = pair.Value;
                        ItemTypes schemaType = schema[newColName];
                        newItem.Type = schemaType;
                        newItem.Validate(false);
                        item.Values.Add(newColName, newItem);
                    }
                    else
                    {
                        item.Values.Add(pair.Key, pair.Value);
                    }
                }
            }
        }
    }
}
