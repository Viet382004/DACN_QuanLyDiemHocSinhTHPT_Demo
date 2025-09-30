using DACN_QuanLyDiemHocSinh_CallAPI.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;

namespace DACN_QuanLyDiemHocSinh_CallAPI
{
    public partial class Subject: Form
    {
        HttpClient client = new HttpClient();
        public Subject()
        {
            InitializeComponent();
        }

        public async Task GetAllSubject()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost/QLDHSTHPT/api/getallsubject");
            string js = await response.Content.ReadAsStringAsync();
            List<Subjects> data_getall = JsonConvert.DeserializeObject<List<Subjects>>(js);
            dataGridView2.DataSource = data_getall;
        }

        //Thêm môn học vào CSDL
        private async void button1_Click(object sender, EventArgs e)
        {
            Subjects sj = new Subjects
            {
                MaMon = txbSubjectID.Text,
                TenMon = txbSubjectName.Text,
                SoTiet = int.Parse(txbST.Text),
            };
            if (sj.MaMon == "" || sj.TenMon == "" || txbST.SelectedText.ToString()=="")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin môn học!", "Thông báo");
            }
            else {
            var json = JsonConvert.SerializeObject(sj, Formatting.Indented);
            var send = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost/QLDHS/api/addsubject", send);
            MessageBox.Show(await response.Content.ReadAsStringAsync(), "Thông báo");
            await GetAllSubject();
            }
        }

        //Cập nhật môn học vào CSDL
        private async void button3_Click(object sender, EventArgs e)
        {
            Subjects sj = new Subjects
            {
                MaMon = txbSubjectID.Text,
                TenMon = txbSubjectName.Text,
                SoTiet = int.Parse(txbST.Text),
            };
            var json = JsonConvert.SerializeObject(sj, Formatting.Indented);
            var send = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync($"http://localhost/QLDHSTHPT/api/updatesubject/{sj.MaMon}", send);
            MessageBox.Show(await response.Content.ReadAsStringAsync(), "Thông báo");
            await GetAllSubject();
        }


        //Xóa môn học khỏi CSDL
        private async void button4_Click(object sender, EventArgs e)
        {
            string sjid = txbSubjectID.Text;
            HttpResponseMessage response = await client.DeleteAsync($"http://localhost/QLDHSTHPT/api/deletesubject/{sjid}");
            MessageBox.Show(await response.Content.ReadAsStringAsync(), "Thông báo");
            await GetAllSubject();
        }


        private async void Subject_Load(object sender, EventArgs e)
        {
            await GetAllSubject();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Subjects sub = (Subjects)dataGridView2.CurrentRow.DataBoundItem;
            txbSubjectID.Text = sub.MaMon;
            txbSubjectName.Text = sub.TenMon;
            txbST.Text = sub.SoTiet.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Subjects sub = new Subjects();
            txbSubjectID.Text = "";
            txbSubjectName.Text = "";
            txbST.Text = "";
            txbSubjectID.Focus();
        }
    }
}
