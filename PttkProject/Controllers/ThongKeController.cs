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
    public class ThongKeController : Controller
    {
        private BenhNhanDAO benhNhanDAO = new BenhNhanDAO();
        private BenhAnDAO benhAnDAO = new BenhAnDAO();
        private DBCovidContext dbcontext = new DBCovidContext();
        // GET: ThongKe
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult thongkecanhiem()
        {
            return View();
        }
        [HttpPost]
        public JsonResult thongKeCaNhiem(string startdate, string enddate)
        {
            try
            {
                DateTime sDate = Convert.ToDateTime(startdate);
                DateTime eDate = Convert.ToDateTime(enddate);
                /*test chuyển đổi thời gian*/
                DateTime d = (DateTime)benhNhanDAO.layBenhNhan(3).ngaySinh;
                var date = d.ToString("yyyy-MM-dd");
                var result = DateTime.Compare(d, sDate); //<0 sớm hơn,  ==0 bằng, >0 muộn hơn

                //lấy các bệnh án có ngày vào viện nằm trong khoảng thời gian đã chọn
                var list = (from _benhAn in dbcontext.benhAn
                            join _benhNhan in dbcontext.benhNhan on _benhAn.benhNhanID equals _benhNhan.ID
                            join _phongBenh in dbcontext.phongBenh on _benhAn.phongBenhID equals _phongBenh.ID
                            join _trangThai in dbcontext.trangThai on _benhAn.trangThaiID equals _trangThai.ID
                            where DateTime.Compare((DateTime)_benhAn.ngayNhapVien, sDate) >= 0
                            && DateTime.Compare((DateTime)_benhAn.ngayNhapVien, eDate) <= 0
                            select new
                            {
                                ID = _benhNhan.ID,
                                tenBenhNhan = _benhNhan.ten,
                                //ngaySinh = _benhNhan.ngaySinh,
                                CMND = _benhNhan.CMND,
                                soDienThoai = _benhNhan.sdtBenhNhan,
                                ngayNhiemBenh = _benhAn.ngayNhapVien,
                                phongBenh = _phongBenh.tenPhong,
                                trangThai = _trangThai.tinhTrang,
                                
                            }).GroupBy(o => o.ID).Select(g => g.FirstOrDefault()).ToList();     
                return Json(new { code = 200, data = list }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { code = 404, mgs = "lỗi" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult thongkecakhoibenh()
        {            
            return View();
        }
        [HttpPost]
        public JsonResult thongKeCaKhoiBenh(string startdate, string enddate)
        {
            try
            {
                DateTime sDate = Convert.ToDateTime(startdate);
                DateTime eDate = Convert.ToDateTime(enddate);
                //lấy các bệnh án có ngày ra viện nằm trong khoảng thời gian đã chọn
                //và trạng thái là khỏi bệnh
                var list = (from _benhAn in dbcontext.benhAn
                            join _benhNhan in dbcontext.benhNhan on _benhAn.benhNhanID equals _benhNhan.ID
                            join _phongBenh in dbcontext.phongBenh on _benhAn.phongBenhID equals _phongBenh.ID
                            join _trangThai in dbcontext.trangThai on _benhAn.trangThaiID equals _trangThai.ID
                            where DateTime.Compare((DateTime)_benhAn.ngayXuatVien, sDate) >= 0
                            && DateTime.Compare((DateTime)_benhAn.ngayXuatVien, eDate) <= 0
                            && _trangThai.ID == 2
                            select new
                            {
                                ID = _benhNhan.ID,
                                tenBenhNhan = _benhNhan.ten,
                               // ngaySinh = _benhNhan.ngaySinh == null ? _benhNhan.ngaySinh.ToString() : DateTime.Today.ToString("dd:MM:yyyy"),
                                CMND = _benhNhan.CMND,
                                soDienThoai = _benhNhan.sdtBenhNhan,
                                ngayNhiemBenh = _benhAn.ngayNhapVien,
                                phongBenh = _phongBenh.tenPhong,
                                trangThai = _trangThai.tinhTrang
                            }).GroupBy(o => o.ID).Select(g => g.FirstOrDefault()).ToList();
                return Json(new { code = 200, data = list }, JsonRequestBehavior.AllowGet);
            }catch(Exception e)
            {
                return Json(new { code = 404 }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult thongkecatuvong()
        {
            
            return View();
        }
        [HttpPost]
        public JsonResult thongKeCaTuVong(string startdate, string enddate)
        {
            try
            {
                DateTime sDate = Convert.ToDateTime(startdate);
                DateTime eDate = Convert.ToDateTime(enddate);
                //lấy các bệnh án có trạng thái là tử vong trong khoảng thời gian đã chọn
                //
                var list = (from _benhAn in dbcontext.benhAn
                            join _benhNhan in dbcontext.benhNhan on _benhAn.benhNhanID equals _benhNhan.ID
                            join _phongBenh in dbcontext.phongBenh on _benhAn.phongBenhID equals _phongBenh.ID
                            join _trangThai in dbcontext.trangThai on _benhAn.trangThaiID equals _trangThai.ID
                            where _trangThai.ID == 3
                            select new
                            {
                                ID = _benhNhan.ID,
                                tenBenhNhan = _benhNhan.ten,
                               // ngaySinh = _benhNhan.ngaySinh == null ? _benhNhan.ngaySinh.ToString() : DateTime.Today.ToString("dd:MM:yyyy"),
                                CMND = _benhNhan.CMND,
                                soDienThoai = _benhNhan.sdtBenhNhan,
                                ngayNhiemBenh = _benhAn.ngayNhapVien,
                                phongBenh = _phongBenh.tenPhong,
                                trangThai = _trangThai.tinhTrang
                            }).GroupBy(o => o.ID).Select(g => g.FirstOrDefault()).ToList();
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
                var listBN = benhNhanDAO.layDSBenhNhan();
                var listBA = benhAnDAO.layDSBenhAn();
                List<BenhNhan> listkq = new List<BenhNhan>();
                foreach (BenhNhan a in listBN)
                {
                    int soLuongBA = (from _benhAn in dbcontext.benhAn
                                     join _phongBenh in dbcontext.phongBenh on _benhAn.phongBenhID equals _phongBenh.ID
                                     where _benhAn.benhNhanID == a.ID
                                     select new
                                     {
                                         tenBenhNhan = a.ten
                                     }
                                       ).Count();
                    if (soLuongBA > 1)
                    {
                        listkq.Add(a);
                    }
                }
                var list = (from res in listkq
                            select new
                            {
                                ID = res.ID,
                                ten = res.ten,
                                CMND = res.CMND,
                                sdtBenhNhan = res.sdtBenhNhan,
                                gioiTinh = res.gioiTinh
            }).ToList();
               return Json(new { code = 200, data = list }, JsonRequestBehavior.AllowGet);
                
            }
            catch (Exception e)
            {
                return Json(new { code = 404 }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}