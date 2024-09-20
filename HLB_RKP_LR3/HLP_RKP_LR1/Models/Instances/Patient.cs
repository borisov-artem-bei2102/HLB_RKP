using HLP_RKP_LR2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace HLP_RKP_LR1.Models
{
    internal class Patient
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
