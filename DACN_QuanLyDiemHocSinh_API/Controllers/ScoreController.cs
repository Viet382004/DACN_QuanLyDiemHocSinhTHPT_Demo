using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DACN_QuanLyDiemHocSinh_API.Models;

namespace DACN_QuanLyDiemHocSinh_API.Controllers
{
    public class ScoreController : ApiController
    {
        QLDHSTHPTEntities db = new QLDHSTHPTEntities();

        // GET: api/Score -- Lấy tất cả điểm có trong database

        [HttpGet]
        [Route("api/getscorefull")]
        public IHttpActionResult GetDiemFull()
        {
            using (var db = new QLDHSTHPTEntities())
            {
                var query = from d in db.DIEMs
                            join hs in db.HOC_SINH on d.MaHS equals hs.MaHS
                            join mh in db.MON_HOC on d.MaMon equals mh.MaMon
                            join l in db.LOPs on hs.MaLop equals l.MaLop
                            select new ScoreDTO
                            {
                                MaHS = hs.MaHS,
                                HoTenHS = hs.HoTenHS,
                                GioiTinh = hs.GioiTinh,
                                MaLop = hs.MaLop,
                                TenLop = l.TenLop,
                                MaMon = mh.MaMon,
                                TenMon = mh.TenMon,
                                HocKy = d.HocKy,
                                NamHoc = d.NamHoc,
                                DiemKT = d.DiemKT,
                                DiemGK = d.DiemGK,
                                DiemThi = d.DiemThi,

                            };

                return Ok(query.ToList());
            }
        }

        // GET: api/Score/mahs/mamon -- Tìm điểm theo mã học sinh và mã môn học
        [HttpGet]
        [Route("api/findscore")]
        public IHttpActionResult FindScore(int? mahs = null, int? mamon = null, int? malop = null)
        {
            using (var db = new QLDHSTHPTEntities())
            {
                var query = from d in db.DIEMs
                            join hs in db.HOC_SINH on d.MaHS equals hs.MaHS
                            join mh in db.MON_HOC on d.MaMon equals mh.MaMon
                            join l in db.LOPs on hs.MaLop equals l.MaLop
                            select new ScoreDTO
                            {
                                MaHS = hs.MaHS,
                                HoTenHS = hs.HoTenHS,
                                GioiTinh = hs.GioiTinh,
                                MaLop = hs.MaLop,
                                TenLop = l.TenLop,
                                MaMon = mh.MaMon,
                                TenMon = mh.TenMon,
                                HocKy = d.HocKy,
                                NamHoc = d.NamHoc,
                                DiemKT = d.DiemKT,
                                DiemGK = d.DiemGK,
                                DiemThi = d.DiemThi,
                            };

                if (mahs.HasValue) query = query.Where(q => q.MaHS == mahs.Value);
                if (mamon.HasValue) query = query.Where(q => q.MaMon == mamon.Value);
                if (malop.HasValue) query = query.Where(q => q.MaLop == malop.Value);


                return Ok(query.ToList());
            }
        }


        // GET: api/Score/id -- Tìm điểm theo mã học sinh
        [HttpGet]
        [Route("api/getscorebymahs/{id}")]
        public IHttpActionResult FindScoreByMaHS(int id)
        {
            using (var db = new QLDHSTHPTEntities())
            {
                var query = from d in db.DIEMs
                            join hs in db.HOC_SINH on d.MaHS equals hs.MaHS
                            join mh in db.MON_HOC on d.MaMon equals mh.MaMon
                            join l in db.LOPs on hs.MaLop equals l.MaLop
                            where (d.MaHS == id)
                            select new ScoreDTO
                            {
                                MaHS = hs.MaHS,
                                HoTenHS = hs.HoTenHS,
                                GioiTinh = hs.GioiTinh,
                                MaLop = hs.MaLop,
                                TenLop = l.TenLop,
                                MaMon = mh.MaMon,
                                TenMon = mh.TenMon,
                                HocKy = d.HocKy,
                                NamHoc = d.NamHoc,
                                DiemKT = d.DiemKT,
                                DiemGK = d.DiemGK,
                                DiemThi = d.DiemThi,
                            };
                return Ok(query.ToList());
            }
        }

        // GET: api/Score/id -- Tìm điểm theo mã môn học
        [HttpGet]
        [Route("api/getscorebymamon/{id_mon}")]
        public IHttpActionResult FindScoreByMaMon(int id_mon)
        {
            using (var db = new QLDHSTHPTEntities())
            {
                var query = from d in db.DIEMs
                            join hs in db.HOC_SINH on d.MaHS equals hs.MaHS
                            join mh in db.MON_HOC on d.MaMon equals mh.MaMon
                            join l in db.LOPs on hs.MaLop equals l.MaLop
                            where (d.MaMon == id_mon)
                            select new ScoreDTO
                            {
                                MaHS = hs.MaHS,
                                HoTenHS = hs.HoTenHS,
                                GioiTinh = hs.GioiTinh,
                                MaLop = hs.MaLop,
                                TenLop = l.TenLop,
                                MaMon = mh.MaMon,
                                TenMon = mh.TenMon,
                                HocKy = d.HocKy,
                                NamHoc = d.NamHoc,
                                DiemKT = d.DiemKT,
                                DiemGK = d.DiemGK,
                                DiemThi = d.DiemThi,
                            };
                return Ok(query.ToList());
            }
        }

        // GET: api/Score/id -- Tìm điểm theo mã lớp
        [HttpGet]
        [Route("api/getscorebymalop/{id_lop}")]
        public IHttpActionResult FindScoreByMaLop(int id_lop)
        {
            using (var db = new QLDHSTHPTEntities())
            {
                var query = from d in db.DIEMs
                            join hs in db.HOC_SINH on d.MaHS equals hs.MaHS
                            join mh in db.MON_HOC on d.MaMon equals mh.MaMon
                            join l in db.LOPs on hs.MaLop equals l.MaLop
                            where (l.MaLop == id_lop)
                            select new ScoreDTO
                            {
                                MaHS = hs.MaHS,
                                HoTenHS = hs.HoTenHS,
                                GioiTinh = hs.GioiTinh,
                                MaLop = hs.MaLop,
                                TenLop = l.TenLop,
                                MaMon = mh.MaMon,
                                TenMon = mh.TenMon,
                                HocKy = d.HocKy,
                                NamHoc = d.NamHoc,
                                DiemKT = d.DiemKT,
                                DiemGK = d.DiemGK,
                                DiemThi = d.DiemThi,
                            };
                return Ok(query.ToList());
            }
        }

        // PUT api/Score/5 -- Cập nhật điểm
        [HttpPut]
        [Route("api/updatescore/{id}")]
        public HttpResponseMessage UpdateScore(int id, DIEM diem)
        {
            try
            {
                var scoreFind = db.DIEMs.FirstOrDefault(s => s.MaHS == id && s.MaMon == diem.MaMon);
                if (scoreFind != null)
                {
                    scoreFind.DiemKT = diem.DiemKT;
                    scoreFind.DiemGK = diem.DiemGK;
                    scoreFind.DiemThi = diem.DiemThi;
                    scoreFind.HocKy = diem.HocKy;
                    scoreFind.NamHoc = diem.NamHoc;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, "Cập nhật điểm thành công");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Không tìm thấy điểm");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Lỗi server: " + ex.Message);
            }
        }

    }
}
