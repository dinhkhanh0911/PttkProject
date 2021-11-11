using DBCovid.Data;
using DBCovid.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PttkProject.DatabaseDAO
{
    public class BenhNhanDAO:DBCovidContext
    {
        private DBCovidContext data = new DBCovidContext();
        /*Bênh nhân */
        public List<BenhNhan> layDSBenhNhan()
        {
            List<BenhNhan> b = data.benhNhan.ToList();
            return b;
        }
        public BenhNhan layBenhNhan(int id)
        {
            BenhNhan a = new BenhNhan();
            try
            {
                var s = benhNhan.Find(id);
                //a = data.benhNhan.Find(id);
                return s;
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

        public bool themBenhNhan(BenhNhan bn)
        {
            try
            {
                data.benhNhan.Add(bn);
                data.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public List<BenhNhan> layDSBenhNhan(string input)
        {
            List<BenhNhan> b = data.benhNhan.Where(x => x.CMND == input || x.ten == input).ToList();
            
            return b;
        }
        public bool xoaBenhNhan(int ID)
        {
            try
            {
                BenhNhan b = data.benhNhan.Where(x => x.ID == ID).FirstOrDefault();
                data.benhNhan.Remove(b);
                data.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}