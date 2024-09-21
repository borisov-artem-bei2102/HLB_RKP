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
            TableMethods.Save(Position.fileName, Position.xmlElementName, Position.schema, Position.items);
            TableMethods.Save(Department.fileName, Department.xmlElementName, Department.schema, Department.items);
            TableMethods.Save(Doctor.fileName, Doctor.xmlElementName, Doctor.schema, Doctor.items);
            TableMethods.Save(Patient.fileName, Patient.xmlElementName, Patient.schema, Patient.items);
            TableMethods.Save(Appointment.fileName, Appointment.xmlElementName, Appointment.schema, Appointment.items);
        }

        public static void AddColumn(string name, ItemTypes type, DataGridView dgv, List<TableItem> items, Dictionary<string, ItemTypes> schema)
        {
            
            TableMethods.UpdateTableOnAdd(name, type, items, schema);
            TableMethods.InitDGV(dgv, items, schema);
        }

        public static void DeleteColumn(string name, DataGridView dgv, List<TableItem> items, Dictionary<string, ItemTypes> schema)
        {
            
            TableMethods.UpdateTableOnDelete(name, items, schema);
            TableMethods.InitDGV(dgv, items, schema);
        }

        public static void EditColumn(string oldColName, string newColName, ItemTypes newType, DataGridView dgv, List<TableItem> items, Dictionary<string, ItemTypes> schema)
        {
            
            TableMethods.UpdateTableOnEdit(oldColName, newColName, newType, items, schema);
            TableMethods.InitDGV(dgv, items, schema);
        }
    }
}
