using DBCovid.models;
using PttkProject.DatabaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PttkProject.Controllers
{
    public class PatientController : Controller
    {
        private DBIO dBIO = new DBIO();
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
        [HttpPost]
        public JsonResult getPatientList(string input)
        {
            try
            {
                if(input.Length == 0)
                {
                    return Json(new { code = 404 }, JsonRequestBehavior.AllowGet);
                }
                List<BenhNhan> data = dBIO.layDSBenhNhan();
                return Json(new {code= 200,data=data},JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { code = 404}, JsonRequestBehavior.AllowGet);
            }

        }
    }
}