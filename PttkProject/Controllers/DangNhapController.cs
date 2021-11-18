using PttkProject.Common;
using PttkProject.DatabaseDAO;
using PttkProject.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace PttkProject.Controllers
{
    public class DangNhapController : Controller
    {
        private NguoiDungDAO nguoiDung = new NguoiDungDAO();
        // GET: DangNhap
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult dangnhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult dangnhap(User u)
        {
            
            if (ModelState.IsValid)
            {
                
                if (nguoiDung.isTaiKhoan(u.taiKhoan,Encypter.MD5Hash(u.matKhau)))
                {
                    var userSession = u;
                    if (nguoiDung.isAdmin(u.taiKhoan))
                    {
                        Session.Add(CommonConstant.ADMIN_SESSION, userSession);
                        return Redirect("/trang-chu/index");
                    }
                    Session.Add(CommonConstant.USER_SESSION, userSession);
                    return Redirect("/trang-chu/index");
                }
            }
            return Redirect("/dang-nhap/dang-nhap");
        }
        public ActionResult dangxuat()
        {
            Session.Clear();
            return Redirect("/dang-nhap/dang-nhap");
        }
        public ActionResult quyenmatkhau()
        {
            return View();
        }
        public ActionResult doimatkhau()
        {
            return View();
        }

    }
}