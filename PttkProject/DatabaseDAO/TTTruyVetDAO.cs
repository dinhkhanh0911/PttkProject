using DBCovid.Data;
using DBCovid.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PttkProject.DatabaseDAO
{
    public class TTTruyVetDAO: DBCovidContext
    {
        /*Thông tin truy vết*/
        public bool themThongTinTruyVet(ThongTinTruyVet t)
        {
            try
            {
                thongTinTruyVet.Add(t);
                SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public Object layDSThongTinTruyVet(int benhAnID)
        {
            //List< TTTruyVet >list;

            var list = (from tt in thongTinTruyVet
                        join x in xa
                        on tt.xaID equals x.ID

                        join h in huyen
                        on x.huyenID equals h.ID
                        join t in tinh
                        on h.tinhID equals t.ID

                        where tt.benhAnID == benhAnID
                        select new
                        {
                            ID = tt.ID,
                            thoiGian = tt.thoiGian,
                            diaChiChiTiet = tt.diaChichiTiet,
                            xa = x.tenXa,
                            huyen = h.tenHuyen,
                            tinh = t.tenTinh,
                        }).ToList();
            return list;
        }
        public bool xoaThongTinTruyVet(int ID)
        {
            try
            {
                ThongTinTruyVet t = thongTinTruyVet.Where(x => x.ID == ID).FirstOrDefault();
                thongTinTruyVet.Remove(t);
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