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

        /*Nhân viên y tế*/
        public List<NhanVienYTe> layDSNhanVienYTe()
        {
            return data.nhanVienYTe.ToList();
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
        /*Địa chỉ*/
        public List<Tinh> layDSTinh()
        {
            return data.tinh.ToList();
        }
        public List<Huyen> layDSHuyen(int tinhID)
        {
            List<Huyen> list;
            try
            {
                list = data.huyen.Where(h => h.tinhID == tinhID).ToList();
            }
            catch(Exception e)
            {
                list = new List<Huyen>();
            }
            return list;
        }
        public List<Xa> layDSXa(int huyenID)
        {
            List<Xa> list;
            try
            {
                list = data.xa.Where(x => x.huyenID == huyenID).ToList();
            }
            catch (Exception e)
            {
                list = new List<Xa>();
            }
            return list;
        }
    }

}