using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DACN_QuanLyDiemHocSinh_CallAPI.Class;
using Microsoft.Reporting.WinForms;

namespace DACN_QuanLyDiemHocSinh_CallAPI
{
    public partial class Report: Form
    {
        public Report()
        {
            InitializeComponent();
        }



        private async void Statistical_Load(object sender, EventArgs e)
        {
            try{

                StudentService service = new StudentService();
                var students = await service.GetAllStudent();

                reportViewer2.LocalReport.ReportEmbeddedResource = "DACN_QuanLyDiemHocSinh_CallAPI.Report1.rdlc";
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1"; // This name must match the DataSet name in the RDLC file
                rds.Value = students;
                reportViewer2.LocalReport.DataSources.Clear();
                reportViewer2.LocalReport.DataSources.Add(rds);
                this.reportViewer2.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            this.reportViewer2.RefreshReport();
        }

        private void reportViewer2_Load(object sender, EventArgs e)
        {

        }
    }
}
