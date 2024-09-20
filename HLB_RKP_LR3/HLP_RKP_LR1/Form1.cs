using HLP_RKP_LR1.Models;
using HLP_RKP_LR2;
using HLP_RKP_LR2.Models;
using HLP_RKP_LR2.Models.Tables;
using System;
using System.Windows.Forms;

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
            MessageBox.Show("Данные были успешно сохранены!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void delDepartmentRows_Click(object sender, EventArgs e)
        {
            TableMethods.DeleteRows(dgvDepartment, Department.items);
        }

        private void delPositionRows_Click(object sender, EventArgs e)
        {
            TableMethods.DeleteRows(dgvPosition, Position.items);
        }

        private void delDoctorRows_Click(object sender, EventArgs e)
        {
            TableMethods.DeleteRows(dgvDoctor, Doctor.items);
        }

        private void delPatientRows_Click(object sender, EventArgs e)
        {
            TableMethods.DeleteRows(dgvPatient, Patient.items);
        }

        private void delAppointmentRows_Click(object sender, EventArgs e)
        {
            TableMethods.DeleteRows(dgvAppointment, Appointment.items);
        }

        private void createWordBtn_Click(object sender, EventArgs e)
        {
            WordDocumentCreator.CreateDocument("./", "report.docx");
            MessageBox.Show("Успешно создали отчет!", "Создание отчета", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void createDiagramBtn_Click(object sender, EventArgs e)
        {
            ChartsForm form = new ChartsForm();
            form.ShowDialog();
        }

        private void addDepartmentsColBtn_Click(object sender, EventArgs e)
        {
            Form form = new AddColumnForm(dgvDepartment, Department.items, Department.schema);
            form.ShowDialog();
        }

        private void addPositionsColBtn_Click(object sender, EventArgs e)
        {
            Form form = new AddColumnForm(dgvPosition, Position.items, Position.schema);
            form.ShowDialog();
        }

        private void addDoctorsColBtn_Click(object sender, EventArgs e)
        {
            Form form = new AddColumnForm(dgvDoctor, Doctor.items, Doctor.schema);
            form.ShowDialog();
        }

        private void addPatientsColBtn_Click(object sender, EventArgs e)
        {
            Form form = new AddColumnForm(dgvPatient, Patient.items, Patient.schema);
            form.ShowDialog();
        }

        private void addAppointmentsColBtn_Click(object sender, EventArgs e)
        {
            Form form = new AddColumnForm(dgvAppointment, Appointment.items, Appointment.schema);
            form.ShowDialog();
        }
    }
}
