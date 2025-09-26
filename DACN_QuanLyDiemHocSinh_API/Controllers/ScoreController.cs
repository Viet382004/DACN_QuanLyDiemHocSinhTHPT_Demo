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

        // GET: api/Score

        [HttpGet]
        [Route("api/getscorefull")]
        public IHttpActionResult GetDiemFull()
        {
            using (var db = new QLDHSTHPTEntities())
            {
                var query = from d in db.DIEMs
                            join hs in db.HOC_SINH on d.MaHS equals hs.MaHS
                            join mh in db.MON_HOC on d.MaMon equals mh.MaMon
                            select new ScoreDTO
                            {
                                MaHS = hs.MaHS,
                                HoTenHS = hs.HoTenHS,
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


        

    }
}
