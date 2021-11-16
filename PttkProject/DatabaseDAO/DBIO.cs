﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DBCovid.Data;
using DBCovid.models;
using PttkProject.models;

namespace PttkProject.DatabaseDAO
{
    
    public class DBIO
    {
        private DBCovidContext data = new DBCovidContext();

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
        
        public List<PhongBenh> layDSPhongBenh()
        {
            List<PhongBenh> p = data.phongBenh.Where(x => x.soGiuongHienTai < x.soGiuongToiDa).ToList();
            return p;
        }
        public List<PhongBenh> layDSPhongBenh(int loaiPhongID)
        {
            List<PhongBenh> p = data.phongBenh.Where(x => x.loaiPhongID == loaiPhongID && x.soGiuongHienTai < x.soGiuongToiDa).ToList();
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
        public List<ViTriLamViec> layDSViTriLamViec()
        {
            return data.viTriLamViec.ToList();
        }
        /*Bệnh Án*/
        public bool themBenhAn(BenhAn model)
        {

            try
            {
                data.benhAn.Add(model);
                data.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }

            
        }
        public bool isBenhAn(int? ID)
        {
            try
            {
                return (data.benhAn.Where(b => b.ID == ID).FirstOrDefault() != null);
            }
            catch(Exception e)
            {
                return true;
            }
        }
        public BenhAn layBenhAn(int ID)
        {
            return data.benhAn.Where(b => b.ID == ID).FirstOrDefault();
        }
        public int layBenhNhanID(int benhAnID)
        {
            try
            {
                return data.benhAn.Where(b => b.ID == benhAnID).FirstOrDefault().benhNhanID;
            }
            catch(Exception e)
            {
                return 0;
            }
            
        }


        /* Thông tin điều trị */
        public bool themThongTinDieuTri(ThongTinDieuTri t)
        {
            try
            {
                data.thongtinDieuTri.Add(t);
                data.SaveChanges();
                return true;
            }
            catch(Exception e)
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
            catch(Exception e)
            {
                list = new List<ThongTinDieuTri>();
                return list;
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
        public Object layDSThongTinTruyVet(int benhAnID)
        {
            //List< TTTruyVet >list;
            
              var  list = (from tt in data.thongTinTruyVet
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
        public bool xoaThongTinTruyVet(int ID)
        {
            try
            {
                ThongTinTruyVet t = data.thongTinTruyVet.Where(x => x.ID == ID).FirstOrDefault();
                data.thongTinTruyVet.Remove(t);
                data.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        
    }

}