using HLP_RKP_LR3.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HLP_RKP_LR2.Models.Utils
{
    internal class DBConnector
    {
        private const string connectionString = "Server=localhost;Database=lr5;Uid=root;Pwd=mysql;";

        private const string TABLES_TABLE = "client_tables";
        private const string COLUMNS_TABLE = "columns";
        private const string DATA_TABLE = "data";
        private const string ITEMS_TABLE = "items";

        private static void ExecuteCommandNonQuery(string query, MySqlConnection connection)
        {
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                command.ExecuteNonQuery();
            }
        }

        public static int GetLastId(MySqlConnection connection)
        {
            string query = "select last_insert_id()";

            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public static MySqlDataReader ExecuteCommandReader(MySqlConnection connection, string query)
        {
            MySqlDataReader reader = null;
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                reader = command.ExecuteReader();
            }
            return reader;
        }

        public static void ClearOldData()
        {
            string query;
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                query = $"SET FOREIGN_KEY_CHECKS = 0";
                ExecuteCommandNonQuery(query, connection);

                query = $"truncate {ITEMS_TABLE}";
                ExecuteCommandNonQuery(query, connection);

                query = $"truncate {DATA_TABLE}";
                ExecuteCommandNonQuery(query, connection);

                query = $"truncate {COLUMNS_TABLE}";
                ExecuteCommandNonQuery(query, connection);

                query = $"truncate {TABLES_TABLE}";
                ExecuteCommandNonQuery(query, connection);

                query = $"SET FOREIGN_KEY_CHECKS = 1";
                ExecuteCommandNonQuery(query, connection);

                connection.Close();
            }
        }

        public static void ExportTable(string tableName, Dictionary<string, ItemTypes> schema, List<TableItem> items)
        {
            try
            {
                string query;
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    query = $"insert {TABLES_TABLE} (name) values (\"{tableName}\")";
                    ExecuteCommandNonQuery(query, connection);
                    int tableID = GetLastId(connection);

                    Dictionary<string, int> columnsWithIDs = ExportColumns(connection, tableID, schema);
                    ExportData(connection, tableID, columnsWithIDs, items);

                    connection.Close();
                }

                Logger.ExportToDB(tableName);
            }
            catch
            {
                Logger.Error($"Ошибка экспорта в БД таблицы \"{tableName}\"");
                throw new Exception();
            }

        }

        public static Dictionary<string, int> ExportColumns(MySqlConnection connection, int tableID, Dictionary<string, ItemTypes> schema)
        {
            string query;
            Dictionary<string, int> columnsWithIDs = new Dictionary<string, int>();
            foreach (KeyValuePair<string, ItemTypes> pair in schema)
            {
                query = $"insert {COLUMNS_TABLE} (name, data_type, table_id) values (\"{pair.Key}\", \"{TypedItem.TypeToStringDict[pair.Value]}\", {tableID})";
                ExecuteCommandNonQuery(query, connection);
                int columnID = GetLastId(connection);
                columnsWithIDs.Add(pair.Key, columnID);
            }

            return columnsWithIDs;
        }

        public static Dictionary<string, int> ExportData(MySqlConnection connection, int tableID, Dictionary<string, int> columnsWithIDs, List<TableItem> items)
        {
            string query;
            foreach (TableItem item in items)
            {
                query = $"insert {ITEMS_TABLE}(table_id) values ({tableID})";
                ExecuteCommandNonQuery(query, connection);

                int itemID = GetLastId(connection);

                foreach (KeyValuePair<string, TypedItem> pair in item.Values)
                {
                    query = $"insert {DATA_TABLE} (value, column_id, item_id) values (\"{pair.Value.Value}\", \"{columnsWithIDs[pair.Key]}\", {itemID})";
                    ExecuteCommandNonQuery(query, connection);
                }
            }

            return columnsWithIDs;
        }

        public static void ImportTable(string tableName, Dictionary<string, ItemTypes> schema, List<TableItem> items)
        {
            try
            {
                string query;
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    query = $"select * from {TABLES_TABLE} where name = \"{tableName}\"";
                    MySqlDataReader reader = ExecuteCommandReader(connection, query);
                    reader.Read();

                    int tableID = reader.GetInt32("id");
                    reader.Close();
                    ImportColumns(connection, tableID, schema);
                    ImportData(connection, tableID, items, schema);

                    connection.Close();
                }

                Logger.ImportFromDB(tableName);
            }
            catch
            {
                Logger.Error($"Ошибка импорта из БД таблицы \"{tableName}\"");
                throw new Exception();
            }
        }

        private static void ImportColumns(MySqlConnection connection, int tableID, Dictionary<string, ItemTypes> schema)
        {
            schema.Clear();

            Dictionary<string, int> columnsWithIDs = new Dictionary<string, int>();

            string query = $"select * from {COLUMNS_TABLE} where table_id = {tableID}";
            MySqlDataReader reader = ExecuteCommandReader(connection, query);
            while (reader.Read())
            {
                int id = reader.GetInt32("id");
                string name = reader.GetString("name");
                string data_type = reader.GetString("data_type");
                ItemTypes type = TypedItem.StringToTypeDict[data_type];

                schema.Add(name, type);
                columnsWithIDs.Add(name, id);
            }

            reader.Close();
        }

        private static void ImportData(MySqlConnection connection, int tableID, List<TableItem> items, Dictionary<string, ItemTypes> schema)
        {
            items.Clear();

            string query = $"select {COLUMNS_TABLE}.name, {DATA_TABLE}.value"
                + $" from {ITEMS_TABLE}"
                + $" join {DATA_TABLE} on {DATA_TABLE}.item_id = {ITEMS_TABLE}.id"
                + $" join {COLUMNS_TABLE} on {COLUMNS_TABLE}.id = {DATA_TABLE}.column_id"
                + $" where {ITEMS_TABLE}.table_id = {tableID}";

            MySqlDataReader reader = ExecuteCommandReader(connection, query);

            if (!reader.HasRows)
            {
                return;
            }

            int columnCount = 0;
            Dictionary<string, string> itemValues = new Dictionary<string, string>();

            while (reader.Read())
            {
                string name = reader.GetString("name");
                string value = reader.GetString("value");

                if (!itemValues.ContainsKey(name))
                {
                    itemValues.Add(name, value);
                }

                columnCount++;
                if (columnCount == schema.Count)
                {
                    items.Add(new TableItem(schema, itemValues));
                    itemValues.Clear();
                    columnCount = 0;
                }
            };

            reader.Close();
        }
    }
}
