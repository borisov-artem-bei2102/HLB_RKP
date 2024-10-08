﻿using HLP_RKP_LR1.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HLP_RKP_LR1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Department.Load();
            Position.Load();
            Doctor.Load();
            Patient.Load();
            Appointment.Load();
        }

        private void dgvDepartment_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Department.Edit(dgvDepartment, e);
        }

        private void dgvPosition_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Position.Edit(dgvPosition, e);
        }

        private void dgvDoctor_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Doctor.Edit(dgvDoctor, e);
        }

        private void dgvPatient_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Patient.Edit(dgvPatient, e);
        }

        private void dgvAppointment_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Appointment.Edit(dgvAppointment, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Department.Init(dgvDepartment);
            Position.Init(dgvPosition);
            Doctor.Init(dgvDoctor);
            Patient.Init(dgvPatient);
            Appointment.Init(dgvAppointment);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Department.Save();
            Position.Save();
            Doctor.Save();
            Patient.Save();
            Appointment.Save();
            MessageBox.Show("Данные были успешно сохранены!", "Сохранение", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void delDepartmentRows_Click(object sender, EventArgs e)
        {
            Department.DeleteRows(dgvDepartment);
        }

        private void delPositionRows_Click(object sender, EventArgs e)
        {
            Position.DeleteRows(dgvPosition);
        }

        private void delDoctorRows_Click(object sender, EventArgs e)
        {
            Doctor.DeleteRows(dgvDoctor);
        }

        private void delPatientRows_Click(object sender, EventArgs e)
        {
            Patient.DeleteRows(dgvPatient);
        }

        private void delAppointmentRows_Click(object sender, EventArgs e)
        {
            Appointment.DeleteRows(dgvAppointment);
        }
    }
}
