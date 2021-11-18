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
                return s;
            }
            catch(Exception e)
            {
                return null;
            }
        }
        public BenhNhan layBenhNhan_BA(int idBenhAn)
        {
            BenhAn a = benhAn.Find(idBenhAn);
            try
            {
                var s = benhNhan.Find(a.benhNhanID);
                return s;
            }
            catch(Exception e)
            {
                return null;
            }
        }

        public bool capNhatTTBenhNhan(BenhNhan bn)
        {
            try
            {
                data.Entry(bn).State = EntityState.Modified;
                data.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
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
        public int demSoCaDangNhiemBenh()
        {
            int count = 0;
            try
            {
                count = this.benhAn.Count(x => x.trangThaiID == 1);
                return count;
            }
            catch (Exception e)
            {
                count = 0;
                return count;
            }
        }
        public int demSoCaKhoiBenh()
        {
            int count = 0;
            try
            {
                count = this.benhAn.Count(x => x.trangThaiID == 2);
                return count;
            }
            catch (Exception e)
            {
                count = 0;
                return count;
            }
        }
        public int demSoCaTuVong()
        {
            int count = 0;
            try
            {
                count = this.benhAn.Count(x => x.trangThaiID == 3);
                return count;
            }
            catch (Exception e)
            {
                count = 0;
                return count;
            }
        }
    }
}