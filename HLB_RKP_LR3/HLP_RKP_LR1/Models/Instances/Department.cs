using HLP_RKP_LR1.Models;
using HLP_RKP_LR2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace HLP_RKP_LR1
{
    internal class Department
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
