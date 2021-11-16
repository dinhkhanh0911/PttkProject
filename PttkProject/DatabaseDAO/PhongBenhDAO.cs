using DBCovid.Data;
using DBCovid.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PttkProject.DatabaseDAO
{
    public class PhongBenhDAO: DBCovidContext
    {
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
        public List<PhongBenh> timKiemPhong(string ten)
        {
            List<PhongBenh> l = (from s in phongBenh
                                 where s.tenPhong.Contains(ten)
                                 select s).ToList();
            return l;
        }
        public void xoaPhong(int id)
        {
            var p = phongBenh.Where(s => s.ID == id).FirstOrDefault();
            Entry(p).State = EntityState.Deleted;
            SaveChanges();
        }
        public PhongBenh layPhongBenh(int id)
        {
            try
            {
                var pb = phongBenh.Where(s => s.ID == id).FirstOrDefault();
                return pb;
            }
            catch
            {
                return null;
            }
        }
        public bool capNhatPhongBenh(PhongBenh pb)
        {
            try
            {
                Entry(pb).State = EntityState.Modified;
                SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool themPhongBenh(PhongBenh pb)
        {
            try
            {
                pb.benhVienID = 1;
                pb.soGiuongHienTai = 0;
                phongBenh.Add(pb);
                SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }
        public void tangPhong(int phongID)
        {
            PhongBenh p = this.phongBenh.Where(x => x.ID == phongID).FirstOrDefault();
            if (p != null)
            {
                p.soGiuongHienTai = p.soGiuongHienTai + 1;
                try
                {
                    Entry(p).State = EntityState.Modified;
                }
                catch (Exception e)
                {

                }
            }
        }
    }
}