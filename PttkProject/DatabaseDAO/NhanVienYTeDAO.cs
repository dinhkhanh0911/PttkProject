using DBCovid.Data;
using DBCovid.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PttkProject.DatabaseDAO
{
    public class NhanVienYTeDAO: DBCovidContext
    {
        /*Nhân viên y tế*/
        public List<NhanVienYTe> layDSNhanVienYTe()
        {
            return nhanVienYTe.ToList();
        }
        public NhanVienYTe layNhanVienYTe(int id)
        {
            return nhanVienYTe.Where(s=>s.ID==id).FirstOrDefault();
        }
        public void capNhatTTNhanVien(NhanVienYTe nv)
        {
            Entry(nv).State = EntityState.Modified;
            SaveChanges();
        }

    }
}