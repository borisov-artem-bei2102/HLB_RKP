using HLP_RKP_LR1.Models;
using HLP_RKP_LR2.Models;
using HLP_RKP_LR2.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HLP_RKP_LR2
{
    public partial class AddColumnForm : Form
    {
        public Dictionary<string, ItemTypes> Schema {  get; set; }
        public List<TableItem> Items { get; set; }
        public DataGridView DGV { get; set; }

        public AddColumnForm(DataGridView dgv, List<TableItem> items, Dictionary<string, ItemTypes> schema)
        {
            InitializeComponent();
            Schema = schema;
            Items = items;
            DGV = dgv;
        }

        private void addColumnBtn_Click(object sender, EventArgs e)
        {
            string[] name = textBox1.Text.Trim().Split(' ');
            string formattedName = string.Join("_", name);
            string typeHuman = comboBox1.Text;

            if (formattedName == string.Empty || typeHuman == string.Empty)
            {
                MessageBox.Show("Введите корректные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string typeStr = TypedItem.HumanToStringDict[typeHuman];
            ItemTypes type = TypedItem.StringToTypeDict[typeStr];

            TablesActions.AddColumn(formattedName, type, DGV, Items, Schema);
            Close();
        }

        private void AddColumnForm_Load(object sender, EventArgs e)
        {
            string[] keys = TypedItem.HumanToStringDict.Keys.ToArray();
            comboBox1.Items.AddRange(keys);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
