using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DACN_QuanLyDiemHocSinh_API.DTO
{
	public class StudentDTO
	{
        public int MaHS { get; set; }
        public string HoTenHS { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public int? MaLop { get; set; }
    }
}