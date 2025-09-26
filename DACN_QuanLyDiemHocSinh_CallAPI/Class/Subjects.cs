using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACN_QuanLyDiemHocSinh_CallAPI.Class
{
    public class Subjects
    {
        [DisplayName("Mã môn học")]
        public string MaMon { get; set; }
        [DisplayName("Tên môn học")]

        public string TenMon { get; set; }
        [DisplayName("Số tiết")]

        public int SoTiet { get; set; }
    }
}
