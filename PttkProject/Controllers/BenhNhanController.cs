using DBCovid.models;
using PttkProject.DatabaseDAO;
using PttkProject.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PttkProject.Controllers
{
    public class BenhNhanController : BaseUserController
    {
        private DiaChiDAO diaChi = new DiaChiDAO();
        private BenhNhanDAO benhNhan = new BenhNhanDAO();
        private BenhAnDAO benhAn = new BenhAnDAO();
        private PhongBenhDAO phong = new PhongBenhDAO();
        private NhanVienYTeDAO nvyTe = new NhanVienYTeDAO();
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }
        /*View thêm bệnh nhân*/
        public ActionResult themBenhNhan()
        {
            try
            {
                setViewBagDiaChi();             
            }
            catch(Exception e)
            {
                return RedirectToAction("Index", "BenhNhan");
            }
            return View();
        }
        /*Thêm bệnh nhân*/
        [HttpPost]
        public ActionResult themBenhNhan(BenhNhan bn)
        {
            
            try
            {
                    var ok = benhNhan.themBenhNhan(bn);
                    return RedirectToAction("thembenhan", "BenhNhan", new { ID = bn.ID,  msg = "Thêm thành công"});

            }
            catch (Exception e)
            {
                //lloi
                return RedirectToAction("Index", "BenhNhan");
            }

        }
        /*GD cập nhật bệnh nhân*/
        public ActionResult capnhatTTbenhnhan(int id, string mgs)
        {
            try
            {
                BenhNhan bn = benhNhan.layBenhNhan(id);
                ViewBag.message = mgs;
                ViewBag.ba = new SelectList(benhAn.layDSBenhAn(id), "ID", "ngayNhapVien");
                setViewBagDiaChi();
                if(bn==null)return RedirectToAction("Index", "BenhNhan");
                return View(bn);
            }
            catch(Exception e)
            {
                return RedirectToAction("Index", "BenhNhan");
            }
            
        }
        /*cập nhật bệnh nhân*/
        [HttpPost]
        public ActionResult Update(BenhNhan bn)
        {

            try
            {
                benhNhan.capNhatTTBenhNhan(bn);
                return RedirectToAction("capnhatTTbenhnhan", "BenhNhan", new {id = bn.ID, mgs = "Sửa thành công"});
            }
            catch (Exception e)
            {
                //lloi
                return RedirectToAction("capnhatTTbenhnhan", "BenhNhan", new { id = bn.ID, mgs = "Sửa thất bại" });
            }

        }
        /*Tìm kiếm bệnh nhân*/
        public ActionResult timKiemBenhNhan()
        {
            return View();
        }
        [HttpPost]
        public JsonResult layDSBenhNhan(string input)
        {
            try
            {
                if (input.Length == 0)
                {
                    return Json(new { code = 404 }, JsonRequestBehavior.AllowGet);
                }
                List<BenhNhan> data = benhNhan.layDSBenhNhan(input);
                return Json(new { code = 200, data = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 404 }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public JsonResult layBenhNhan(int id)
        {
            try
            {
                BenhNhan bn = benhNhan.layBenhNhan(id);
                return Json(new { code = 200, data = bn }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 404 }, JsonRequestBehavior.AllowGet);
            }

        }
        [HttpPost]
        public JsonResult xoaBenhNhan(int ID)
        {
            try
            {
                bool ok = false;
                ok = benhNhan.xoaBenhNhan(ID);
                if (ok)
                {
                    return Json(new { code = 200, msg = "Xóa thành công" }, JsonRequestBehavior.AllowGet);
                }
                return Json(new { code = 500, msg = "Xóa không thành công" }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { code = 500, msg = "Xóa không thành công" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult thembenhan(int id)
        {

            string tenBenhNhan = benhNhan.layTenBenhNhan(id);
            if(tenBenhNhan != "")
            {
                setViewBagTenBenhNhan(tenBenhNhan);
                setViewBagThemBenhAn();
                BenhAn model = new BenhAn();
                model.benhNhanID = id;
                return View(model);
            }
            return Redirect("Index");
        }
        
        [HttpPost]
        public JsonResult thembenhan(BenhAn model)
        {
            if (ModelState.IsValid)
            {
                setViewBagThemBenhAn();
                var ok = benhAn.themBenhAn(model);
                
                if (ok)
                {
                    return Json(new { code = 200, model = model,msg ="Thêm thành công"}, JsonRequestBehavior.AllowGet);
                }
                return Json(new { code = 500, model = model,msg = "Thêm không thành công" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                setViewBagThemBenhAn();
                return Json(new { code = 500,model = model,msg = "Thuộc tính chưa chính xác"}, JsonRequestBehavior.AllowGet);
            }
            
        }
        private void setViewBagTenBenhNhan(string tenBenhNhan)
        {
            ViewBag.tenBenhNhan = tenBenhNhan;
        }
        [HttpPost]
        public JsonResult layDSPhongBenh(int loaiPhongID)
        {
            try
            {

                List<PhongBenh> data = phong.layDSPhongBenh(loaiPhongID) ;
                return Json(new { code = 200, listRoom = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 404 }, JsonRequestBehavior.AllowGet);
            }
        }
        private void setViewBagThemBenhAn()
        {
            List<LoaiPhong> l = phong.layDSLoaiPhong();
            List<PhongBenh> p = new List<PhongBenh>();
            List<TrangThai> t = benhNhan.layDSTrangThai();
            if (l.Count() > 0)
            {
                p = phong.layDSPhongBenh(l[0].ID);
            }
            ViewBag.loaiPhong = new SelectList(l, "ID", "tenLoaiPhong");
            ViewBag.phongBenh = new SelectList(p, "ID", "tenPhong");
            ViewBag.trangThai = new SelectList(t, "ID", "tinhTrang");
        }
        /*Cập nhật bệnh án*/
        public ActionResult capnhatbenhan(int id, string mgs)
        {
            BenhAn BA = benhAn.layBenhAn(id);
            if (BA != null)
            {
                ViewBag.message = mgs;
                setViewBagInfo(BA.ID, BA.benhNhanID);
                return View(BA);
            }
            return RedirectToAction("capnhatTTbenhnhan", "BenhNhan", new { id = id, mgs = "Không có bệnh án" });
        }
        public void setViewBagInfo(int id, int idBN)
        {
            ViewBag.BenhNhan = benhNhan.layBenhNhan(idBN);
            var l = phong.layDSPhongTrong();
            ViewBag.phong = new SelectList(l!=null? l :new List<PhongBenh>(), "ID", "tenPhong");
            ViewBag.dsTTDieuTri = benhAn.layDSTTDieuTri(id);
            ViewBag.dsTTTruyVet = benhAn.layDSTTTruyVet(id);
            var tt = benhAn.layDSTrangThai();
            ViewBag.trangThai = new SelectList(tt!=null?tt:new List<TrangThai>(), "ID", "tinhTrang");
        }
        [HttpPost]
        public ActionResult UpdateBenhAn(BenhAn bn)
        {
            int id = bn.ID;
            bool check = benhAn.capNhatTTBenhAn(bn);
            phong.capNhatSoGiuong();
            string mgs;
            if (check) mgs = "chỉnh sửa thành công";
            else mgs = "chỉnh sửa thất bại";
            return RedirectToAction("capnhatbenhan","BenhNhan", new { id = id , mgs = mgs});
        }
        
        public JsonResult layDSThongTin(int benhAnID)
        {
            try
            {
                List<ThongTinDieuTri> thongTinDieuTris = benhNhan.layDSThongTinDieuTri(benhAnID);
                var thongTinTruyVets = benhNhan.layDSThongTinTruyVet(benhAnID);
                return Json(new { code = 200, thongTinDieuTris = thongTinDieuTris, thongTinTruyVets = thongTinTruyVets }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { code = 500 }, JsonRequestBehavior.AllowGet);
            }
        }
        

        /*Thông tin điều trị */
        public ActionResult themThongTinDieuTri(int ID)
        {

            int benhNhanID = benhNhan.layBenhNhanID(ID);
            string tenBenhNhan = benhNhan.layTenBenhNhan(benhNhanID);
            if(tenBenhNhan != null)
            {
                setViewBagTenBenhNhan(tenBenhNhan);
                setViewbagNVYT();
                ThongTinDieuTri thongTinDieuTri = new ThongTinDieuTri();
                thongTinDieuTri.benhAnID = ID;
                return View(thongTinDieuTri);
            }
            return Redirect("/benh-nhan/cap-nhat-benh-an/"+ID.ToString());
        }
        [HttpPost]
        public JsonResult themThongTinDieuTri(ThongTinDieuTri model)
        {
            if (ModelState.IsValid)
            {
                bool oke = false;
                oke = benhNhan.themThongTinDieuTri(model);
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
                ok = benhNhan.xoaThongTinDieuTri(ID);
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
            List<NhanVienYTe> list = nvyTe.layDSNhanVienYTe();

            SelectList s = new SelectList(list, "ID", "ten");
            ViewBag.nhanVienYTe = s;
        }

        /*Thông tin truy vết*/
        public ActionResult ThemThongTinTruyVet(int ID)
        {
            int benhNhanID = benhNhan.layBenhNhanID(ID);
            string tenBenhNhan = benhNhan.layTenBenhNhan(benhNhanID);
            if (tenBenhNhan != null)
            {
                setViewBagTenBenhNhan(tenBenhNhan);
                setViewBagDiaChi();
                ThongTinTruyVet thongTinTruyVet = new ThongTinTruyVet();
                thongTinTruyVet.benhAnID = ID;
                return View(thongTinTruyVet);
            }
            return Redirect("/benh-nhan/cap-nhat-benh-an/" + ID.ToString());
        }
        [HttpPost]
        public ActionResult ThemThongTinTruyVet(ThongTinTruyVet model)
        {
            if (ModelState.IsValid)
            {
                bool oke = false;
                oke = benhNhan.themThongTinTruyVet(model);
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
                ok = benhNhan.xoaThongTinTruyVet(ID);
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
                             select new {
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