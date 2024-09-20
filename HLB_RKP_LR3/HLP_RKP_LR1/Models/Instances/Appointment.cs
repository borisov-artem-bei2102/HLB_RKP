using HLP_RKP_LR2.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace HLP_RKP_LR1.Models
{
    internal class Appointment
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
