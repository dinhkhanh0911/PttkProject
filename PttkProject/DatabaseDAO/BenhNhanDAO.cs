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
        public int layBenhNhanID(int benhAnID)
        {
            try
            {
                return data.benhAn.Where(b => b.ID == benhAnID).FirstOrDefault().benhNhanID;
            }
            catch (Exception e)
            {
                return 0;
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
        public string layTenBenhNhan(int ID)
        {

            try
            {
                string tenBenhNhan = data.benhNhan.Where(x => x.ID == ID).FirstOrDefault().ten;
                return tenBenhNhan;
            }
            catch (Exception e)
            {
                return "";
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
        /* trạng thái */
        public List<TrangThai> layDSTrangThai()
        {
            List<TrangThai> t = data.trangThai.ToList();
            return t;
        }
        /*Thông tin truy vết*/
        public bool themThongTinTruyVet(ThongTinTruyVet t)
        {
            try
            {
                data.thongTinTruyVet.Add(t);
                data.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool xoaThongTinTruyVet(int ID)
        {
            try
            {
                ThongTinTruyVet t = data.thongTinTruyVet.Where(x => x.ID == ID).FirstOrDefault();
                data.thongTinTruyVet.Remove(t);
                data.SaveChanges();
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

            var list = (from tt in data.thongTinTruyVet
                        join x in data.xa
                        on tt.xaID equals x.ID

                        join h in data.huyen
                        on x.huyenID equals h.ID
                        join t in data.tinh
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
            //}
            //catch (Exception e)
            //{
            //    list = new List<TTTruyVet>();
            //    return list;
            //}
        }
        /*Thông tin điều trị */
        public bool themThongTinDieuTri(ThongTinDieuTri t)
        {
            try
            {
                data.thongtinDieuTri.Add(t);
                data.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool xoaThongTinDieuTri(int ID)
        {
            try
            {
                ThongTinDieuTri t = data.thongtinDieuTri.Where(x => x.ID == ID).FirstOrDefault();
                data.thongtinDieuTri.Remove(t);
                data.SaveChanges();
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
                list = data.thongtinDieuTri.Where(t => t.benhAnID == benhAnID).ToList();
                return list;
            }
            catch (Exception e)
            {
                list = new List<ThongTinDieuTri>();
                return list;
            }
        }
    }
}