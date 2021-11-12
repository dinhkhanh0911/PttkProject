using PttkProject.DatabaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PttkProject.Controllers
{
    public class NhanVienYTeController : Controller
    {
        // GET: MedicalStaff
        private DBIO dBIO = new DBIO();
        private NhanVienYTeDAO nvYTe = new NhanVienYTeDAO();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult themnhanvienyte()
        {
            return View();
        }

        public ActionResult capnhatttnhanvienyte()
        {
            return View();
        }
        public ActionResult timkiemnhanvienyte()
        {
            return View();
        }

    }
}