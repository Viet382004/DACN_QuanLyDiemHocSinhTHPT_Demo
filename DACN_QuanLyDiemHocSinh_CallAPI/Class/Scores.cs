using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DACN_QuanLyDiemHocSinh_CallAPI.Class
{
    public class Scores
    {
        [DisplayName("Mã HS")]
        public string MaHS { get; set; }
        [DisplayName("Tên HS")]
        public string HoTenHS { get; set; }
        [DisplayName("Mã môn")]
        public string MaMon { get; set; }
        [DisplayName("Têm môn")]

        public string TenMon { get; set; }
        [DisplayName("Học kỳ")]

        public float HocKy { get; set; }
        [DisplayName("Năm học")]

        public string NamHoc { get; set; }
        [DisplayName("Điểm KT")]

        public float DiemKT { get; set; }
        [DisplayName("Điểm GK")]

        public float DiemGK { get; set; }
        [DisplayName("Điểm thi")]

        public float DiemThi { get; set; }
        [DisplayName("Điểm TB")]

        public float DiemTB
        {
            get
            {
                return (float)Math.Round((DiemKT + DiemGK * 2 + DiemThi * 3) / 6, 2);
            }
        }


        [DisplayName("Xếp loại")]

        public string XepLoai
        {
            get
            {
                if (DiemTB >= 8.0f) return "Giỏi";
                else if (DiemTB >= 6.5f) return "Khá";
                else if (DiemTB >= 5.0f) return "Trung bình";
                else return "Yếu";
            }
        }
    }
}
