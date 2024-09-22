using System;
using System.Linq;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Spreadsheet;
using HLP_RKP_LR2.Models.Utils;
using HLP_RKP_LR3.Models;

namespace HLP_RKP_LR2
{
    public partial class EditTable : Form
    {
        public const string departmentsTableName = "Отделения";
        public const string positionsTableName = "Должности";
        public const string doctorsTableName = "Врачи";
        public const string patientsTableName = "Пациенты";
        public const string appointmentsTableName = "Приемы у врача";

        public DataGridView DGVDepartments { get; set; }
        public DataGridView DGVPositions { get; set; }
        public DataGridView DGVDoctors { get; set; }
        public DataGridView DGVPatients { get; set; }
        public DataGridView DGVAppointments { get; set; }

        public EditTable(DataGridView dgvDepartments, DataGridView dgvPositions, DataGridView dgvDoctors, DataGridView dgvPatients, DataGridView dgvAppointments)
        {
            InitializeComponent();
            tableNameCBox.Items.AddRange(new string[] { departmentsTableName, positionsTableName, doctorsTableName, patientsTableName, appointmentsTableName });
            DGVDepartments = dgvDepartments;
            DGVPositions = dgvPositions;
            DGVDoctors = dgvDoctors;
            DGVPatients = dgvPatients;
            DGVAppointments = dgvAppointments;
        }

        private void editColCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string chosenCol = editColCBox.Text;
            string tableName = tableNameCBox.Text;

            string currentColType = TypedItem.TypeToHumanDict[ItemTypes.str];

            switch (tableName)
            {
                case departmentsTableName:
                    currentColType = TypedItem.TypeToHumanDict[Department.schema[chosenCol]];
                    break;
                case positionsTableName:
                    currentColType = TypedItem.TypeToHumanDict[Position.schema[chosenCol]];
                    break;
                case doctorsTableName:
                    currentColType = TypedItem.TypeToHumanDict[Doctor.schema[chosenCol]];
                    break;
                case patientsTableName:
                    currentColType = TypedItem.TypeToHumanDict[Patient.schema[chosenCol]];
                    break;
                case appointmentsTableName:
                    currentColType = TypedItem.TypeToHumanDict[Appointment.schema[chosenCol]];
                    break;
            }

            editColTypeCBox.Text = currentColType;
            editColTBox.Text = chosenCol;
        }

        private void tableNameCBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCBoxesValues();
        }

        private void UpdateCBoxesValues()
        {
            string tableName = tableNameCBox.Text;

            editColCBox.Text = string.Empty;
            editColCBox.Items.Clear();

            deleteColCBox.Text = string.Empty;
            deleteColCBox.Items.Clear();

            switch (tableName)
            {
                case departmentsTableName:
                    editColCBox.Items.AddRange(Department.schema.Keys.ToArray());
                    deleteColCBox.Items.AddRange(Department.schema.Keys.ToArray());
                    break;
                case positionsTableName:
                    editColCBox.Items.AddRange(Position.schema.Keys.ToArray());
                    deleteColCBox.Items.AddRange(Position.schema.Keys.ToArray());
                    break;
                case doctorsTableName:
                    editColCBox.Items.AddRange(Doctor.schema.Keys.ToArray());
                    deleteColCBox.Items.AddRange(Doctor.schema.Keys.ToArray());
                    break;
                case patientsTableName:
                    editColCBox.Items.AddRange(Patient.schema.Keys.ToArray());
                    deleteColCBox.Items.AddRange(Patient.schema.Keys.ToArray());
                    break;
                case appointmentsTableName:
                    editColCBox.Items.AddRange(Appointment.schema.Keys.ToArray());
                    deleteColCBox.Items.AddRange(Appointment.schema.Keys.ToArray());
                    break;
            }
        }

        private void EditTable_Load(object sender, EventArgs e)
        {
            string[] keys = TypedItem.HumanToStringDict.Keys.ToArray();
            addColCBox.Items.AddRange(keys);
            addColCBox.Text = keys[0];
            editColTypeCBox.Items.AddRange(keys);
        }

        private void addColTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void addColBtn_Click(object sender, EventArgs e)
        {
            string tableName = tableNameCBox.Text;
            if (tableName == string.Empty)
            {
                MessageBox.Show("Выберите таблицу для редактирования", "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string formattedName = Formatters.FormatColumnName(addColTBox.Text);

            if (formattedName == string.Empty)
            {
                MessageBox.Show("Введите корректные данные", "Ошибка добавления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ItemTypes type = TypedItem.HumanToTypeDict[addColCBox.Text];

            switch (tableName)
            {
                case departmentsTableName:
                    TablesActions.AddColumn(formattedName, type, DGVDepartments, Department.items, Department.schema);
                    break;
                case positionsTableName:
                    TablesActions.AddColumn(formattedName, type, DGVPositions, Position.items, Position.schema);
                    break;
                case doctorsTableName:
                    TablesActions.AddColumn(formattedName, type, DGVDoctors, Doctor.items, Doctor.schema);
                    break;
                case patientsTableName:
                    TablesActions.AddColumn(formattedName, type, DGVPatients, Patient.items, Patient.schema);
                    break;
                case appointmentsTableName:
                    TablesActions.AddColumn(formattedName, type, DGVAppointments, Appointment.items, Appointment.schema);
                    break;
            }

            UpdateCBoxesValues();
        }

        private void deleteColBtn_Click(object sender, EventArgs e)
        {
            string tableName = tableNameCBox.Text;
            if (tableName == string.Empty)
            {
                MessageBox.Show("Выберите таблицу для редактирования", "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string colName = deleteColCBox.Text;

            if (colName == string.Empty)
            {
                MessageBox.Show("Выберите столбец", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (tableName)
            {
                case departmentsTableName:
                    TablesActions.DeleteColumn(colName, DGVDepartments, Department.items, Department.schema);
                    break;
                case positionsTableName:
                    TablesActions.DeleteColumn(colName, DGVPositions, Position.items, Position.schema);
                    break;
                case doctorsTableName:
                    TablesActions.DeleteColumn(colName, DGVDoctors, Doctor.items, Doctor.schema);
                    break;
                case patientsTableName:
                    TablesActions.DeleteColumn(colName, DGVPatients, Patient.items, Patient.schema);
                    break;
                case appointmentsTableName:
                    TablesActions.DeleteColumn(colName, DGVAppointments, Appointment.items, Appointment.schema);
                    break;
            }

            UpdateCBoxesValues();
        }

        private void editColBtn_Click(object sender, EventArgs e)
        {
            string tableName = tableNameCBox.Text;
            if (tableName == string.Empty)
            {
                MessageBox.Show("Выберите таблицу для редактирования", "Ошибка редактирования", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string oldColName = editColCBox.Text;
            string newColName = Formatters.FormatColumnName(editColTBox.Text);

            if (oldColName == string.Empty || newColName == string.Empty)
            {
                MessageBox.Show("Введите корректные данные", "Ошибка изменения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ItemTypes newType = TypedItem.HumanToTypeDict[editColTypeCBox.Text];

            switch (tableName)
            {
                case departmentsTableName:
                    TablesActions.EditColumn(oldColName, newColName, newType, DGVDepartments, Department.items, Department.schema);
                    break;
                case positionsTableName:
                    TablesActions.EditColumn(oldColName, newColName, newType, DGVPositions, Position.items, Position.schema);
                    break;
                case doctorsTableName:
                    TablesActions.EditColumn(oldColName, newColName, newType, DGVDoctors, Doctor.items, Doctor.schema);
                    break;
                case patientsTableName:
                    TablesActions.EditColumn(oldColName, newColName, newType, DGVPatients, Patient.items, Patient.schema);
                    break;
                case appointmentsTableName:
                    TablesActions.EditColumn(oldColName, newColName, newType, DGVAppointments, Appointment.items, Appointment.schema);
                    break;
            }

            UpdateCBoxesValues();
        }

        private void tableNameCBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void addColCBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void editColCBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void editColTypeCBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void deleteColCBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void editColTBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
