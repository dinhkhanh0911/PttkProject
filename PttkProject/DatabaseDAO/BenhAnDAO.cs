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
        public bool themBenhAn(BenhAn model)
        {

            try
            {
                this.benhAn.Add(model);
                this.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }


        }

        public BenhAn layBenhAn(int id)
        {
            try
            {
                BenhAn BA = benhAn.Find(id);
                return BA;
            }
            catch(Exception e)
            {
                return null;
            }
        }
        public List<BenhAn> layDSBenhAn()
        {
            try
            {
                var list = benhAn.ToList();
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<BenhAn> layDSBenhAn(int idBenhNhan)
        {
            try
            {
                var list = benhAn.Where(s=>s.benhNhanID==idBenhNhan).ToList();
                return list;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        
        public bool capNhatTTBenhAn(BenhAn ba)
        {
            try
            {
                Entry(ba).State = EntityState.Modified;
                SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
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