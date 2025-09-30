using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DACN_QuanLyDiemHocSinh_CallAPI
{
    public partial class Statistic: Form
    {
        public Statistic()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

        }

        private void Statistic_Load(object sender, EventArgs e)
        {
            chartBDCScore.Series["ChartBDCScore"].Points.Add(3);
            chartBDCScore.Series["ChartBDCScore"].Points[0].Label = "3";
            chartBDCScore.Series["ChartBDCScore"].Points[0].Color = Color.Blue;
            chartBDCScore.Series["ChartBDCScore"].Points[0].AxisLabel = "Điểm Toán";

            chartBDCScore.Series["ChartBDCScore"].Points.Add(5);
            chartBDCScore.Series["ChartBDCScore"].Points[1].Label = "5";
            chartBDCScore.Series["ChartBDCScore"].Points[1].Color = Color.Blue;
            chartBDCScore.Series["ChartBDCScore"].Points[1].AxisLabel = "Điểm Văn";

            chartBDCScore.Series["ChartBDCScore"].Points.Add(7);
            chartBDCScore.Series["ChartBDCScore"].Points[2].Label = "7";
            chartBDCScore.Series["ChartBDCScore"].Points[2].Color = Color.Blue;
            chartBDCScore.Series["ChartBDCScore"].Points[2].AxisLabel = "Điểm Anh";

            chartBDCScore.Series["ChartBDCScore"].Points.Add(8);
            chartBDCScore.Series["ChartBDCScore"].Points[3].Label = "8";
            chartBDCScore.Series["ChartBDCScore"].Points[3].Color = Color.Blue;
            chartBDCScore.Series["ChartBDCScore"].Points[3].AxisLabel = "Điểm Lý";

            chartBDCScore.Series["ChartBDCScore"].Points.Add(9);
            chartBDCScore.Series["ChartBDCScore"].Points[4].Label = "9";
            chartBDCScore.Series["ChartBDCScore"].Points[4].Color = Color.Blue;
            chartBDCScore.Series["ChartBDCScore"].Points[4].AxisLabel = "Điểm Hóa";
        }
    }
}
