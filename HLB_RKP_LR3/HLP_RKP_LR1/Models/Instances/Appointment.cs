using System.Collections.Generic;

namespace HLP_RKP_LR3.Models
{
    public class Appointment
    {
        public static List<TableItem> items = new List<TableItem>();
        public static readonly string fileName = "xml/Приемы.xml";
        public static readonly string xmlElementName = "Приемы";
        public static Dictionary<string, ItemTypes> schema = new Dictionary<string, ItemTypes>()
        {
            { "Код", ItemTypes.num },
            { "Код_Пациента", ItemTypes.num },
            { "Код_Врача", ItemTypes.num },
            { "Дата", ItemTypes.date },
            { "Время", ItemTypes.str },
            { "Отчет", ItemTypes.str },
        };
    }
}
