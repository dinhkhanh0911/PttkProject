﻿using DBCovid.models;
using PttkProject.DatabaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PttkProject.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: Uesr
        private NguoiDungDAO nguoiDung = new NguoiDungDAO();
        private DBIO dBIO = new DBIO();
        private DiaChiDAO diaChi = new DiaChiDAO();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult themnguoidung(string mgs)
        {
            ViewBag.message = mgs;
            setViewBagDiaChi();
            ViewBag.viTriLamViec = new SelectList(dBIO.layDSViTriLamViec(), "ID", "tenVitri");
            return View();
        }
        [HttpPost]
        public ActionResult themNguoiDung(NguoiDung nd)
        {
            try
            {
                nguoiDung.themNguoiDung(nd);
                return RedirectToAction("themnguoidung", "NguoiDung", new { mgs = "Thêm thành công" });
            }
            catch (Exception e)
            {
                //lloi
                return RedirectToAction("Index", "NguoiDung", new {mgs = "Thêm thất bại" });
            }
        }
        public ActionResult suanguoidung()
        {
            int id = 9;
            NguoiDung nd = nguoiDung.layNguoiDung(id);
            setViewBagDiaChi();
            ViewBag.viTriLamViec = new SelectList(dBIO.layDSViTriLamViec(), "ID", "tenVitri");
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
                var data = nguoiDung.layDSNguoiDung(search);
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
                return Json(new { code = 404, mgs = "Xóa thất bại"}, JsonRequestBehavior.AllowGet);
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
            List<Huyen> huyens = new List<Huyen>();
            List<Xa> xas = new List<Xa>();
            if (tinhs.Count > 0)
            {
                huyens = diaChi.layDSHuyen(tinhs[0].ID);
            }
            if (huyens.Count > 0)
            {
                xas = diaChi.layDSXa(huyens[0].ID);
            }

            ViewBag.tinhs = new SelectList(tinhs, "ID", "tenTinh");
            ViewBag.huyens = new SelectList(huyens, "ID", "tenHuyen");
            ViewBag.xas = new SelectList(xas, "ID", "tenXa");

        }
    }
}