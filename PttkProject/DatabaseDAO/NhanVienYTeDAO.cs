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
        public bool themNhanVienYTe(NhanVienYTe nv)
        {
            try
            {
                nhanVienYTe.Add(nv);
                SaveChanges();
                return true;
            }
            catch(Exception e) { return false; }
            
        }
        public List<NhanVienYTe> timKiemNvYTe(string name)
        {
            try
            {
                var list = (from s in nhanVienYTe
                            where s.ten.Contains(name) || s.CMND.Contains(name)
                            select s).ToList();
                foreach(var it in list)
                {
                    it.viTriLamViec = viTriLamViec.Find(it.viTriLamViecID);
                }
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public void xoaNvYTe(int id)
        {
            var nv = nhanVienYTe.Where(s => s.ID == id).FirstOrDefault();
            nhanVienYTe.Remove(nv);
            SaveChanges();
        }
        public void capNhatTTNhanVien(NhanVienYTe nv)
        {
            Entry(nv).State = EntityState.Modified;
            SaveChanges();
        }
        public List<ViTriLamViec> layDSViTriLamViec()
        {
            return viTriLamViec.ToList();
        }
    }
}