using DBCovid.Data;
using DBCovid.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PttkProject.DatabaseDAO
{
    public class BenhAnDAO : DBCovidContext
    {
        DBCovidContext dc = new DBCovidContext();
        public BenhAn layBenhAnMoiNhat(int idBenhNhan)
        {
            try
            {
                BenhAn BA = (from ba in benhAn
                             join tt in trangThai
                             on ba.trangThaiID equals tt.ID
                             where tt.ID == 1 && ba.benhNhanID==idBenhNhan
                             select ba).FirstOrDefault();
                return BA;
            }
            catch(Exception e)
            {
                return null;
            }
        }
        public void capNhatTTBenhAn(BenhAn ba)
        {
            try
            {
                dc.Entry(ba).State = EntityState.Modified;
                dc.SaveChanges();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public List<ThongTinDieuTri> layDSTTDieuTri(int idBenhAn)
        {
            try
            {
                var list = thongtinDieuTri.Where(s => s.benhAnID == idBenhAn).ToList();
                return list;
            }
            catch(Exception e)
            {
                return null;
            }
        }
        public List<TrangThai> layDSTrangThai()
        {
            try
            {
                return trangThai.ToList();
            }
            catch
            {
                return null;
            }
        }
        public List<ThongTinTruyVet> layDSTTTruyVet(int idBenhAn)
        {
            try
            {
                var list = thongTinTruyVet.Where(s => s.benhAnID == idBenhAn).ToList();
                return list;
            }
            catch(Exception e)
            {
                return null;
            }
        }

    }
}