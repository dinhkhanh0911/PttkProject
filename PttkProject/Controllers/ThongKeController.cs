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
                            where DateTime.Compare((DateTime)_benhAn.ngayNhapVien, sDate) >= 0
                            && DateTime.Compare((DateTime)_benhAn.ngayNhapVien, eDate) <= 0
                            select new
                            {
                                tenBenhNhan = _benhNhan.ten,
                                ngaySinh = _benhNhan.ngaySinh,
                                CMND = _benhNhan.CMND,
                                soDienThoai = _benhNhan.sdtBenhNhan,
                                ngayNhiemBenh = _benhAn.ngayNhapVien,
                                phongBenh = _phongBenh.tenPhong,
                                trangThai = _benhAn.trangThai
                            }).ToList();
                var list2 = (from _benhAn in dbcontext.benhAn
                             join _benhNhan in dbcontext.benhNhan on _benhAn.benhNhanID equals _benhNhan.ID
                             join _phongBenh in dbcontext.phongBenh on _benhAn.phongBenhID equals _phongBenh.ID
                             select new
                             {
                                 tenBenhNhan = _benhNhan.ten,
                                 ngaySinh = _benhNhan.ngaySinh.ToString(),
                                 CMND = _benhNhan.CMND,
                                 soDienThoai = _benhNhan.sdtBenhNhan,
                                 ngayNhiemBenh = _benhAn.ngayNhapVien.ToString(),
                                 phongBenh = _phongBenh.tenPhong,
                                 trangThai = _benhAn.trangThai.tinhTrang
                             }).ToList();
                return Json(new { code = 200, data = list2 }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { code = 404, mgs = "lỗi" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult thongkecakhoibenh(string startdate, string enddate)
        {
            DateTime sDate = Convert.ToDateTime(startdate);
            DateTime eDate = Convert.ToDateTime(enddate);
            //lấy các bệnh án có ngày ra viện nằm trong khoảng thời gian đã chọn
            var list = (from _benhAn in dbcontext.benhAn
                        join _benhNhan in dbcontext.benhNhan on _benhAn.benhNhanID equals _benhNhan.ID
                        join _phongBenh in dbcontext.phongBenh on _benhAn.phongBenhID equals _phongBenh.ID
                        where DateTime.Compare((DateTime)_benhAn.ngayXuatVien, sDate) >= 0
                        && DateTime.Compare((DateTime)_benhAn.ngayXuatVien, eDate) <= 0
                        && _benhAn.trangThai.ID == 2
                        select new
                        {
                            tenBenhNhan = _benhNhan.ten,
                            ngaySinh = _benhNhan.ngaySinh,
                            CMND = _benhNhan.CMND,
                            soDienThoai = _benhNhan.sdtBenhNhan,
                            ngayNhiemBenh = _benhAn.ngayNhapVien,
                            phongBenh = _phongBenh.tenPhong,
                            trangThai = _benhAn.trangThai
                        }).ToList();
            return View();
        }
        public ActionResult thongkecatuvong(string startdate, string enddate)
        {
            DateTime sDate = Convert.ToDateTime(startdate);
            DateTime eDate = Convert.ToDateTime(enddate);
            //lấy các bệnh án có trạng thái là tử vong trong khoảng thời gian đã chọn
            var list = (from _benhAn in dbcontext.benhAn
                        join _benhNhan in dbcontext.benhNhan on _benhAn.benhNhanID equals _benhNhan.ID
                        join _phongBenh in dbcontext.phongBenh on _benhAn.phongBenhID equals _phongBenh.ID
                        where _benhAn.trangThai.ID == 3
                        select new
                        {
                            tenBenhNhan = _benhNhan.ten,
                            ngaySinh = _benhNhan.ngaySinh,
                            CMND = _benhNhan.CMND,
                            soDienThoai = _benhNhan.sdtBenhNhan,
                            ngayNhiemBenh = _benhAn.ngayNhapVien,
                            phongBenh = _phongBenh.tenPhong,
                            trangThai = _benhAn.trangThai
                        }).ToList();
            return View();
        }
        public ActionResult thongkecaduongtinhtrolai(string startdate, string enddate)
        {
            DateTime sDate = Convert.ToDateTime(startdate);
            DateTime eDate = Convert.ToDateTime(enddate);
            //lấy các bệnh nhân có 2 bệnh án trở lên (chưa làm)
            var list = (from _benhAn in dbcontext.benhAn
                        join _benhNhan in dbcontext.benhNhan on _benhAn.benhNhanID equals _benhNhan.ID
                        join _phongBenh in dbcontext.phongBenh on _benhAn.phongBenhID equals _phongBenh.ID
                        where _benhAn.trangThai.ID == 3
                        select new
                        {
                            tenBenhNhan = _benhNhan.ten,
                            ngaySinh = _benhNhan.ngaySinh,
                            CMND = _benhNhan.CMND,
                            soDienThoai = _benhNhan.sdtBenhNhan,
                            ngayNhiemBenh = _benhAn.ngayNhapVien,
                            phongBenh = _phongBenh.tenPhong,
                            trangThai = _benhAn.trangThai
                        }).ToList();
            return View();
        }
    }
}