using DBCovid.Data;
using DBCovid.models;
using Newtonsoft.Json;
using PttkProject.DatabaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PttkProject.Controllers
{
    public class TrangChuController : Controller
    {
        private BenhNhanDAO benhNhan = new BenhNhanDAO();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult layDuLieuBieuDoTron()
        {
            try
            {
                int A = benhNhan.demSoCaDangNhiemBenh();
                int B = benhNhan.demSoCaKhoiBenh();
                int C = benhNhan.demSoCaTuVong();
                int tong = A + B + C;
                List<double> list = new List<double>();
                double rateA = Math.Round((double)A * 100 / tong, 2);
                double rateB = Math.Round((double)B * 100 / tong, 2);
                double rateC = Math.Round((double)C * 100 / tong, 2);
                list.Add(rateA);
                list.Add(rateB);
                list.Add(rateC);
                return Json(new { code = 200, list = list }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { code = 404, msg = "Loi lay du lieu" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}