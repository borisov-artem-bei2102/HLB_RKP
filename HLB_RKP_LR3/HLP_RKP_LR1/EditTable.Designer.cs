namespace HLP_RKP_LR2
{
    partial class EditTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableNameCBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.addColBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addColCBox = new System.Windows.Forms.ComboBox();
            this.addColTBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.editColBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.editColCBox = new System.Windows.Forms.ComboBox();
            this.editColTBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.deleteColBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.deleteColCBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.editColTypeCBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tableNameCBox
            // 
            this.tableNameCBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableNameCBox.FormattingEnabled = true;
            this.tableNameCBox.Location = new System.Drawing.Point(230, 52);
            this.tableNameCBox.Name = "tableNameCBox";
            this.tableNameCBox.Size = new System.Drawing.Size(311, 24);
            this.tableNameCBox.TabIndex = 0;
            this.tableNameCBox.SelectedIndexChanged += new System.EventHandler(this.tableNameCBox_SelectedIndexChanged);
            this.tableNameCBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tableNameCBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите таблицу";
            // 
            // addColBtn
            // 
            this.addColBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addColBtn.Location = new System.Drawing.Point(43, 260);
            this.addColBtn.Name = "addColBtn";
            this.addColBtn.Size = new System.Drawing.Size(177, 33);
            this.addColBtn.TabIndex = 9;
            this.addColBtn.Text = "Добавить";
            this.addColBtn.UseVisualStyleBackColor = true;
            this.addColBtn.Click += new System.EventHandler(this.addColBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Тип данных";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Название";
            // 
            // addColCBox
            // 
            this.addColCBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addColCBox.FormattingEnabled = true;
            this.addColCBox.Location = new System.Drawing.Point(43, 230);
            this.addColCBox.Name = "addColCBox";
            this.addColCBox.Size = new System.Drawing.Size(177, 24);
            this.addColCBox.TabIndex = 6;
            this.addColCBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.addColCBox_KeyPress);
            // 
            // addColTBox
            // 
            this.addColTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addColTBox.Location = new System.Drawing.Point(43, 187);
            this.addColTBox.Name = "addColTBox";
            this.addColTBox.Size = new System.Drawing.Size(177, 22);
            this.addColTBox.TabIndex = 5;
            this.addColTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.addColTBox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(42, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "Добавить столбец";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(293, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(179, 24);
            this.label5.TabIndex = 16;
            this.label5.Text = "Изменить столбец";
            // 
            // editColBtn
            // 
            this.editColBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editColBtn.Location = new System.Drawing.Point(294, 304);
            this.editColBtn.Name = "editColBtn";
            this.editColBtn.Size = new System.Drawing.Size(177, 33);
            this.editColBtn.TabIndex = 15;
            this.editColBtn.Text = "Изменить";
            this.editColBtn.UseVisualStyleBackColor = true;
            this.editColBtn.Click += new System.EventHandler(this.editColBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(294, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Столбец";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(294, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Название";
            // 
            // editColCBox
            // 
            this.editColCBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editColCBox.FormattingEnabled = true;
            this.editColCBox.Location = new System.Drawing.Point(294, 185);
            this.editColCBox.Name = "editColCBox";
            this.editColCBox.Size = new System.Drawing.Size(177, 24);
            this.editColCBox.TabIndex = 12;
            this.editColCBox.SelectedIndexChanged += new System.EventHandler(this.editColCBox_SelectedIndexChanged);
            this.editColCBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editColCBox_KeyPress);
            // 
            // editColTBox
            // 
            this.editColTBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editColTBox.Location = new System.Drawing.Point(294, 276);
            this.editColTBox.Name = "editColTBox";
            this.editColTBox.Size = new System.Drawing.Size(177, 22);
            this.editColTBox.TabIndex = 11;
            this.editColTBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editColTBox_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(556, 136);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 24);
            this.label8.TabIndex = 22;
            this.label8.Text = "Удалить столбец";
            // 
            // deleteColBtn
            // 
            this.deleteColBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteColBtn.Location = new System.Drawing.Point(557, 215);
            this.deleteColBtn.Name = "deleteColBtn";
            this.deleteColBtn.Size = new System.Drawing.Size(177, 33);
            this.deleteColBtn.TabIndex = 21;
            this.deleteColBtn.Text = "Удалить";
            this.deleteColBtn.UseVisualStyleBackColor = true;
            this.deleteColBtn.Click += new System.EventHandler(this.deleteColBtn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(557, 169);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Столбец";
            // 
            // deleteColCBox
            // 
            this.deleteColCBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.deleteColCBox.FormattingEnabled = true;
            this.deleteColCBox.Location = new System.Drawing.Point(557, 185);
            this.deleteColCBox.Name = "deleteColCBox";
            this.deleteColCBox.Size = new System.Drawing.Size(177, 24);
            this.deleteColCBox.TabIndex = 18;
            this.deleteColCBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.deleteColCBox_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(294, 216);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Тип данных";
            // 
            // editColTypeCBox
            // 
            this.editColTypeCBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.editColTypeCBox.FormattingEnabled = true;
            this.editColTypeCBox.Location = new System.Drawing.Point(294, 230);
            this.editColTypeCBox.Name = "editColTypeCBox";
            this.editColTypeCBox.Size = new System.Drawing.Size(177, 24);
            this.editColTypeCBox.TabIndex = 23;
            this.editColTypeCBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.editColTypeCBox_KeyPress);
            // 
            // EditTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 393);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.editColTypeCBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.deleteColBtn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.deleteColCBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.editColBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.editColCBox);
            this.Controls.Add(this.editColTBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.addColBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addColCBox);
            this.Controls.Add(this.addColTBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableNameCBox);
            this.Name = "EditTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование таблиц";
            this.Load += new System.EventHandler(this.EditTable_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox tableNameCBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addColBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox addColCBox;
        private System.Windows.Forms.TextBox addColTBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button editColBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox editColCBox;
        private System.Windows.Forms.TextBox editColTBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button deleteColBtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox deleteColCBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox editColTypeCBox;
    }
}