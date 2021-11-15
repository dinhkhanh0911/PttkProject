using DBCovid.Data;
using DBCovid.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PttkProject.Controllers
{
    public class HomeController : Controller
    {
        private DBCovidContext data = new DBCovidContext();
        public ActionResult Index()
        {
            return View();
        }
    }
}