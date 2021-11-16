using DBCovid.Data;
using DBCovid.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PttkProject.DatabaseDAO
{
    public class TTDieuTri : DBCovidContext
    {
        /* Thông tin điều trị */
        public bool themThongTinDieuTri(ThongTinDieuTri t)
        {
            try
            {
                thongtinDieuTri.Add(t);
                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<ThongTinDieuTri> layDSThongTinDieuTri(int benhAnID)
        {
            List<ThongTinDieuTri> list;
            try
            {
                list = thongtinDieuTri.Where(t => t.benhAnID == benhAnID).ToList();
                return list;
            }
            catch (Exception e)
            {
                list = new List<ThongTinDieuTri>();
                return list;
            }
        }
        public bool xoaThongTinDieuTri(int ID)
        {
            try
            {
                ThongTinDieuTri t = thongtinDieuTri.Where(x => x.ID == ID).FirstOrDefault();
                thongtinDieuTri.Remove(t);
                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}