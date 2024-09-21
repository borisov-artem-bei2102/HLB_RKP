﻿namespace HLP_RKP_LR1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDepartment = new System.Windows.Forms.DataGridView();
            this.departmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPosition = new System.Windows.Forms.DataGridView();
            this.positionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.positionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDoctor = new System.Windows.Forms.DataGridView();
            this.doctorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctodName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctorBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctorDepartmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctorPositionId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctorSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPatient = new System.Windows.Forms.DataGridView();
            this.patientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientPolis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientPassport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.patientSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvAppointment = new System.Windows.Forms.DataGridView();
            this.appointmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appointmentPatientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appointmentDoctorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appointmentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appointmentTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appointmentReport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.createWordBtn = new System.Windows.Forms.Button();
            this.createDiagramBtn = new System.Windows.Forms.Button();
            this.editTablesBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointment)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDepartment
            // 
            this.dgvDepartment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepartment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.departmentId,
            this.departmentName});
            this.dgvDepartment.Location = new System.Drawing.Point(9, 25);
            this.dgvDepartment.Name = "dgvDepartment";
            this.dgvDepartment.Size = new System.Drawing.Size(354, 178);
            this.dgvDepartment.TabIndex = 0;
            this.dgvDepartment.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepartment_CellEndEdit);
            // 
            // departmentId
            // 
            this.departmentId.FillWeight = 101.5228F;
            this.departmentId.HeaderText = "Код";
            this.departmentId.Name = "departmentId";
            // 
            // departmentName
            // 
            this.departmentName.FillWeight = 98.47716F;
            this.departmentName.HeaderText = "Название";
            this.departmentName.Name = "departmentName";
            // 
            // dgvPosition
            // 
            this.dgvPosition.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPosition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.positionId,
            this.positionName});
            this.dgvPosition.Location = new System.Drawing.Point(369, 25);
            this.dgvPosition.Name = "dgvPosition";
            this.dgvPosition.Size = new System.Drawing.Size(353, 178);
            this.dgvPosition.TabIndex = 1;
            this.dgvPosition.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPosition_CellEndEdit);
            // 
            // positionId
            // 
            this.positionId.FillWeight = 101.5228F;
            this.positionId.HeaderText = "Код";
            this.positionId.Name = "positionId";
            // 
            // positionName
            // 
            this.positionName.FillWeight = 98.47716F;
            this.positionName.HeaderText = "Название";
            this.positionName.Name = "positionName";
            // 
            // dgvDoctor
            // 
            this.dgvDoctor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDoctor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoctor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.doctorId,
            this.doctodName,
            this.doctorBirth,
            this.doctorDepartmentId,
            this.doctorPositionId,
            this.doctorSex});
            this.dgvDoctor.Location = new System.Drawing.Point(728, 25);
            this.dgvDoctor.Name = "dgvDoctor";
            this.dgvDoctor.Size = new System.Drawing.Size(710, 178);
            this.dgvDoctor.TabIndex = 2;
            this.dgvDoctor.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDoctor_CellEndEdit);
            // 
            // doctorId
            // 
            this.doctorId.FillWeight = 101.5228F;
            this.doctorId.HeaderText = "Код";
            this.doctorId.Name = "doctorId";
            // 
            // doctodName
            // 
            this.doctodName.FillWeight = 98.47716F;
            this.doctodName.HeaderText = "ФИО";
            this.doctodName.Name = "doctodName";
            // 
            // doctorBirth
            // 
            this.doctorBirth.HeaderText = "Дата рождения";
            this.doctorBirth.Name = "doctorBirth";
            // 
            // doctorDepartmentId
            // 
            this.doctorDepartmentId.HeaderText = "Код отделения";
            this.doctorDepartmentId.Name = "doctorDepartmentId";
            // 
            // doctorPositionId
            // 
            this.doctorPositionId.HeaderText = "Код должности";
            this.doctorPositionId.Name = "doctorPositionId";
            // 
            // doctorSex
            // 
            this.doctorSex.HeaderText = "Пол";
            this.doctorSex.Name = "doctorSex";
            // 
            // dgvPatient
            // 
            this.dgvPatient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPatient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPatient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.patientId,
            this.patientName,
            this.patientBirth,
            this.patientPolis,
            this.patientPassport,
            this.patientSex});
            this.dgvPatient.Location = new System.Drawing.Point(9, 234);
            this.dgvPatient.Name = "dgvPatient";
            this.dgvPatient.Size = new System.Drawing.Size(713, 178);
            this.dgvPatient.TabIndex = 3;
            this.dgvPatient.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatient_CellEndEdit);
            // 
            // patientId
            // 
            this.patientId.FillWeight = 101.5228F;
            this.patientId.HeaderText = "Код";
            this.patientId.Name = "patientId";
            // 
            // patientName
            // 
            this.patientName.FillWeight = 98.47716F;
            this.patientName.HeaderText = "ФИО";
            this.patientName.Name = "patientName";
            // 
            // patientBirth
            // 
            this.patientBirth.HeaderText = "Дата рождения";
            this.patientBirth.Name = "patientBirth";
            // 
            // patientPolis
            // 
            this.patientPolis.HeaderText = "Полис";
            this.patientPolis.Name = "patientPolis";
            // 
            // patientPassport
            // 
            this.patientPassport.HeaderText = "Паспорт";
            this.patientPassport.Name = "patientPassport";
            // 
            // patientSex
            // 
            this.patientSex.HeaderText = "Пол";
            this.patientSex.Name = "patientSex";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Отделения";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(366, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Должности";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(725, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Врачи";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl.Location = new System.Drawing.Point(6, 215);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(73, 16);
            this.lbl.TabIndex = 7;
            this.lbl.Text = "Пациенты";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(725, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Приемы у врача";
            // 
            // dgvAppointment
            // 
            this.dgvAppointment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAppointment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.appointmentId,
            this.appointmentPatientId,
            this.appointmentDoctorId,
            this.appointmentDate,
            this.appointmentTime,
            this.appointmentReport});
            this.dgvAppointment.Location = new System.Drawing.Point(728, 234);
            this.dgvAppointment.Name = "dgvAppointment";
            this.dgvAppointment.Size = new System.Drawing.Size(710, 178);
            this.dgvAppointment.TabIndex = 8;
            this.dgvAppointment.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAppointment_CellEndEdit);
            // 
            // appointmentId
            // 
            this.appointmentId.FillWeight = 101.5228F;
            this.appointmentId.HeaderText = "Код";
            this.appointmentId.Name = "appointmentId";
            // 
            // appointmentPatientId
            // 
            this.appointmentPatientId.FillWeight = 98.47716F;
            this.appointmentPatientId.HeaderText = "Код пациента";
            this.appointmentPatientId.Name = "appointmentPatientId";
            // 
            // appointmentDoctorId
            // 
            this.appointmentDoctorId.HeaderText = "Код врача";
            this.appointmentDoctorId.Name = "appointmentDoctorId";
            // 
            // appointmentDate
            // 
            this.appointmentDate.HeaderText = "Дата";
            this.appointmentDate.Name = "appointmentDate";
            // 
            // appointmentTime
            // 
            this.appointmentTime.HeaderText = "Время";
            this.appointmentTime.Name = "appointmentTime";
            // 
            // appointmentReport
            // 
            this.appointmentReport.HeaderText = "Отчет";
            this.appointmentReport.Name = "appointmentReport";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.Location = new System.Drawing.Point(9, 459);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(1429, 35);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // createWordBtn
            // 
            this.createWordBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createWordBtn.Location = new System.Drawing.Point(731, 500);
            this.createWordBtn.Name = "createWordBtn";
            this.createWordBtn.Size = new System.Drawing.Size(707, 35);
            this.createWordBtn.TabIndex = 16;
            this.createWordBtn.Text = "Создать отчёт";
            this.createWordBtn.UseVisualStyleBackColor = true;
            this.createWordBtn.Click += new System.EventHandler(this.createWordBtn_Click);
            // 
            // createDiagramBtn
            // 
            this.createDiagramBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createDiagramBtn.Location = new System.Drawing.Point(9, 500);
            this.createDiagramBtn.Name = "createDiagramBtn";
            this.createDiagramBtn.Size = new System.Drawing.Size(716, 35);
            this.createDiagramBtn.TabIndex = 17;
            this.createDiagramBtn.Text = "Создать диаграмму";
            this.createDiagramBtn.UseVisualStyleBackColor = true;
            this.createDiagramBtn.Click += new System.EventHandler(this.createDiagramBtn_Click);
            // 
            // editTablesBtn
            // 
            this.editTablesBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editTablesBtn.Location = new System.Drawing.Point(9, 418);
            this.editTablesBtn.Name = "editTablesBtn";
            this.editTablesBtn.Size = new System.Drawing.Size(1429, 35);
            this.editTablesBtn.TabIndex = 23;
            this.editTablesBtn.Text = "Редактировать таблицы";
            this.editTablesBtn.UseVisualStyleBackColor = true;
            this.editTablesBtn.Click += new System.EventHandler(this.editTablesBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1450, 545);
            this.Controls.Add(this.editTablesBtn);
            this.Controls.Add(this.createDiagramBtn);
            this.Controls.Add(this.createWordBtn);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvAppointment);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPatient);
            this.Controls.Add(this.dgvDoctor);
            this.Controls.Add(this.dgvPosition);
            this.Controls.Add(this.dgvDepartment);
            this.Name = "Form1";
            this.Text = "Учет работы поликлиники";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDepartment;
        private System.Windows.Forms.DataGridView dgvPosition;
        private System.Windows.Forms.DataGridView dgvDoctor;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctodName;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctorBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctorDepartmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctorPositionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctorSex;
        private System.Windows.Forms.DataGridView dgvPatient;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientName;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientPolis;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientPassport;
        private System.Windows.Forms.DataGridViewTextBoxColumn patientSex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionId;
        private System.Windows.Forms.DataGridViewTextBoxColumn positionName;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvAppointment;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentPatientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentDoctorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn appointmentReport;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button createWordBtn;
        private System.Windows.Forms.Button createDiagramBtn;
        private System.Windows.Forms.Button editTablesBtn;
    }
}

