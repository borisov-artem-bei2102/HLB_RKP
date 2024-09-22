using System.Collections.Generic;

namespace HLP_RKP_LR3.Models
{
    public class Department
    {
        public static List<TableItem> items = new List<TableItem>();
        public static readonly string fileName = "xml/Отделения.xml";
        public static readonly string xmlElementName = "Отделение";
        public static Dictionary<string, ItemTypes> schema = new Dictionary<string, ItemTypes>()
        {
            { "Код", ItemTypes.num },
            { "Название", ItemTypes.str },
        };
    }
}
