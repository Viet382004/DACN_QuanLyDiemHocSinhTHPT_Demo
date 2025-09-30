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
            txbGender.Text = choose.GioiTinh;
            txbClassID.Text = choose.MaLop;
            txbClassName.Text = choose.TenLop;
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
        

        // Tìm kiếm điểm học sinh theo mã học sinh
        private async void btnFindStuID_Click_1(object sender, EventArgs e)
        {
            string find_id = txbStudentID.Text;
            HttpResponseMessage response = await client.GetAsync($"http://localhost/QLDHSTHPT/api/getscorebymahs/{find_id}");
            string js = await response.Content.ReadAsStringAsync();
            List<Scores> data_getall = JsonConvert.DeserializeObject<List<Scores>>(js);
            dataGridView1.ReadOnly = true;
            if (data_getall.Count != 0)
            {
                MessageBox.Show($"Tìm được danh sách điểm của học sinh có mã {find_id} ! ", "Thông báo");
                dataGridView1.DataSource = data_getall;
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu học sinh !" + find_id, "Thông báo");
                await GetAllScore();

            }
        }

        //Tìm kiếm điểm học sinh theo mã môn học 
        private async void btnFindSubID_Click(object sender, EventArgs e)
        {
            string find_id = txbSubjectID.Text;
            HttpResponseMessage response = await client.GetAsync($"http://localhost/QLDHSTHPT/api/getscorebymamon/{find_id}");
            string js = await response.Content.ReadAsStringAsync();
            List<Scores> data_getall = JsonConvert.DeserializeObject<List<Scores>>(js);
            dataGridView1.ReadOnly = true;
            if (data_getall.Count != 0)
            {
                MessageBox.Show($"Tìm được danh sách điểm của học sinh với mã môn {find_id} ! ", "Thông báo");
                dataGridView1.DataSource = data_getall;
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu của môn học !" + find_id, "Thông báo");
                await GetAllScore();
            }
        }

        // Tìm kiếm điểm học sinh theo mã lớp 
        private async void btnFindbyMaLop_Click(object sender, EventArgs e)
        {
            string find_id = txbClassID.Text;
            HttpResponseMessage response = await client.GetAsync($"http://localhost/QLDHSTHPT/api/getscorebymalop/{find_id}");
            string js = await response.Content.ReadAsStringAsync();
            List<Scores> data_getall = JsonConvert.DeserializeObject<List<Scores>>(js);
            dataGridView1.ReadOnly = true;
            if (data_getall.Count != 0)
            {
                MessageBox.Show($"Tìm được học sinh trong lớp {find_id} ! ", "Thông báo");
                dataGridView1.DataSource = data_getall;
            }
            else
            {
                MessageBox.Show("Không tìm thấy dữ liệu của lớp học !" + find_id, "Thông báo");
                await GetAllScore();
            }
        }

        // Tìm kiếm điểm học sinh theo mã học sinh , mã môn học và mã lớp 
        private async void btnFInd_Click_1(object sender, EventArgs e)
        {
            string mahs = string.IsNullOrWhiteSpace(txbFindStudentID.Text) ? null : txbFindStudentID.Text;
            string mamon = string.IsNullOrWhiteSpace(txbFindSubjectID.Text) ? null : txbFindSubjectID.Text;
            string malop = string.IsNullOrWhiteSpace(txbFindClassID.Text) ? null : txbFindClassID.Text;

            // Tạo query string động
            var url = "http://localhost/QLDHSTHPT/api/findscore";
            var queryParams = new List<string>();

            if (mahs != null) queryParams.Add($"mahs={mahs}");
            if (mamon != null) queryParams.Add($"mamon={mamon}");
            if (malop != null) queryParams.Add($"malop={malop}");

            if (queryParams.Count > 0)
                url += "?" + string.Join("&", queryParams);

            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string js = await response.Content.ReadAsStringAsync();
                List<Scores> data = JsonConvert.DeserializeObject<List<Scores>>(js);

                if (data.Count > 0)
                {
                    MessageBox.Show($"Tìm được {data.Count} kết quả phù hợp yêu cầu", "Thông báo");
                    dataGridView1.DataSource = data;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy điểm phù hợp!", "Thông báo");
                    await GetAllScore(); 
                }
            }
            else
            {
                MessageBox.Show("Lỗi khi gọi API!", "Thông báo");
            }
        }


        private void cbxSubjectID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await GetAllScore();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            Scores scores = new Scores
            {
                MaHS = txbStudentID.Text,
                MaMon = txbSubjectID.Text,
                HocKy = txbSemester.Text,
                NamHoc = txbYear.Text,
                DiemKT = float.Parse(txb15p.Text),
                DiemGK = float.Parse(txb45p.Text),
                DiemThi = float.Parse(txbLastTest.Text)
            };
            var json = JsonConvert.SerializeObject(scores, Formatting.Indented);
            var send = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync($"http://localhost/QLDHSTHPT/api/updatescore/{scores.MaHS}", send);
            MessageBox.Show(await response.Content.ReadAsStringAsync(), "Thông báo");
            await GetAllScore();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
