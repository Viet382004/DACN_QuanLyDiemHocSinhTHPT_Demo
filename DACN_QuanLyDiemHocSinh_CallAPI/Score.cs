using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Http;
using Newtonsoft.Json;
using DACN_QuanLyDiemHocSinh_CallAPI.Class;

namespace DACN_QuanLyDiemHocSinh_CallAPI
{
    public partial class Score: Form
    {
        HttpClient client = new HttpClient();
        public Score()
        {
            InitializeComponent();
        }

        public async Task GetAllScore()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost/QLDHSTHPT/api/getscorefull");
            string js = await response.Content.ReadAsStringAsync();
            List<Scores> data_getall = JsonConvert.DeserializeObject<List<Scores>>(js);
            dataGridView1.DataSource = data_getall;
            cbxClassID.DataSource = data_getall.Select(s => s.MaHS).Distinct().ToList();
            cbxSubjectID.DataSource = data_getall.Select(s => s.MaMon).Distinct().ToList();

        }

        private async void Score_Load(object sender, EventArgs e)
        {
            await GetAllScore();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Scores choose = dataGridView1.CurrentRow.DataBoundItem as Scores;
            txbStudentID.Text = choose.MaHS;
            txbStudentName.Text = choose.HoTenHS;
            txbSubjectID.Text = choose.MaMon;
            txbSubjectName.Text = choose.TenMon;
            txbSemester.Text = choose.HocKy.ToString();
            txbYear.Text = choose.NamHoc.ToString();
            txb15p.Text = choose.DiemKT.ToString();
            txb45p.Text = choose.DiemGK.ToString();
            txbLastTest.Text = choose.DiemThi.ToString();
        }

        private void cbxClassID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
