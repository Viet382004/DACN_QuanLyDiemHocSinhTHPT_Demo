using DACN_QuanLyDiemHocSinh_API.DTO;
using DACN_QuanLyDiemHocSinh_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DACN_QuanLyDiemHocSinh_API.Controllers
{
    public class SubjectController : ApiController
    {
        QLDHSTHPTEntities db = new QLDHSTHPTEntities();

        // GET: api/Subject
        [HttpGet]
        [Route("api/getallsubject")]
        public IHttpActionResult GetAllSubject()
        {
            var result = db.MON_HOC
                   .Select(hs => new SubjectDTO
                   {
                       MaMon = hs.MaMon,
                       TenMon = hs.TenMon,
                       SoTiet = hs.SoTiet
                   })
                   .ToList();

            return Ok(result);
        }


        // GET: api/Subject/id
        [HttpGet]
        [Route("api/getsubjectbyid/{id}")]
        public IEnumerable<MON_HOC> GetSubjectById(int id)
        {
            return db.MON_HOC.Where(s => s.MaMon == id);
        }

        // POST: api/Subject
        [HttpPost]
        [Route("api/addsubject")]
        public HttpResponseMessage AddSubject(MON_HOC mh)
        {
            try
            {
                var subfind = db.MON_HOC.FirstOrDefault(s => s.MaMon == mh.MaMon);
                if (subfind == null)
                {
                    db.MON_HOC.Add(mh);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Thêm môn học thành công");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Môn học đã tồn tại");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Lỗi server: " + ex.Message);
            }
        }

        // DELETE: api/Subject/5
        [HttpDelete]
        [Route("api/deletesubject/{id}")]
        public HttpResponseMessage DeleteSubject(int id)
        {
            try
            {
                var subfind = db.MON_HOC.FirstOrDefault(s => s.MaMon == id);
                if (subfind != null)
                {

                    db.MON_HOC.Remove(subfind);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Xóa môn học thành công");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Môn học không tồn tại");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(
                    HttpStatusCode.InternalServerError,
                    "Lỗi server: " + ex.InnerException?.Message ?? ex.Message
                );
            }

        }

        // PUT: api/Subject/5
        [HttpPut]
        [Route("api/updatesubject/{id}")]
        public HttpResponseMessage UpdateSubject(int id, MON_HOC mh)
        {
            try
            {
                var subfind = db.MON_HOC.FirstOrDefault(s => s.MaMon == id);
                if (subfind != null)
                {
                    subfind.TenMon = mh.TenMon;
                    subfind.SoTiet = mh.SoTiet;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Cập nhật môn học thành công");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Môn học không tồn tại");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Lỗi server: " + ex.Message);
            }
        }

        
    }
}
