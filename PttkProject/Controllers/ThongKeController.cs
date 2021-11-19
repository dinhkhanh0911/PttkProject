using DBCovid.Data;
using DBCovid.models;
using PttkProject.DatabaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PttkProject.Controllers
{
    public class ThongKeController : BaseUserController
    {
        private ThongKeDAO thongke = new ThongKeDAO();
        private DBCovidContext dbcontext = new DBCovidContext();
        // GET: ThongKe
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult thongkecanhiem(string mgs)
        {
            ViewBag.message = mgs;
            return View();
        }
        [HttpPost]
        public JsonResult thongKeCaNhiem(string startdate, string enddate)
        {
            try
            {
                var list = thongke.layDSCaNhiem(startdate, enddate);                
                return Json(new { code = 200, data = list }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { code = 404, mgs = "lỗi" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult thongkecakhoibenh(string mgs)
        {
            ViewBag.message = mgs;
            return View();
        }
        [HttpPost]
        public JsonResult thongKeCaKhoiBenh(string startdate, string enddate)
        {
            try
            {
                var list = thongke.layDSCaKhoiBenh(startdate, enddate);
                return Json(new { code = 200, data = list }, JsonRequestBehavior.AllowGet);
            }catch(Exception e)
            {
                return Json(new { code = 404 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult thongkecatuvong(string mgs)
        {
            ViewBag.message = mgs;
            return View();
        }
        [HttpPost]
        public JsonResult thongKeCaTuVong(string startdate, string enddate)
        {
            try
            {
                var list = thongke.layDSCaTuVong(startdate, enddate);
                return Json(new { code = 200, data = list }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e) {
                return Json(new { code = 404 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult thongkecaduongtinhtrolai()
        {
            
            return View();
        }
        [HttpPost]
        public JsonResult thongKeCaDuongTinhTroLai()
        {
            try
            {
                var list = thongke.layDSCaDuongTinhTroLai();   
               return Json(new { code = 200, data = list }, JsonRequestBehavior.AllowGet);
                
            }
            catch (Exception e)
            {
                return Json(new { code = 404 }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}