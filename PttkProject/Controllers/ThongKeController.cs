using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PttkProject.Controllers
{
    public class ThongKeController : Controller
    {
        // GET: ThongKe
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult thongkecanhiem()
        {

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