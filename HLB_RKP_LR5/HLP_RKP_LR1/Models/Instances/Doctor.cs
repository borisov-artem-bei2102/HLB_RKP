using System.Collections.Generic;

namespace HLP_RKP_LR3.Models
{
    public class Doctor
    {
        public static List<TableItem> items = new List<TableItem>();
        public static readonly string fileName = "xml/Доктора.xml";
        public static readonly string xmlElementName = "Доктор";
        public static readonly string DBTableName = "doctors";
        public static Dictionary<string, ItemTypes> schema = new Dictionary<string, ItemTypes>()
        {
            { "Код", ItemTypes.num },
            { "ФИО", ItemTypes.str },
            { "Дата_Рождения", ItemTypes.date },
            { "Код_Отделения", ItemTypes.num },
            { "Код_Должности", ItemTypes.num },
            { "Пол", ItemTypes.str },
        };
    }
}
