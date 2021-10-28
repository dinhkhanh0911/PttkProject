using DBCovid.models;
using PttkProject.DatabaseDAO;
using PttkProject.models;
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
            int ID = 1;
            string tenBenhNhan = dBIO.layTenBenhNhan(ID);
            if(tenBenhNhan != "")
            {
                BenhNhan b = new BenhNhan();
            }
            MediaRecord model = new MediaRecord();
            model.tenBenhNhan = "Đinh Văn Khánh";
            model.benhNhanID = 1;
            setViewBagImportMedicalRecord();
            return View(model);
        }
        [HttpPost]
        public ActionResult ImportMedicalRecord(MediaRecord model)
        {
            if (ModelState.IsValid)
            {
                setViewBagImportMedicalRecord();
                return View(model);
            }
            else
            {
                setViewBagImportMedicalRecord();
                return View(model);
            }
            
        }
        [HttpPost]
        public JsonResult getListRoom(int loaiPhongID)
        {
            try
            {

                List<PhongBenh> data = dBIO.layDSPhongBenh(loaiPhongID) ;
                return Json(new { code = 200, listRoom = data }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { code = 404 }, JsonRequestBehavior.AllowGet);
            }
        }
        private void setViewBagImportMedicalRecord()
        {
            List<LoaiPhong> l = dBIO.layDSLoaiPhong();
            List<PhongBenh> p = new List<PhongBenh>();
            List<TrangThai> t = dBIO.layDSTrangThai();
            if (l.Count() > 0)
            {
                p = dBIO.layDSPhongBenh(l[0].ID);
            }
            ViewBag.loaiPhong = new SelectList(l, "ID", "tenLoaiPhong");
            ViewBag.phongBenh = new SelectList(p, "ID", "tenPhong");
            ViewBag.trangThai = new SelectList(t, "ID", "tinhTrang");
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