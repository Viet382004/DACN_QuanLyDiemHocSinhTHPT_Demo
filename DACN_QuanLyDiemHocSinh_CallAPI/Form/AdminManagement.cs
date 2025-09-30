using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DACN_QuanLyDiemHocSinh_CallAPI
{
    public partial class AdminManagement: Form
    {
        public AdminManagement()
        {
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.ShowDialog();
        }
        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Subject subject = new Subject();
            subject.ShowDialog();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Score score = new Score();
            score.ShowDialog();
        }

        private void AdminManagement_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.ShowDialog();
        }


        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Statistic statistic = new Statistic();
            statistic.ShowDialog();
        }
    }
}
