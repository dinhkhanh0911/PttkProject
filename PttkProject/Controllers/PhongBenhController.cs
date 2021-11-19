using DBCovid.models;
using PttkProject.DatabaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PttkProject.Controllers
{
    public class PhongBenhController : BaseUserController
    {
        private PhongBenhDAO phongbenhDAO = new PhongBenhDAO();
        // GET: Room
        public ActionResult Index()
        {
            return View();
        }
        /*view thêm phòng bệnh*/
        public ActionResult themphong(string mgs)
        {
            setViewBagLoaiPhong();
            ViewBag.message = mgs;
            return View();
        }
        /*thêm phòng bệnh*/
        [HttpPost]
        public ActionResult themPhong(PhongBenh pb)
        {
            try
            {               
                var ok = phongbenhDAO.themPhongBenh(pb);                
                return RedirectToAction("themphong", "PhongBenh", new { mgs = "Thêm thành công" });
                
            }
            catch (Exception e)
            {
                //lloi
                return RedirectToAction("themphong", "PhongBenh", new { mgs = "Thêm thất bại" });
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
        [HttpPost]
        public JsonResult timKiem(string search)
        {
            try
            {
                var data = phongbenhDAO.timKiemPhong(search);
                return Json(new { code = 200, data = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 404, mgs = "Tìm kiếm có lỗi" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult xoaPhong(int ID)
        {
            try
            {
                phongbenhDAO.xoaPhong(ID);
                return Json(new { code = 200, mgs = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 404, mgs = "Xóa thất bại, phòng đang được sử dụng" }, JsonRequestBehavior.AllowGet);
            }
        }
        private void setViewBagLoaiPhong()
        {
            List<LoaiPhong> l = phongbenhDAO.layDSLoaiPhong();
            ViewBag.loaiPhong = new SelectList(l, "ID", "tenLoaiPhong");
        }
    }
}