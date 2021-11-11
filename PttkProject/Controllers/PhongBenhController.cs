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
                var ok = phongbenhDAO.themPhongBenh(pb);
                
                return RedirectToAction("Index", "PhongBenh");

            }
            catch (Exception e)
            {
                //lloi
                return RedirectToAction("Index", "PhongBenh");
            }
        }


        public ActionResult suaphong(int id, string mgs)
        {
            var pb = phongbenhDAO.layPhongBenh(id);

            if (pb != null)
            {
                ViewBag.message = mgs;
                setViewBagLoaiPhong();
                return View(pb);
            }
            else return RedirectToAction("timkiemphong", "PhongBenh");
        }
        [HttpPost]
        public ActionResult UpdateRoom(PhongBenh pb)
        {
            try
            {
                phongbenhDAO.capNhatPhongBenh(pb);
                return RedirectToAction("suaphong", "PhongBenh", new { id = pb.ID, mgs = "Sửa phòng thành công" });
            }
            catch
            {
                return RedirectToAction("suaphong", "PhongBenh", new { id = pb.ID, mgs = "Sửa phong thất bại" });
            }
            
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