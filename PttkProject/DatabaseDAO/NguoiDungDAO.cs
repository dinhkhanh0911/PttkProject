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
        public NguoiDung layNguoiDung(int id)
        {
            return nguoiDung.Where(s=>s.ID==id).FirstOrDefault();
        }
        public List<NguoiDung> layDSNguoiDung(string name)
        {
            try
            {
                var list = nguoiDung.ToList();
                return list;
            }
            catch(Exception e)
            {
                return null;
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

    }
}