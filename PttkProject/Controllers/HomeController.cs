using CovidModels.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PttkProject.Controllers
{
    public class HomeController : Controller
    {
        private PttkModel db = new PttkModel();
        public ActionResult Index()
        {
            var s = db.tbl_benhAn.ToList();
            return View();
        }

        
    }
}