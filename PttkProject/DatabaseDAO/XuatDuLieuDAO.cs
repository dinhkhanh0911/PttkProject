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
        public List<BenhAn> xuatBenhAn(int id)
        {
            try
            {
                List<BenhAn> BA = benhAn.Where(s => s.ID == id).ToList();
                foreach(var s in BA)
                {
                    s.benhNhan = benhNhan.Where(ss => ss.ID == s.benhNhanID).FirstOrDefault();
                    s.benhNhan.xa = xa.Find(s.benhNhan.xaID);
                    s.benhNhan.xa.huyen = huyen.Find(s.benhNhan.xa.huyenID);
                    s.benhNhan.xa.huyen.tinh = tinh.Find(s.benhNhan.xa.huyen.tinhID);
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
        public List<ThongTinDieuTri> xuatTTDieuTri(int idBenhAn)
        {
            try
            {
                List<ThongTinDieuTri> tv = thongtinDieuTri.Where(s => s.benhAnID == idBenhAn).ToList();
                foreach(var s in tv)
                {
                    s.benhAn = benhAn.Find(idBenhAn);
                }
                return tv;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public dynamic xuatBaoCaoCaNhiem(string startdate, string enddate)
        {
            DateTime sDate = Convert.ToDateTime(startdate);
            DateTime eDate = Convert.ToDateTime(enddate);

            var list = (from _benhAn in benhAn
                        join _benhNhan in benhNhan on _benhAn.benhNhanID equals _benhNhan.ID
                        join _phongBenh in phongBenh on _benhAn.phongBenhID equals _phongBenh.ID
                        where DateTime.Compare((DateTime)_benhAn.ngayNhapVien, sDate) >= 0
                        && DateTime.Compare((DateTime)_benhAn.ngayNhapVien, eDate) <= 0
                        select new
                        {
                            tenBenhNhan = _benhNhan.ten,
                            ngaySinh = _benhNhan.ngaySinh,
                            CMND = _benhNhan.CMND,
                            soDienThoai = _benhNhan.sdtBenhNhan,
                            ngayNhiemBenh = _benhAn.ngayNhapVien,
                            phongBenh = _phongBenh.tenPhong,
                            trangThai = _benhAn.trangThai.tinhTrang,
                            thoiGian = startdate + " - " + enddate
                        }).ToList();
            return list;
        }
        public dynamic xuatBaoCaoCaTuVong(string startdate, string enddate)
        {
            DateTime sDate = Convert.ToDateTime(startdate);
            DateTime eDate = Convert.ToDateTime(enddate);
            //lấy các bệnh án có trạng thái là tử vong trong khoảng thời gian đã chọn
            var list = (from _benhAn in benhAn
                        join _benhNhan in benhNhan on _benhAn.benhNhanID equals _benhNhan.ID
                        join _phongBenh in phongBenh on _benhAn.phongBenhID equals _phongBenh.ID
                        where _benhAn.trangThai.ID == 3
                        select new
                        {
                            tenBenhNhan = _benhNhan.ten,
                            ngaySinh = _benhNhan.ngaySinh,
                            CMND = _benhNhan.CMND,
                            soDienThoai = _benhNhan.sdtBenhNhan,
                            ngayNhiemBenh = _benhAn.ngayNhapVien,
                            phongBenh = _phongBenh.tenPhong,
                            trangThai = _benhAn.trangThai.tinhTrang,
                            thoiGian = startdate + " - " + enddate
                        }).ToList();
            return list;
        }
        public dynamic xuatBaoCaoCaKhoiBenh(string startdate, string enddate)
        {
            DateTime sDate = Convert.ToDateTime(startdate);
            DateTime eDate = Convert.ToDateTime(enddate);
            //lấy các bệnh án có ngày ra viện nằm trong khoảng thời gian đã chọn
            var list = (from _benhAn in benhAn
                        join _benhNhan in benhNhan on _benhAn.benhNhanID equals _benhNhan.ID
                        join _phongBenh in phongBenh on _benhAn.phongBenhID equals _phongBenh.ID
                        where DateTime.Compare((DateTime)_benhAn.ngayXuatVien, sDate) >= 0
                        && DateTime.Compare((DateTime)_benhAn.ngayXuatVien, eDate) <= 0
                        && _benhAn.trangThai.ID == 2
                        select new
                        {
                            tenBenhNhan = _benhNhan.ten,
                            ngaySinh = _benhNhan.ngaySinh,
                            CMND = _benhNhan.CMND,
                            soDienThoai = _benhNhan.sdtBenhNhan,
                            ngayNhiemBenh = _benhAn.ngayNhapVien,
                            phongBenh = _phongBenh.tenPhong,
                            trangThai = _benhAn.trangThai.tinhTrang,
                            thoiGian = startdate + " - " + enddate
                        }).ToList();
            return list;
        }

    }
}