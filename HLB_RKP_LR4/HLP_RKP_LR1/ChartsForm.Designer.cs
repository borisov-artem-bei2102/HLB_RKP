namespace HLP_RKP_LR2
{
    partial class ChartsForm
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
            this.cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            this.pieChart1 = new LiveChartsCore.SkiaSharpView.WinForms.PieChart();
            this.cartesianChart2 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cartesianChart1.Location = new System.Drawing.Point(12, 37);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(374, 371);
            this.cartesianChart1.TabIndex = 0;
            // 
            // pieChart1
            // 
            this.pieChart1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pieChart1.InitialRotation = 0D;
            this.pieChart1.IsClockwise = true;
            this.pieChart1.Location = new System.Drawing.Point(772, 37);
            this.pieChart1.MaxAngle = 360D;
            this.pieChart1.MaxValue = null;
            this.pieChart1.MinValue = 0D;
            this.pieChart1.Name = "pieChart1";
            this.pieChart1.Size = new System.Drawing.Size(374, 371);
            this.pieChart1.TabIndex = 1;
            this.pieChart1.Total = null;
            // 
            // cartesianChart2
            // 
            this.cartesianChart2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cartesianChart2.Location = new System.Drawing.Point(392, 37);
            this.cartesianChart2.Name = "cartesianChart2";
            this.cartesianChart2.Size = new System.Drawing.Size(374, 371);
            this.cartesianChart2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Кол-во пациентов по годам рождения";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(446, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Кол-во приемов по датам";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(802, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Статистика пациентов по полу";
            // 
            // ChartsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 421);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cartesianChart2);
            this.Controls.Add(this.pieChart1);
            this.Controls.Add(this.cartesianChart1);
            this.Name = "ChartsForm";
            this.Text = "ChartsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        private LiveChartsCore.SkiaSharpView.WinForms.PieChart pieChart1;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}