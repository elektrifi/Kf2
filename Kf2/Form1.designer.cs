namespace Kalman_Filter
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Start_BTN = new System.Windows.Forms.Button();
            this.CalculatedData_LBL = new System.Windows.Forms.Label();
            this.CalculatedPrediction_LBL = new System.Windows.Forms.Label();
            this.KalmanCorrection_LBL = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Start_BTN2 = new System.Windows.Forms.Button();
            this.timmer_UPDN = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timmer_UPDN)).BeginInit();
            this.SuspendLayout();
            // 
            // Start_BTN
            // 
            this.Start_BTN.Location = new System.Drawing.Point(12, 9);
            this.Start_BTN.Name = "Start_BTN";
            this.Start_BTN.Size = new System.Drawing.Size(97, 30);
            this.Start_BTN.TabIndex = 2;
            this.Start_BTN.Text = "Start Sine Wave";
            this.Start_BTN.UseVisualStyleBackColor = true;
            this.Start_BTN.Click += new System.EventHandler(this.Start_BTN_Click);
            // 
            // CalculatedData_LBL
            // 
            this.CalculatedData_LBL.AutoSize = true;
            this.CalculatedData_LBL.Location = new System.Drawing.Point(241, 9);
            this.CalculatedData_LBL.Name = "CalculatedData_LBL";
            this.CalculatedData_LBL.Size = new System.Drawing.Size(86, 13);
            this.CalculatedData_LBL.TabIndex = 3;
            this.CalculatedData_LBL.Text = "Calculated Data:";
            // 
            // CalculatedPrediction_LBL
            // 
            this.CalculatedPrediction_LBL.AutoSize = true;
            this.CalculatedPrediction_LBL.Location = new System.Drawing.Point(241, 41);
            this.CalculatedPrediction_LBL.Name = "CalculatedPrediction_LBL";
            this.CalculatedPrediction_LBL.Size = new System.Drawing.Size(110, 13);
            this.CalculatedPrediction_LBL.TabIndex = 4;
            this.CalculatedPrediction_LBL.Text = "Calculated Prediction:";
            // 
            // KalmanCorrection_LBL
            // 
            this.KalmanCorrection_LBL.AutoSize = true;
            this.KalmanCorrection_LBL.Location = new System.Drawing.Point(444, 9);
            this.KalmanCorrection_LBL.Name = "KalmanCorrection_LBL";
            this.KalmanCorrection_LBL.Size = new System.Drawing.Size(96, 13);
            this.KalmanCorrection_LBL.TabIndex = 5;
            this.KalmanCorrection_LBL.Text = "Kalman Correction:";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 67);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "The Data";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Kalman Prediction";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(701, 393);
            this.chart1.TabIndex = 6;
            this.chart1.Text = "chart1";
            // 
            // Start_BTN2
            // 
            this.Start_BTN2.Location = new System.Drawing.Point(115, 9);
            this.Start_BTN2.Name = "Start_BTN2";
            this.Start_BTN2.Size = new System.Drawing.Size(97, 30);
            this.Start_BTN2.TabIndex = 7;
            this.Start_BTN2.Text = "Start Random";
            this.Start_BTN2.UseVisualStyleBackColor = true;
            this.Start_BTN2.Click += new System.EventHandler(this.Start_BTN2_Click);
            // 
            // timmer_UPDN
            // 
            this.timmer_UPDN.Location = new System.Drawing.Point(115, 41);
            this.timmer_UPDN.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.timmer_UPDN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timmer_UPDN.Name = "timmer_UPDN";
            this.timmer_UPDN.Size = new System.Drawing.Size(97, 20);
            this.timmer_UPDN.TabIndex = 8;
            this.timmer_UPDN.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.timmer_UPDN.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Interval";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 472);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timmer_UPDN);
            this.Controls.Add(this.Start_BTN2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.KalmanCorrection_LBL);
            this.Controls.Add(this.CalculatedPrediction_LBL);
            this.Controls.Add(this.CalculatedData_LBL);
            this.Controls.Add(this.Start_BTN);
            this.Name = "Form1";
            this.Text = "Cosneta KF2";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timmer_UPDN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start_BTN;
        private System.Windows.Forms.Label CalculatedData_LBL;
        private System.Windows.Forms.Label CalculatedPrediction_LBL;
        private System.Windows.Forms.Label KalmanCorrection_LBL;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button Start_BTN2;
        private System.Windows.Forms.NumericUpDown timmer_UPDN;
        private System.Windows.Forms.Label label1;
    }
}

