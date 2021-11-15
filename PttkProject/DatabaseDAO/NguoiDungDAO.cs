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
        public void capNhatNguoiDung(NguoiDung nd)
        {
            Entry(nd).State = EntityState.Modified;
            SaveChanges();
        }

    }
}