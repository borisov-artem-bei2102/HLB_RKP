using System.Collections.Generic;

namespace HLP_RKP_LR3.Models
{
    public class Patient
    {
        public static List<TableItem> items = new List<TableItem>();
        public static readonly string fileName = "xml/Пациенты.xml";
        public static readonly string xmlElementName = "Пациент";
        public static Dictionary<string, ItemTypes> schema = new Dictionary<string, ItemTypes>()
        {
            { "Код", ItemTypes.num },
            { "ФИО", ItemTypes.str },
            { "Дата_Рождения", ItemTypes.date },
            { "Полис", ItemTypes.num },
            { "Паспорт", ItemTypes.num },
            { "Пол", ItemTypes.str },
        };
    }
}
