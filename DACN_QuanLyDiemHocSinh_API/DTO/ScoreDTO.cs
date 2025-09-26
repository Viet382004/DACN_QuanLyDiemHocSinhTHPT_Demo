using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACN_QuanLyDiemHocSinh_API
{
	public class ScoreDTO
	{
        public int MaHS { get; set; }
        public string HoTenHS { get; set; }
        public int MaMon { get; set; }
        public string TenMon { get; set; }
        public int HocKy { get; set; }
        public string NamHoc { get; set; }
        public double? DiemKT { get; set; }
        public double? DiemGK { get; set; }
        public double? DiemThi { get; set; }
    }
}