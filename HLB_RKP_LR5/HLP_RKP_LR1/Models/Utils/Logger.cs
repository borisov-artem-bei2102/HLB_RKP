using HLP_RKP_LR3.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLP_RKP_LR2.Models.Utils
{
    enum OPERATION_TYPES
    {
        ADD_COLUMN,
        ADD_ITEM,
        EDIT_COLUMN,
        EDIT_CELL,
        DELETE_ITEM,
        DELETE_COLUMN,
        SAVE,
        ERROR,
        RESTRICTED_ACCESS,
        DB_EXPORT,
        DB_IMPORT
    }
    internal class Logger
    {
        private const string FILE_NAME = "logs.txt";

        private static void AddLog(OPERATION_TYPES type, string payload)
        {
            string currentDate = DateTime.Now.ToLocalTime().ToString();
            File.AppendAllText(FILE_NAME, $"{currentDate} [{type}] {payload}\n");
        }

        public static void Save(string path)
        {
            AddLog(OPERATION_TYPES.SAVE, $"{path}");
        }

        public static void Error(string description)
        {
            AddLog(OPERATION_TYPES.ERROR, description);
        }

        public static void EditCell(string dgvName, string colName, string oldValue, string newValue)
        {
            AddLog(OPERATION_TYPES.EDIT_CELL, $"{dgvName} - \"{colName}\" - \"{oldValue}\" -> \"{newValue}\"");
        }

        public static void EditColumn(string dgvName, string oldColName, string newColName, ItemTypes newType)
        {
            AddLog(OPERATION_TYPES.EDIT_COLUMN, $"{dgvName} - \"{oldColName}\" - название: \"{newColName}\", тип: \"{TypedItem.TypeToHumanDict[newType]}\"");
        }

        public static void AddItem(string dgvName)
        {
            AddLog(OPERATION_TYPES.ADD_ITEM, $"{dgvName}");
        }

        public static void AddColumn(string dgvName, string columnName)
        {
            AddLog(OPERATION_TYPES.ADD_COLUMN, $"{dgvName} - {columnName}");
        }

        public static void DeleteItem(string dgvName)
        {
            AddLog(OPERATION_TYPES.DELETE_ITEM, $"{dgvName}");
        }

        public static void DeleteColumn(string dgvName, string columnName)
        {
            AddLog(OPERATION_TYPES.DELETE_COLUMN, $"{dgvName} - {columnName}");
        }

        public static void RestrictedAccess(string action)
        {
            AddLog(OPERATION_TYPES.RESTRICTED_ACCESS, $"{User.Username} - {action}");
        }

        public static void ExportToDB(string tableName)
        {
            AddLog(OPERATION_TYPES.DB_EXPORT, tableName);
        }

        public static void ImportFromDB(string tableName)
        {
            AddLog(OPERATION_TYPES.DB_IMPORT, tableName);
        }
    }
}
