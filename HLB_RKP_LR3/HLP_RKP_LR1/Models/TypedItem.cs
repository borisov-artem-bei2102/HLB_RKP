using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HLP_RKP_LR3.Models
{
    public enum ItemTypes
    {
        num,
        str,
        date
    }

    public class TypedItem
    {
        public static Dictionary<string, ItemTypes> StringToTypeDict = new Dictionary<string, ItemTypes>()
        {
            { "str", ItemTypes.str },
            { "num", ItemTypes.num },
            { "date", ItemTypes.date }
        };

        public static Dictionary<string, string> HumanToStringDict = new Dictionary<string, string>()
        {
            { "Строка", "str" },
            { "Число", "num" },
            { "Дата" , "date" }
        };

        public static Dictionary<string, ItemTypes> HumanToTypeDict = new Dictionary<string, ItemTypes>()
        {
            { "Строка", ItemTypes.str },
            { "Число", ItemTypes.num },
            { "Дата" , ItemTypes.date }
        };

        public static Dictionary<ItemTypes, string> TypeToStringDict = new Dictionary<ItemTypes, string>()
        {
            { ItemTypes.str, "str" },
            { ItemTypes.num, "num" },
            { ItemTypes.date, "date" }
        };

        public static Dictionary<ItemTypes, string> TypeToHumanDict = new Dictionary<ItemTypes, string>()
        {
            { ItemTypes.str, "Строка" },
            { ItemTypes.num, "Число" },
            { ItemTypes.date , "Дата" }
        };

        public ItemTypes Type { get; set; }
        public string Value { get; set; }

        public TypedItem(string value, ItemTypes type)
        {
            Type = type;
            Value = value;
        }

        public bool Validate(bool withError = true)
        {
            if (Value == string.Empty) return true;

            bool success = true;
            if (Type == ItemTypes.num)
            {
                success = int.TryParse(Value, out _);
            }
            if (Type == ItemTypes.date)
            {
                success = DateTime.TryParse(Value, out _);
            }

            if (!success)
            {
                if (withError)
                {
                    MessageBox.Show($"Неверный тип данных для значения \"{Value}\"!\nНеобходимый тип данных - \"{TypeToHumanDict[Type]}\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Value = string.Empty;
            }
            return success;
        }
    }
}
