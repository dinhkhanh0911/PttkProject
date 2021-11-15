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
        public ActionResult thongKeCaNhiem()
        {
            var startdate = Request.Form["startdate"];
            var enddate = Request.Form["enddate"];
            DateTime sDate = Convert.ToDateTime(startdate);
            DateTime eDate = Convert.ToDateTime(enddate);
            /*test chuyển đổi thời gian*/
            DateTime d = (DateTime) benhNhanDAO.layBenhNhan(3).ngaySinh;
            var date = d.ToString("yyyy-MM-dd");
            var result = DateTime.Compare(d, sDate); //<0 sớm hơn,  ==0 bằng, >0 muộn hơn
            
            //lấy các bệnh án có ngày vào viện nằm trong khoảng thời gian đã chọn
            var list = (from _benhAn in dbcontext.benhAn
                        join _benhNhan in dbcontext.benhNhan on _benhAn.benhNhanID equals _benhNhan.ID
                        join _phongBenh in dbcontext.phongBenh on _benhAn.phongBenhID equals _phongBenh.ID
                        where DateTime.Compare((DateTime)_benhAn.ngayNhapVien,sDate)>=0
                        && DateTime.Compare((DateTime)_benhAn.ngayNhapVien, eDate)<=0
                        select new
                        {
                            tenBenhNhan = _benhNhan.ten,
                            ngayNhiemBenh = _benhAn.ngayNhapVien,
                            soDienThoai = _benhNhan.sdtBenhNhan,
                            CMND = _benhNhan.CMND,
                            trangThai =_benhAn.trangThai,
                            PhongBenh = _phongBenh.tenPhong
                        }
                        
                        ).ToList();
            return View();
        }
        public ActionResult thongkecakhoibenh()
        {
            return View();
        }
        public ActionResult thongkecatuvong()
        {
            return View();
        }
        public ActionResult thongkecaduongtinhtrolai()
        {
            return View();
        }
    }
}