using DBCovid.models;
using PttkProject.DatabaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PttkProject.Controllers
{
    public class PhongBenhController : Controller
    {
        private PhongBenhDAO phongbenhDAO = new PhongBenhDAO();
        // GET: Room
        public ActionResult Index()
        {
            return View();
        }
        /*view thêm phòng bệnh*/
        public ActionResult themphong()
        {
            setViewBagLoaiPhong();
            return View();
        }
        /*thêm phòng bệnh*/
        [HttpPost]
        public ActionResult themPhong(PhongBenh pb)
        {
            try
            {
                phongbenhDAO.themPhongBenh(pb);
                return RedirectToAction("Index", "PhongBenh");

            }
            catch (Exception e)
            {
                //lloi
                return RedirectToAction("Index", "PhongBenh");
            }
        }


        public ActionResult suaphong()
        {
            return View();
        }
        public ActionResult xoaPhong()
        {
            return View();
        }
        public ActionResult timkiemphong()
        {
            return View();
        }
        private void setViewBagLoaiPhong()
        {
            List<LoaiPhong> l = phongbenhDAO.layDSLoaiPhong();
            ViewBag.loaiPhong = new SelectList(l, "ID", "tenLoaiPhong");
        }
    }
}