using DBCovid.Data;
using DBCovid.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PttkProject.DatabaseDAO
{
    public class PhongBenhDAO: DBCovidContext
    {
        private DBCovidContext data = new DBCovidContext();
        public List<PhongBenh> layDSPhongBenh()
        {
            List<PhongBenh> p = phongBenh.ToList();
            return p;
        }
        public List<PhongBenh> layDSPhongBenh(int loaiPhongID)
        {
            List<PhongBenh> p = phongBenh.Where(x => x.loaiPhongID == loaiPhongID).ToList();
            return p;
        }
        public List<LoaiPhong> layDSLoaiPhong()
        {
            List<LoaiPhong> l = loaiPhong.ToList();
            return l;
        }

        public bool themPhongBenh(PhongBenh pb)
        {
            try
            {         
                data.phongBenh.Add(pb);
                data.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }
    }
}