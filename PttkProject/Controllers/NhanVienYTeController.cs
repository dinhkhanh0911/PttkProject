using DBCovid.models;
using PttkProject.DatabaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PttkProject.Controllers
{
    
    public class NhanVienYTeController : Controller
    {
        private DiaChiDAO diaChi = new DiaChiDAO();
        private NhanVienYTeDAO nvYTe = new NhanVienYTeDAO();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult themnhanvienyte(string mgs)
        {
            ViewBag.message = mgs;
            setViewBagDiaChi();
            ViewBag.viTriLamViec = new SelectList(nvYTe.layDSViTriLamViec(), "ID", "tenVitri");
            return View();
        }
        [HttpPost]
        public ActionResult themNhanVienYTe(NhanVienYTe nv)
        {
            try
            {
                var ok = nvYTe.themNhanVienYTe(nv);
                return RedirectToAction("themnhanvienyte", "NhanVienYTe", new { mgs = "Thêm thành công" });

            }
            catch (Exception e)
            {
                //lloi
                return RedirectToAction("Index", "NhanVienYTe", new { mgs = "Thêm thất bại" });
            }
        }

        [HttpPost]
        public JsonResult timKiem(string search)
        {
            try
            {
                var data = nvYTe.timKiemNvYTe(search);
                return Json(new { code = 200, data = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 404, mgs = "Tìm kiếm có lỗi" }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult xoaNvYte(int ID)
        {
            try
            {
                nvYTe.xoaNvYTe(ID);
                return Json(new { code = 200, mgs = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 404, mgs = "Nhân viên y tế đang chăm sóc bệnh nhân, không thể xóa" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult capnhatttnhanvienyte(int id, string mgs)
        {
            ViewBag.message = mgs;
            NhanVienYTe nv = nvYTe.layNhanVienYTe(id);
            setViewBagDiaChi();
            ViewBag.viTriLamViec = new SelectList(nvYTe.layDSViTriLamViec(), "ID", "tenVitri");
            return View(nv);
        }
        [HttpPost]
        public ActionResult capNhatNhanVienYte(NhanVienYTe nv)
        {
            try
            {
                nvYTe.capNhatTTNhanVien(nv);
                return RedirectToAction("capnhatttnhanvienyte", "NhanVienYTe", new { id = nv.ID, mgs = "Sửa thành công" });
            }
            catch (Exception e)
            {
                //lloi
                return RedirectToAction("capnhatttnhanvienyte", "NhanVienYTe", new { id = nv.ID, mgs = "Sửa thất bại" });
            }
        }
        public ActionResult timkiemnhanvienyte()
        {
            return View();
        }
        private void setViewBagDiaChi()
        {
            List<Tinh> tinhs = diaChi.layDSTinh();
            //List<Huyen> huyens = new List<Huyen>();
            //List<Xa> xas = new List<Xa>();
            //if (tinhs.Count > 0)
            //{
            //    huyens = diaChi.layDSHuyen(tinhs[0].ID);
            //}
            //if(huyens.Count > 0)
            //{
            //    xas = diaChi.layDSXa(huyens[0].ID);
            //}
            List<Huyen> huyens = diaChi.layDSHuyen();
            List<Xa> xas = diaChi.layDSXa();
            ViewBag.tinhs = (from s in tinhs
                             select new
                             {
                                 s.ID,
                                 s.tenTinh
                             });
            ViewBag.huyens = (from s in huyens
                              select new
                              {
                                  s.ID,
                                  s.tenHuyen,
                                  s.tinhID
                              });
            ViewBag.xas = (from s in xas
                           select new
                           {
                               s.ID,
                               s.tenXa,
                               s.huyenID
                           });
            //ViewBag.tinhs = new SelectList(tinhs, "ID", "tenTinh");
            //ViewBag.huyens = new SelectList(huyens, "ID", "tenHuyen");
            //ViewBag.xas = new SelectList(xas, "ID", "tenXa");

        }

    }
}