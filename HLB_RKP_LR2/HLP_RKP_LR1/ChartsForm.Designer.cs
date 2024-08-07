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
            this.SuspendLayout();
            // 
            // cartesianChart1
            // 
            this.cartesianChart1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cartesianChart1.Location = new System.Drawing.Point(12, 12);
            this.cartesianChart1.Name = "cartesianChart1";
            this.cartesianChart1.Size = new System.Drawing.Size(374, 371);
            this.cartesianChart1.TabIndex = 0;
            // 
            // pieChart1
            // 
            this.pieChart1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pieChart1.InitialRotation = 0D;
            this.pieChart1.IsClockwise = true;
            this.pieChart1.Location = new System.Drawing.Point(772, 12);
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
            this.cartesianChart2.Location = new System.Drawing.Point(392, 12);
            this.cartesianChart2.Name = "cartesianChart2";
            this.cartesianChart2.Size = new System.Drawing.Size(374, 371);
            this.cartesianChart2.TabIndex = 2;
            // 
            // ChartsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1157, 397);
            this.Controls.Add(this.cartesianChart2);
            this.Controls.Add(this.pieChart1);
            this.Controls.Add(this.cartesianChart1);
            this.Name = "ChartsForm";
            this.Text = "ChartsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        private LiveChartsCore.SkiaSharpView.WinForms.PieChart pieChart1;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart2;
    }
}