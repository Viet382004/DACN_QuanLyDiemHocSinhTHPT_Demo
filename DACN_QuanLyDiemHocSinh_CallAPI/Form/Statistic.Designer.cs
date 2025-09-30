namespace DACN_QuanLyDiemHocSinh_CallAPI
{
    partial class Statistic
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title6 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.tab = new System.Windows.Forms.TabControl();
            this.tpStudent = new System.Windows.Forms.TabPage();
            this.tpScore = new System.Windows.Forms.TabPage();
            this.chartBDCScore = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBDTScore = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnLoad = new System.Windows.Forms.Button();
            this.tab.SuspendLayout();
            this.tpStudent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBDCScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBDTScore)).BeginInit();
            this.SuspendLayout();
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tpStudent);
            this.tab.Controls.Add(this.tpScore);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Location = new System.Drawing.Point(0, 0);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(1169, 750);
            this.tab.TabIndex = 0;
            // 
            // tpStudent
            // 
            this.tpStudent.Controls.Add(this.btnLoad);
            this.tpStudent.Controls.Add(this.chartBDTScore);
            this.tpStudent.Controls.Add(this.chartBDCScore);
            this.tpStudent.Location = new System.Drawing.Point(4, 25);
            this.tpStudent.Name = "tpStudent";
            this.tpStudent.Padding = new System.Windows.Forms.Padding(3);
            this.tpStudent.Size = new System.Drawing.Size(1161, 721);
            this.tpStudent.TabIndex = 0;
            this.tpStudent.Text = "Thống kê sinh viên";
            this.tpStudent.UseVisualStyleBackColor = true;
            // 
            // tpScore
            // 
            this.tpScore.Location = new System.Drawing.Point(4, 25);
            this.tpScore.Name = "tpScore";
            this.tpScore.Padding = new System.Windows.Forms.Padding(3);
            this.tpScore.Size = new System.Drawing.Size(1037, 588);
            this.tpScore.TabIndex = 1;
            this.tpScore.Text = "Thống kê điểm";
            this.tpScore.UseVisualStyleBackColor = true;
            // 
            // chartBDCScore
            // 
            chartArea5.Name = "ChartArea1";
            this.chartBDCScore.ChartAreas.Add(chartArea5);
            this.chartBDCScore.Dock = System.Windows.Forms.DockStyle.Left;
            legend5.Name = "Legend1";
            this.chartBDCScore.Legends.Add(legend5);
            this.chartBDCScore.Location = new System.Drawing.Point(3, 3);
            this.chartBDCScore.Name = "chartBDCScore";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.LegendText = "Biểu Đồ Cột";
            series5.Name = "ChartBDCScore";
            this.chartBDCScore.Series.Add(series5);
            this.chartBDCScore.Size = new System.Drawing.Size(594, 715);
            this.chartBDCScore.TabIndex = 0;
            this.chartBDCScore.Text = "chart1";
            title5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            title5.ForeColor = System.Drawing.Color.Red;
            title5.Name = "Title1";
            title5.Text = "Biểu Đồ Cột Thông Tin Điểm Số";
            this.chartBDCScore.Titles.Add(title5);
            // 
            // chartBDTScore
            // 
            chartArea6.Name = "ChartArea1";
            this.chartBDTScore.ChartAreas.Add(chartArea6);
            this.chartBDTScore.Dock = System.Windows.Forms.DockStyle.Fill;
            legend6.Name = "Legend1";
            this.chartBDTScore.Legends.Add(legend6);
            this.chartBDTScore.Location = new System.Drawing.Point(597, 3);
            this.chartBDTScore.Name = "chartBDTScore";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series6.Legend = "Legend1";
            series6.Name = "ChartBDTScore";
            this.chartBDTScore.Series.Add(series6);
            this.chartBDTScore.Size = new System.Drawing.Size(561, 715);
            this.chartBDTScore.TabIndex = 1;
            this.chartBDTScore.Text = "chart2";
            title6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            title6.ForeColor = System.Drawing.Color.Red;
            title6.Name = "Title1";
            title6.Text = "Biểu Đồ Tròn";
            this.chartBDTScore.Titles.Add(title6);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnLoad.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnLoad.Location = new System.Drawing.Point(968, 618);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(125, 45);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // Statistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 750);
            this.Controls.Add(this.tab);
            this.Name = "Statistic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê";
            this.Load += new System.EventHandler(this.Statistic_Load);
            this.tab.ResumeLayout(false);
            this.tpStudent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartBDCScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBDTScore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tpStudent;
        private System.Windows.Forms.TabPage tpScore;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBDTScore;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBDCScore;
        private System.Windows.Forms.Button btnLoad;
    }
}