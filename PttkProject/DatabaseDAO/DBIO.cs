using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBCovid.Data;
using DBCovid.models;

namespace PttkProject.DatabaseDAO
{
    
    public class DBIO
    {
        private DBCovidContext data = new DBCovidContext();
        public List<BenhNhan> layDSBenhNhan()
        {
            List<BenhNhan> b = data.benhNhan.ToList();
            return b;
        }
        
        public string layTenBenhNhan(int ID)
        {

            try
            {
                string tenBenhNhan = data.benhNhan.Where(x => x.ID == ID).FirstOrDefault().ten;
                return tenBenhNhan;
            }
            catch(Exception e)
            {
                return "";
            }
        }
        public List<BenhNhan> layDSBenhNhan(string input)
        {
            List<BenhNhan> b = data.benhNhan.Where(x => x.CMND == input || x.ten == input).ToList();
            return b;
        }
        public List<PhongBenh> layDSPhongBenh()
        {
            List<PhongBenh> p = data.phongBenh.ToList();
            return p;
        }
        public List<PhongBenh> layDSPhongBenh(int loaiPhongID)
        {
            List<PhongBenh> p = data.phongBenh.Where(x => x.loaiPhongID == loaiPhongID).ToList();
            return p;
        }
        public List<LoaiPhong> layDSLoaiPhong()
        {
            List<LoaiPhong> l= data.loaiPhong.ToList();
            return l;
        }
        public List<TrangThai> layDSTrangThai()
        {
            List<TrangThai> t = data.trangThai.ToList();
            return t;
        }
    }

}