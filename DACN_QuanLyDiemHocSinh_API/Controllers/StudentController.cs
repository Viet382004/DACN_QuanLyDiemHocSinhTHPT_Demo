using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DACN_QuanLyDiemHocSinh_API.DTO;
using DACN_QuanLyDiemHocSinh_API.Models;

namespace DACN_QuanLyDiemHocSinh_API.Controllers
{
    public class StudentController : ApiController
    {
        QLDHSTHPTEntities db = new QLDHSTHPTEntities();

        // GET: api/Student
        [HttpGet]
        [Route("api/getallstudent")]
        public IHttpActionResult GetAllSudent()
        {
            var result = db.HOC_SINH
                   .Select(hs => new StudentDTO
                   {
                       MaHS = hs.MaHS,
                       HoTenHS = hs.HoTenHS,
                       GioiTinh = hs.GioiTinh,
                       NgaySinh = hs.NgaySinh,
                       DiaChi = hs.DiaChi,
                       MaLop = hs.MaLop
                   })
                   .ToList();

            return Ok(result);
        }

        // GET: api/Student/id
        [HttpGet]
        [Route("api/getstudentbyid/{id}")]
        public IHttpActionResult GetStudentById(int id)
        {
            var result = db.HOC_SINH
                   .Where(hs => hs.MaHS == id)
                   .Select(hs => new StudentDTO
                   {
                       MaHS = hs.MaHS,
                       HoTenHS = hs.HoTenHS,
                       GioiTinh = hs.GioiTinh,
                       NgaySinh = hs.NgaySinh,
                       DiaChi = hs.DiaChi,
                       MaLop = hs.MaLop
                   })
                   .ToList();

            return Ok(result);
        }

        // POST: api/Student
        [HttpPost]
        [Route("api/addstudent")]
        public HttpResponseMessage AddStudent(HOC_SINH hs)
        {
            try
            {
                var stfind = db.HOC_SINH.FirstOrDefault(s => s.MaHS == hs.MaHS);

                if (stfind == null)
                {
                    db.HOC_SINH.Add(hs);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Thêm học sinh thành công");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Học sinh đã tồn tại");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Lỗi server: " + ex.Message);
            }

        }

        // PUT: api/Student/5
        [HttpPut]
        [Route("api/updatestudent/{id}")]
        public HttpResponseMessage UpdateStudent(int id, HOC_SINH hs)
        {
            try
            {
                var stfind = db.HOC_SINH.FirstOrDefault(s => s.MaHS == id);
                if (stfind != null)
                {
                    stfind.HoTenHS = hs.HoTenHS;
                    stfind.GioiTinh = hs.GioiTinh;
                    stfind.NgaySinh = hs.NgaySinh;
                    stfind.DiaChi = hs.DiaChi;
                    stfind.MaLop = hs.MaLop;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Cập nhật học sinh thành công");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Học sinh không tồn tại");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Lỗi server: " + ex.Message);
            }
        }

        // DELETE: api/Student/5
        [HttpDelete]
        [Route("api/deletestudent/{id}")]
        public HttpResponseMessage DeleteStudent(int id)
        {

            var stfind = db.HOC_SINH.FirstOrDefault(s => s.MaHS == id);
            if (stfind != null)
            {
                db.HOC_SINH.Remove(stfind);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Xóa học sinh thành công");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Học sinh không tồn tại");
            }

        }
    }
}
