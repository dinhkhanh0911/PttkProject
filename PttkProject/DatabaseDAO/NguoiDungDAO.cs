using DBCovid.Data;
using DBCovid.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PttkProject.DatabaseDAO
{
    public class NguoiDungDAO:DBCovidContext
    {
        public bool isNguoiDung(string taiKhoan)
        {
            var ok = this.nguoiDung.Where(n => n.taiKhoan == taiKhoan).FirstOrDefault();
            if(ok != null)
            {
                return true;
            }
            return false;
        }
        public bool isTaiKhoan(string taiKhoan,string matKhau)
        {
            var ok = this.nguoiDung.Where(n => n.taiKhoan == taiKhoan && n.matKhau == matKhau).FirstOrDefault();
            if (ok != null)
            {
                return true;
            }
            return false;
        }
        public bool isAdmin(string taiKhoan)
        {
            try
            {
                var ok = this.nguoiDung.Where(n => n.taiKhoan == taiKhoan && n.viTriLamViecID == 3).FirstOrDefault();
                if (ok != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public NguoiDung layNguoiDung(int id)
        {
            return nguoiDung.Where(s=>s.ID==id).FirstOrDefault();
        }
        public List<NguoiDung> timNguoiDung(string name)
        {
            try
            {
                var list = (from s in nguoiDung 
                            where s.ten.Contains(name)||s.CMND.Contains(name)
                            select s).ToList();
                foreach (var it in list)
                {
                    it.viTriLamViec = viTriLamViec.Find(it.viTriLamViecID);
                }
                return list;
            }
            catch(Exception e)
            {
                return null;
            }
        }
        public string timNguoiDung()
        {
            try
            {
                return "abc";
            }
            catch (Exception e)
            {
                return "";
            }
        }
        public void xoaNguoiDung(int id)
        {
            var nd = nguoiDung.Where(s => s.ID == id).FirstOrDefault();
            Entry(nd).State = EntityState.Deleted;
            SaveChanges();
        }
        public void themNguoiDung(NguoiDung nd)
        {
            nguoiDung.Add(nd);
            SaveChanges();
        }
        public void capNhatNguoiDung(NguoiDung nd)
        {
            Entry(nd).State = EntityState.Modified;
            SaveChanges();
        }
        public List<ViTriLamViec> layDSViTriLamViec()
        {
            return viTriLamViec.ToList();
        }
    }
}