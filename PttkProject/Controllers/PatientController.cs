using DBCovid.models;
using PttkProject.DatabaseDAO;
using PttkProject.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PttkProject.Controllers
{
    public class PatientController : Controller
    {
        private DBIO dBIO = new DBIO();
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ImportInformation()
        {
            return View();
        }
        public ActionResult UpdateInformation()
        {
            return View();
        }
        public ActionResult SearchPatient()
        {
            return View();
        }
        
        public ActionResult ImportMedicalRecord()
        {
            int ID = 1;
            string tenBenhNhan = dBIO.layTenBenhNhan(ID);
            if(tenBenhNhan != "")
            {
                setViewBagTenBenhNhan(tenBenhNhan);
                setViewBagImportMedicalRecord();
                BenhAn model = new BenhAn();
                model.benhNhanID = ID;
                return View(model);
            }
            return Redirect("ImportInformation");
        }
        
        [HttpPost]
        public JsonResult ImportMedicalRecord(BenhAn model)
        {
            if (ModelState.IsValid)
            {
                setViewBagImportMedicalRecord();
                var ok = dBIO.themBenhAn(model);
                if (ok)
                {
                    return Json(new { code = 200, model = model,msg ="Thêm thành công"}, JsonRequestBehavior.AllowGet);
                }
                return Json(new { code = 500, model = model,msg = "Thêm không thành công" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                setViewBagImportMedicalRecord();
                return Json(new { code = 500,model = model,msg = "Thuộc tính chưa chính xác"}, JsonRequestBehavior.AllowGet);
            }
            
        }
        private void setViewBagTenBenhNhan(string tenBenhNhan)
        {
            ViewBag.tenBenhNhan = tenBenhNhan;
        }
        [HttpPost]
        public JsonResult getListRoom(int loaiPhongID)
        {
            try
            {

                List<PhongBenh> data = dBIO.layDSPhongBenh(loaiPhongID) ;
                return Json(new { code = 200, listRoom = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 404 }, JsonRequestBehavior.AllowGet);
            }
        }
        private void setViewBagImportMedicalRecord()
        {
            List<LoaiPhong> l = dBIO.layDSLoaiPhong();
            List<PhongBenh> p = new List<PhongBenh>();
            List<TrangThai> t = dBIO.layDSTrangThai();
            if (l.Count() > 0)
            {
                p = dBIO.layDSPhongBenh(l[0].ID);
            }
            ViewBag.loaiPhong = new SelectList(l, "ID", "tenLoaiPhong");
            ViewBag.phongBenh = new SelectList(p, "ID", "tenPhong");
            ViewBag.trangThai = new SelectList(t, "ID", "tinhTrang");
        }
        /*Cập nhật bệnh án*/
        public ActionResult UpdateMedicalRecord()
        {
            int ID = 3;
            bool ok = false;
            ok = dBIO.isBenhAn(ID);
            if (ok)
            {
                BenhAn b = dBIO.layBenhAn(ID);
                return View(b);
            }
            return Redirect("ImportInformation");
        }
        [HttpPost]
        public JsonResult layDSThongTin(int benhAnID)
        {
            try
            {
                List<ThongTinDieuTri> thongTinDieuTris = dBIO.layDSThongTinDieuTri(benhAnID);
                var thongTinTruyVets = dBIO.layDSThongTinTruyVet(benhAnID);

                return Json(new { code = 200, thongTinDieuTris = thongTinDieuTris, thongTinTruyVets = thongTinTruyVets }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public JsonResult getPatientList(string input)
        {
            try
            {
                if(input.Length == 0)
                {
                    return Json(new { code = 404 }, JsonRequestBehavior.AllowGet);
                }
                List<BenhNhan> data = dBIO.layDSBenhNhan();
                return Json(new {code= 200,data=data},JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { code = 404}, JsonRequestBehavior.AllowGet);
            }

        }

        /*Thông tin điều trị */
        public ActionResult themThongTinDieuTri(int ID)
        {
            
            int benhNhanID = dBIO.layBenhNhanID(ID);
            string tenBenhNhan = dBIO.layTenBenhNhan(benhNhanID);
            if(tenBenhNhan != null)
            {
                setViewBagTenBenhNhan(tenBenhNhan);
                setViewbagNVYT();
                ThongTinDieuTri thongTinDieuTri = new ThongTinDieuTri();
                thongTinDieuTri.benhAnID = ID;
                return View(thongTinDieuTri);
            }
            return Redirect("ImportInformation");
        }
        [HttpPost]
        public JsonResult themThongTinDieuTri(ThongTinDieuTri model)
        {
            if (ModelState.IsValid)
            {
                bool oke = false;
                oke = dBIO.themThongTinDieuTri(model);
                if (oke)
                {
                    return Json(new { code = 200, msg = "Thêm thành công", model = model }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { code = 500, msg = "Có lỗi xảy ra", model = model }, JsonRequestBehavior.AllowGet);

            }
            return Json(new { code = 500, msg = "Thông tin nhập chưa chính xác", model = model }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult xoaThongTinDieuTri(int ID)
        {
            try
            {
                bool ok = false;
                ok = dBIO.xoaThongTinDieuTri(ID);
                if (ok)
                {
                    return Json(new { code = 200, msg = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { code = 500, msg = "Xóa thất bại" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 500, msg = "Xóa thất bại" }, JsonRequestBehavior.AllowGet);
            }
        }
        private void setViewbagNVYT()
        {
            List<NhanVienYTe> list = dBIO.layDSNhanVienYTe();

            SelectList s = new SelectList(list, "ID", "ten");
            ViewBag.nhanVienYTe = s;
        }

        /*Thông tin truy vết*/
        public ActionResult ThemThongTinTruyVet(int ID)
        {
            int benhNhanID = dBIO.layBenhNhanID(ID);
            string tenBenhNhan = dBIO.layTenBenhNhan(benhNhanID);
            if (tenBenhNhan != null)
            {
                setViewBagTenBenhNhan(tenBenhNhan);
                setViewBagDiaChi();
                ThongTinTruyVet thongTinTruyVet = new ThongTinTruyVet();
                thongTinTruyVet.benhAnID = ID;
                return View(thongTinTruyVet);
            }
            return Redirect("ImportInformation");
        }
        [HttpPost]
        public ActionResult ThemThongTinTruyVet(ThongTinTruyVet model)
        {
            if (ModelState.IsValid)
            {
                bool oke = false;
                oke = dBIO.themThongTinTruyVet(model);
                if (oke)
                {
                    return Json(new { code = 200, msg = "Thêm thành công", model = model }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { code = 500, msg = "Có lỗi xảy ra", model = model }, JsonRequestBehavior.AllowGet);

            }
            return Json(new { code = 500, msg = "Thông tin nhập chưa chính xác", model = model }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult xoaThongTinTruyVet(int ID)
        {
            try
            {
                bool ok = false;
                ok = dBIO.xoaThongTinTruyVet(ID);
                if (ok)
                {
                    return Json(new { code = 200, msg = "Xóa thành công"}, JsonRequestBehavior.AllowGet);
                }
                return Json(new { code = 500,msg = "Xóa thất bại" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { code = 500,msg= "Xóa thất bại" }, JsonRequestBehavior.AllowGet);
            }
        }
        private void setViewBagDiaChi()
        {
            List<Tinh> tinhs = dBIO.layDSTinh();
            List<Huyen> huyens = new List<Huyen>();
            List<Xa> xas = new List<Xa>();
            if (tinhs.Count > 0)
            {
                huyens = dBIO.layDSHuyen(tinhs[0].ID);
            }
            if(huyens.Count > 0)
            {
                xas = dBIO.layDSXa(huyens[0].ID);
            }

            ViewBag.tinhs = new SelectList(tinhs, "ID", "tenTinh");
            ViewBag.huyens = new SelectList(huyens, "ID", "tenHuyen");
            ViewBag.xas = new SelectList(xas, "ID", "tenXa");

        }
    }
}