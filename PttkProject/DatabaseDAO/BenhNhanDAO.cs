using DBCovid.Data;
using DBCovid.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PttkProject.DatabaseDAO
{
    public class BenhNhanDAO
    {
        private DBCovidContext data = new DBCovidContext();
        public BenhNhan layBenhNhan(int id)
        {
            BenhNhan benhNhan = new BenhNhan();
            try
            {
                benhNhan = data.benhNhan.Find(id);
                return benhNhan;
            }
            catch(Exception e)
            {
                return null;
            }
        }
        public void capNhatTTBenhNhan(BenhNhan bn)
        {
            data.Entry(bn).State = EntityState.Modified;
            data.SaveChanges();
        }
    }
}