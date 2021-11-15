using DBCovid.models;
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
        private DiaChiDAO diaChi = new DiaChiDAO();
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

        public ActionResult capnhatttnhanvienyte(int id, string mgs)
        {
            ViewBag.message = mgs;
            NhanVienYTe nv = nvYTe.layNhanVienYTe(id);
            setViewBagDiaChi();
            ViewBag.viTriLamViec = new SelectList(dBIO.layDSViTriLamViec(), "ID", "tenVitri");
            return View(nv);
        }
        [HttpPost]
        public ActionResult capNhatNhanVienYte(NhanVienYTe nv)
        {
            try
            {
                nvYTe.capNhatTTNhanVien(nv);
                return RedirectToAction("capnhatttnhanvienyte", "NhanVienYTe", new { id = nv.ID, mgs = "Sửa thành công" });
            }
            catch (Exception e)
            {
                //lloi
                return RedirectToAction("capnhatttnhanvienyte", "NhanVienYTe", new { id = nv.ID, mgs = "Sửa thất bại" });
            }
        }
        public ActionResult timkiemnhanvienyte()
        {
            return View();
        }
        private void setViewBagDiaChi()
        {
            List<Tinh> tinhs = diaChi.layDSTinh();
            List<Huyen> huyens = new List<Huyen>();
            List<Xa> xas = new List<Xa>();
            if (tinhs.Count > 0)
            {
                huyens = diaChi.layDSHuyen(tinhs[0].ID);
            }
            if (huyens.Count > 0)
            {
                xas = diaChi.layDSXa(huyens[0].ID);
            }

            ViewBag.tinhs = new SelectList(tinhs, "ID", "tenTinh");
            ViewBag.huyens = new SelectList(huyens, "ID", "tenHuyen");
            ViewBag.xas = new SelectList(xas, "ID", "tenXa");

        }

    }
}