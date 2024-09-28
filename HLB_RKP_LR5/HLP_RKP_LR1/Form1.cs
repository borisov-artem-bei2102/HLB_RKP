using System;
using System.Windows.Forms;
using HLP_RKP_LR2;
using HLP_RKP_LR2.Models.Utils;
using HLP_RKP_LR3.Models;

namespace HLP_RKP_LR1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dgvDepartment_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TableMethods.EditCell(dgvDepartment, e, Department.items, Department.schema);
        }

        private void dgvPosition_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TableMethods.EditCell(dgvPosition, e, Position.items, Position.schema);
        }

        private void dgvDoctor_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TableMethods.EditCell(dgvDoctor, e, Doctor.items, Doctor.schema);
        }

        private void dgvPatient_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TableMethods.EditCell(dgvPatient, e, Patient.items, Patient.schema);
        }

        private void dgvAppointment_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TableMethods.EditCell(dgvAppointment, e, Appointment.items, Appointment.schema);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TablesActions.InitAll(dgvPosition, dgvDepartment, dgvDoctor, dgvPatient, dgvAppointment);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TablesActions.SaveAll();
            
        }

        private void createWordBtn_Click(object sender, EventArgs e)
        {
            WordDocumentCreator.CreateDocument("./", "report.docx");
        }

        private void createDiagramBtn_Click(object sender, EventArgs e)
        {
            ChartsForm form = new ChartsForm();
            form.ShowDialog();
        }

        private void editTablesBtn_Click(object sender, EventArgs e)
        {
            Form editForm = new EditTable(dgvDepartment, dgvPosition, dgvDoctor, dgvPatient, dgvAppointment);
            editForm.ShowDialog();
        }

        private void deleteDepartmentBtn_Click(object sender, EventArgs e)
        {
            TableMethods.DeleteRows(dgvDepartment, Department.items);
        }

        private void deletePositionBtn_Click(object sender, EventArgs e)
        {
            TableMethods.DeleteRows(dgvPosition, Position.items);
        }

        private void deleteDoctorBtn_Click(object sender, EventArgs e)
        {
            TableMethods.DeleteRows(dgvDoctor, Doctor.items);
        }

        private void deletePatientBtn_Click(object sender, EventArgs e)
        {
            TableMethods.DeleteRows(dgvPatient, Patient.items);
        }

        private void deleteAppointmentBtn_Click(object sender, EventArgs e)
        {
            TableMethods.DeleteRows(dgvAppointment, Appointment.items);
        }

        private void loginPublicBtn_Click(object sender, EventArgs e)
        {
            HandleLoginButtons(loginPublicBtn);
            User.Login("Guest", ROLES.PUBLIC);
        }

        private void loginEmployeeBtn_Click(object sender, EventArgs e)
        {
            HandleLoginButtons(loginEmployeeBtn);
            User.Login("Employee", ROLES.EMPLOYEE);
        }

        private void loginAdminBtn_Click(object sender, EventArgs e)
        {
            HandleLoginButtons(loginAdminBtn);
            User.Login("Admin", ROLES.ADMIN);
        }

        private void HandleLoginButtons(Button pressedBtn)
        {
            loginPublicBtn.Enabled = true;
            loginEmployeeBtn.Enabled = true;
            loginAdminBtn.Enabled = true;
            pressedBtn.Enabled = false;
        }

        private void exportDBBtn_Click(object sender, EventArgs e)
        {
            TablesActions.ExportToDB();
        }

        private void importDBBtn_Click(object sender, EventArgs e)
        {
            TablesActions.ImportFromDB(dgvPosition, dgvDepartment, dgvDoctor, dgvPatient, dgvAppointment);
        }
    }
}
