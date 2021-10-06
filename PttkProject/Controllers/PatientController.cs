using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PttkProject.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ImportInformation()
        {
            return View();
        }
        public ActionResult UpdateInformation()
        {
            return View();
        }
        public ActionResult SearchPatient()
        {
            return View();
        }
        public ActionResult ImportMedicalRecord()
        {
            return View();
        }
        public ActionResult UpdateMedicalRecord()
        {
            return View();
        }
    }
}