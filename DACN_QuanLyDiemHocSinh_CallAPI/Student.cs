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
using Newtonsoft.Json;
using System.Net.Http;
using DACN_QuanLyDiemHocSinh_CallAPI.Class;

namespace DACN_QuanLyDiemHocSinh_CallAPI
{
    public partial class Student: Form
    {
        HttpClient client = new HttpClient();
        public Student()
        {
            InitializeComponent();
        }

        public async Task GetAllStudent()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost/QLDHSTHPT/api/getallstudent");
            string js = await response.Content.ReadAsStringAsync();
            List<Students> data_getall = JsonConvert.DeserializeObject<List<Students>>(js);
            dataGridView1.DataSource = data_getall;
        }

        private async void Student_Load(object sender, EventArgs e)
        {
            await GetAllStudent();
        }

        private void dtpkDate_ValueChanged(object sender, EventArgs e)
        {
            dtpkDate.CustomFormat = "dd/MM/yyyy";

        }

        private void dtpkDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dtpkDate.CustomFormat = " ";
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            Students choose = dataGridView1.CurrentRow.DataBoundItem as Students;
            txbStudentID.Text = choose.MaHS;
            txbStudentName.Text = choose.HoTenHS;
            txbGender.Text = choose.GioiTinh;
            dtpkDate.Value = choose.NgaySinh;
            txbAddress.Text = choose.DiaChi;
            txbClassID.Text = choose.MaLop;
        }

        // Thêm học sinh
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            Students sv = new Students
            {
                MaHS = txbStudentID.Text,
                HoTenHS = txbStudentName.Text,
                GioiTinh = txbGender.Text,
                NgaySinh = dtpkDate.Value,
                DiaChi = txbAddress.Text,
                MaLop = txbClassID.Text
            };
            var json = JsonConvert.SerializeObject(sv, Formatting.Indented);
            var send = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost/QLDHSTHPT/api/addstudent", send);
            MessageBox.Show(await response.Content.ReadAsStringAsync(), "Thông báo");
            await GetAllStudent();
        }

        // Cập nhật học sinh
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            Students sv = new Students
            {
                MaHS = txbStudentID.Text,
                HoTenHS = txbStudentName.Text,
                GioiTinh = txbGender.Text,
                NgaySinh = dtpkDate.Value,
                DiaChi = txbAddress.Text,
                MaLop = txbClassID.Text
            };
            var json = JsonConvert.SerializeObject(sv, Formatting.Indented);
            var send = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync($"http://localhost/QLDHSTHPT/api/updatestudent/{sv.MaHS}", send);
            MessageBox.Show(await response.Content.ReadAsStringAsync(), "Thông báo");
            await GetAllStudent();
        }

        // Xóa học sinh theo mã

        private async void btnDelete_Click_1(object sender, EventArgs e)
        {
            string id = txbStudentID.Text;
            HttpResponseMessage response = await client.DeleteAsync($"http://localhost/QLDHSTHPT/api/deletestudent/{id}");
            MessageBox.Show(await response.Content.ReadAsStringAsync(), "Thông báo");
            await GetAllStudent();
        }

        // Tìm kiếm học sinh theo mã

        private async void btnFind_Click_1(object sender, EventArgs e)
        {
            string find_id = txbStudentID.Text;
            HttpResponseMessage response = await client.GetAsync($"http://localhost/QLDHSTHPT/api/getstudentbyid/{find_id}");
            string js = await response.Content.ReadAsStringAsync();
            List<Students> data_getall = JsonConvert.DeserializeObject<List<Students>>(js);
            dataGridView1.ReadOnly = true;
            if (data_getall.Count != 0)
            {
                MessageBox.Show($"Tìm được học sinh trong danh sách có mã "+ find_id, "Thông báo");
                dataGridView1.DataSource = data_getall;
            }
            else
            {
                MessageBox.Show("Không tìm thấy học sinh có mã " + find_id, "Thông báo");
                await GetAllStudent();

            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            txbStudentID.Text = "";
            txbStudentName.Text = "";
            txbGender.Text = "";
            dtpkDate.Value = DateTime.Now;
            txbAddress.Text = "";
            txbClassID.Text = "";
            txbStudentID.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await GetAllStudent();
        }
    }
}
