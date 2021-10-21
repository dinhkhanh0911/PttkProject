using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DBCovid.models;
namespace PttkProject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DBCovidContext p = new DBCovidContext();
            //tbl_nguoi n = new tbl_nguoi();
            //n.CMND = "1234";
            //n.ngaySinh = (DateTime)DateTime.Now;
            //n.diaChiID = 1;
            //n.tbl_nguoiDung = new tbl_nguoiDung();
            //n.tbl_nguoiDung.taiKhoan = "khanh";
            //n.tbl_nguoiDung.viTriLamViecID = 1;

            tbl_nguoiDung n = new tbl_nguoiDung();
            n.taiKhoan = "khanh";
            n.viTriLamViecID = 1;

            n.tbl_nguoi = new tbl_nguoi();
            n.tbl_nguoi.CMND = "1234";
            n.tbl_nguoi.ngaySinh = DateTime.Parse("2000/11/09");
            n.tbl_nguoi.diaChiID = 1;

            p.tbl_nguoiDung.Add(n);
            
            p.SaveChanges();
            
            
                
            

            return View();
        }

        
    }
}