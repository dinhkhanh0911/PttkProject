using DBCovid.Data;
using DBCovid.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PttkProject.DatabaseDAO
{
    public class XuatDuLieuDAO: DBCovidContext
    {
        public List<BenhAn> xuatBenhAn(int idBenhNhan)
        {
            try
            {
                List<BenhAn> BA = benhAn.Where(s => s.benhNhanID == idBenhNhan).ToList();
                foreach(var s in BA)
                {
                    s.benhNhan = benhNhan.Where(ss => ss.ID == s.benhNhanID).FirstOrDefault();
                }
                return BA;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public List<ThongTinTruyVet> xuatTTTruyVet(int idBenhAn)
        {
            try
            {
                List<ThongTinTruyVet> tv = thongTinTruyVet.Where(s => s.benhAnID == idBenhAn).ToList();
                foreach(var s in tv)
                {
                    s.benhAn = benhAn.Where(ss => ss.ID == s.benhAnID).FirstOrDefault();
                }
                return tv;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}