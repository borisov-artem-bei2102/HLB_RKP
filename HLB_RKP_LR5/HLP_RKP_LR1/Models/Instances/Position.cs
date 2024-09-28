using System.Collections.Generic;

namespace HLP_RKP_LR3.Models
{
    public class Position
    {
        public static List<TableItem> items = new List<TableItem>();
        public static readonly string fileName = "xml/Должности.xml";
        public static readonly string xmlElementName = "Должность";
        public static readonly string DBTableName = "positions";
        public static Dictionary<string, ItemTypes> schema = new Dictionary<string, ItemTypes>()
        {
            { "Код", ItemTypes.num },
            { "Название", ItemTypes.str },
        };
    }
}
