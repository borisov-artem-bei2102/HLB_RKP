using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using HLP_RKP_LR2.Models.Utils;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HLP_RKP_LR3.Models
{
    internal class TablesActions
    {
        public static void InitAll(DataGridView dgvPosition, DataGridView dgvDepartment, DataGridView dgvDoctor, DataGridView dgvPatient, DataGridView dgvAppointment)
        {
            TableMethods.Init(dgvPosition, Position.items, Position.schema, Position.fileName);
            TableMethods.Init(dgvDepartment, Department.items, Department.schema, Department.fileName);
            TableMethods.Init(dgvDoctor, Doctor.items, Doctor.schema, Doctor.fileName);
            TableMethods.Init(dgvPatient, Patient.items, Patient.schema, Patient.fileName);
            TableMethods.Init(dgvAppointment, Appointment.items, Appointment.schema, Appointment.fileName);
        }

        public static void SaveAll()
        {
            if (!User.IsAbleToMakeAction("Сохранение", ROLES.EMPLOYEE))
            {
                return;
            }

            TableMethods.Save(Position.fileName, Position.xmlElementName, Position.schema, Position.items);
            TableMethods.Save(Department.fileName, Department.xmlElementName, Department.schema, Department.items);
            TableMethods.Save(Doctor.fileName, Doctor.xmlElementName, Doctor.schema, Doctor.items);
            TableMethods.Save(Patient.fileName, Patient.xmlElementName, Patient.schema, Patient.items);
            TableMethods.Save(Appointment.fileName, Appointment.xmlElementName, Appointment.schema, Appointment.items);

            MessageBox.Show("Данные были успешно сохранены!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public static void AddColumn(string name, ItemTypes type, DataGridView dgv, List<TableItem> items, Dictionary<string, ItemTypes> schema)
        {
            if (!User.IsAbleToMakeAction("Добавление столбца", ROLES.ADMIN))
            {
                return;
            }

            try
            {
                TableMethods.UpdateTableOnAdd(name, type, items, schema);
                TableMethods.InitDGV(dgv, items, schema);
                MessageBox.Show("Добавлен новый столбец", "Добавление столбца", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.AddColumn(dgv.Name, name);
            }
            catch
            {
                MessageBox.Show("Ошибка удаления столбца", "Удаление столбца", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error($"{dgv.Name} - добавление столбца");
            }
        }

        public static void DeleteColumn(string name, DataGridView dgv, List<TableItem> items, Dictionary<string, ItemTypes> schema)
        {
            if (!User.IsAbleToMakeAction("Удаление столбца", ROLES.ADMIN))
            {
                return;
            }

            try
            {
                TableMethods.UpdateTableOnDelete(name, items, schema);
                TableMethods.InitDGV(dgv, items, schema);
                MessageBox.Show("Удален столбец", "Удаление столбца", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.DeleteColumn(dgv.Name, name);
            }
            catch
            {
                MessageBox.Show("Ошибка удаления столбца", "Удаление столбца", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error($"{dgv.Name} - удаление столбца \"{name}\"");
            }
        }

        public static void EditColumn(string oldColName, string newColName, ItemTypes newType, DataGridView dgv, List<TableItem> items, Dictionary<string, ItemTypes> schema)
        {
            if (!User.IsAbleToMakeAction("Изменение столбца", ROLES.ADMIN))
            {
                return;
            }

            try
            {
                TableMethods.UpdateTableOnEdit(oldColName, newColName, newType, items, schema);
                TableMethods.InitDGV(dgv, items, schema);
                MessageBox.Show("Изменен столбец", "Изменение столбца", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Logger.EditColumn(dgv.Name, oldColName, newColName, newType);
            }
            catch
            {
                MessageBox.Show("Ошибка изменения столбца", "Изменение столбца", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.Error($"{dgv.Name} - изменение столбца {oldColName}");
            }
        }

        public static void ExportToDB()
        {
            if (!User.IsAbleToMakeAction("Экспорт в БД", ROLES.EMPLOYEE))
            {
                return;
            }
            try
            {

                DBConnector.ClearOldData();

                DBConnector.ExportTable(Department.DBTableName, Department.schema, Department.items);
                DBConnector.ExportTable(Position.DBTableName, Position.schema, Position.items);
                DBConnector.ExportTable(Doctor.DBTableName, Doctor.schema, Doctor.items);
                DBConnector.ExportTable(Patient.DBTableName, Patient.schema, Patient.items);
                DBConnector.ExportTable(Appointment.DBTableName, Appointment.schema, Appointment.items);

                MessageBox.Show("Успешно экспортировали в БД!", "Экспорт в БД", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                MessageBox.Show("Ошибка при экспорте в БД!", "Экспорт в БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void ImportFromDB(DataGridView dgvPosition, DataGridView dgvDepartment, DataGridView dgvDoctor, DataGridView dgvPatient, DataGridView dgvAppointment)
        {
            if (!User.IsAbleToMakeAction("Экспорт в БД", ROLES.EMPLOYEE))
            {
                return;
            }

            try
            {
                DBConnector.ImportTable(Department.DBTableName, Department.schema, Department.items);
                TableMethods.InitDGV(dgvDepartment, Department.items, Department.schema);

                DBConnector.ImportTable(Position.DBTableName, Position.schema, Position.items);
                TableMethods.InitDGV(dgvPosition, Position.items, Position.schema);

                DBConnector.ImportTable(Doctor.DBTableName, Doctor.schema, Doctor.items);
                TableMethods.InitDGV(dgvDoctor, Doctor.items, Doctor.schema);

                DBConnector.ImportTable(Patient.DBTableName, Patient.schema, Patient.items);
                TableMethods.InitDGV(dgvPatient, Patient.items, Patient.schema);

                DBConnector.ImportTable(Appointment.DBTableName, Appointment.schema, Appointment.items);
                TableMethods.InitDGV(dgvAppointment, Appointment.items, Appointment.schema);

                MessageBox.Show("Успешно импортировали из БД!", "Импорт из БД", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                MessageBox.Show("Ошибка при импорте из БД!", "Импорт из БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
