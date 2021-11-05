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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult themnguoidung()
        {
            return View();
        }
        public ActionResult suanguoidung()
        {
            return View();
        }
        public ActionResult timkiemnguoidung()
        {
            return View();
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
    }
}