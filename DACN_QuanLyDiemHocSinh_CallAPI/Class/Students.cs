using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACN_QuanLyDiemHocSinh_CallAPI.Class
{
    public class Students
    {
        [DisplayName("Mã học sinh")]
        public string MaHS { get; set; }
        [DisplayName("Tên học sinh")]

        public string HoTenHS { get; set; }
        [DisplayName("Giới tính")]

        public string GioiTinh { get; set; }
        [DisplayName("Ngày sinh")]
        public DateTime NgaySinh { get; set; }
        [DisplayName("Địa chỉ")]

        public string DiaChi { get; set; }

        [DisplayName("Mã lớp")]
        public string MaLop { get; set; }
    }
}
