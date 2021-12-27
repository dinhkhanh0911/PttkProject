using DBCovid.models;
using PttkProject.Common;
using PttkProject.DatabaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PttkProject.Controllers
{
    public class NguoiDungController : BaseUserController
    {
        // GET: Uesr
        private NguoiDungDAO nguoiDung = new NguoiDungDAO();
        private DiaChiDAO diaChi = new DiaChiDAO();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult themnguoidung(string mgs)
        {
            ViewBag.message = mgs;
            setViewBagDiaChi();
            ViewBag.viTriLamViec = new SelectList(nguoiDung.layDSViTriLamViec(), "ID", "tenVitri");
            return View();
        }
        [HttpPost]
        public ActionResult themNguoiDung(NguoiDung nd)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    if (nguoiDung.isNguoiDung(nd.taiKhoan))
                    {
                        return RedirectToAction("Index", "NguoiDung", new { mgs = "Tài khoản đã tồn tại" });
                    }
                    nd.matKhau = Encypter.MD5Hash(nd.matKhau);
                    nguoiDung.themNguoiDung(nd);
                    return RedirectToAction("themnguoidung", "NguoiDung", new { mgs = "Thêm thành công" });
                //}
                //return RedirectToAction("Index", "NguoiDung", new { mgs = "Thêm thất bại" });
            }
            catch (Exception e)
            {
                //lloi
                return RedirectToAction("Index", "NguoiDung", new {mgs = "Thêm thất bại" });
            }
        }
        public ActionResult suanguoidung(int id)
        {

            NguoiDung nd = nguoiDung.layNguoiDung(id);
            setViewBagDiaChi();
            ViewBag.viTriLamViec = new SelectList(nguoiDung.layDSViTriLamViec(), "ID", "tenVitri");
            return View(nd);
        }
        [HttpPost]
        public ActionResult capNhatNguoiDung(NguoiDung nd)
        {
            try
            {
                nguoiDung.capNhatNguoiDung(nd);
                return RedirectToAction("suanguoidung", "NguoiDung", new { id = nd.ID, mgs = "Sửa thành công" });
            }
            catch (Exception e)
            {
                //lloi
                return RedirectToAction("suanguoidung", "NguoiDung", new { id = nd.ID, mgs = "Sửa thất bại" });
            }
        }
        public ActionResult timkiemnguoidung()
        {
            return View();
        }
        [HttpPost]
        public JsonResult timKiem(string search)
        {
            try
            {
                var data = nguoiDung.timNguoiDung(search);
                return Json(new { code = 200, data = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 404, mgs = "Tìm kiếm có lỗi"}, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult xoaNguoiDung(int ID)
        {
            try
            {
                nguoiDung.xoaNguoiDung(ID);
                return Json(new { code = 200, mgs="Xóa thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 404, mgs = "Không thể xóa người dùng này"}, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        public ActionResult ChangePassword()
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