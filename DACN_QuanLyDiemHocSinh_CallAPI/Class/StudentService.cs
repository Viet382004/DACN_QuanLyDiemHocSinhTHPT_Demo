using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DACN_QuanLyDiemHocSinh_CallAPI.Class
{
    class StudentService
    {
        private readonly HttpClient client = new HttpClient();
        public async Task<List<Students>> GetAllStudent()
        {
            HttpResponseMessage response = await client.GetAsync("http://localhost/QLDHSTHPT/api/getallstudent");
            string js = await response.Content.ReadAsStringAsync();
            List<Students> data = JsonConvert.DeserializeObject<List<Students>>(js);
            return data;
        }
    }
}
