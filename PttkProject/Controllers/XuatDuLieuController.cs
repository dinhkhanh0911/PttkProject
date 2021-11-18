using DBCovid.Data;
using DBCovid.models;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using PttkProject.DatabaseDAO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using System.Linq;

namespace PttkProject.Controllers
{
    public class XuatDuLieuController : Controller
    {
        XuatDuLieuDAO xuatDuLieu = new XuatDuLieuDAO();
        BenhAnDAO benhAn = new BenhAnDAO();
        BenhNhanDAO benhNhan = new BenhNhanDAO();
        DiaChiDAO diaChi = new DiaChiDAO();
        NhanVienYTeDAO nvyte = new NhanVienYTeDAO();
        // GET: XuatDuLieu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult baocaocanhiem()
        {
            return View();
        }

        public ActionResult baocaocatuvong()
        {
            return View();
        }

        public ActionResult baocaocakhoibenh()
        {
            return View();
        }

        public ActionResult xuatThongTinBenhAn(int id)
        {
            try
            {
                List<BenhAn> ba = xuatDuLieu.xuatBenhAn(id);
                var file = xuatBenhAn(ba);
                return File(file, "doc/docx", "test.docx");
            }
            catch(Exception e) { 
                return RedirectToAction("timkiembenhnhan", "BenhNhan");
            }
        }
        public ActionResult xuatTTTruyVet(int id)
        {
            try
            {
                BenhNhan bn = benhNhan.layBenhNhan_BA(id);
                List<ThongTinTruyVet> tv = xuatDuLieu.xuatTTTruyVet(id);
                foreach(var s in tv)
                {
                    s.xa = diaChi.layXa(s.xaID);
                    s.xa.huyen = diaChi.layHuyen(s.xa.huyenID);
                    s.xa.huyen.tinh = diaChi.layTinh(s.xa.huyen.tinhID);
                }
                var file = xuatTTTruyVet(tv, bn);
                return File(file, "xls/xlsx", "Báo cáo.xlsx");
            }
            catch(Exception e) { 
                return RedirectToAction("timkiembenhnhan", "BenhNhan");
            }
        }
        public ActionResult xuatTTTDieuTri(int id)
        {
            try
            {
                BenhNhan bn = benhNhan.layBenhNhan_BA(id);
                List<ThongTinDieuTri> dt = xuatDuLieu.xuatTTDieuTri(id);
                foreach(var s in dt)
                {
                    s.nhanVienYTe = nvyte.layNhanVienYTe(s.nhanVienYTeID);
                }
                var file = xuatTTDieuTri(dt, bn);
                return File(file, "xls/xlsx", "Báo cáo.xlsx");
            }
            catch(Exception e) { 
                return RedirectToAction("timkiembenhnhan", "BenhNhan");
            }
        }
        [HttpPost]
        public ActionResult xuatBaoCao(string startdate, string enddate, int loaiBC)
        {
            try
            {
                byte[] file = new byte[1025*1024];
                if(loaiBC==1)file = xuatBaoCaoCaNhiem(xuatDuLieu.xuatBaoCaoCaNhiem(startdate, enddate));
                if (loaiBC == 2) file = xuatBaoCaoCaTuVong(xuatDuLieu.xuatBaoCaoCaTuVong(startdate, enddate));
                else file = xuatBaoCaoCaKhoiBenh(xuatDuLieu.xuatBaoCaoCaKhoiBenh(startdate,enddate));
                return File(file, "xlsx/xls", "Báo cáo.xlsx");
            }
            catch (Exception e)
            {
                return RedirectToAction("XuatDuLieu", "index");
            }
        }

        private byte[] xuatBenhAn(List<BenhAn> list)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPackage = new ExcelPackage(new FileInfo("C:\\Users\\toank\\toan2k.xlsx")))
            {
                // Tạo author cho file Excel
                // Tạo title cho file Excel
                excelPackage.Workbook.Properties.Title = "Bệnh Án";
                int count_ws = 0;
                foreach (var item in list)
                {
                    excelPackage.Workbook.Worksheets.Add((count_ws + 1)+"Bệnh án ngày"+item.ngayNhapVien);
                    ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets[count_ws];

                    workSheet.Cells["A1:J1"].Merge = true;
                    workSheet.Cells["A1:J1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    workSheet.Cells["A1:J1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    workSheet.Cells["A1"].Value = "BỆNH ÁN BỆNH VIỆN CHỮA TRỊ COVID-19";

                    workSheet.Cells["A3:B3"].Merge = true;
                    workSheet.Cells["A3"].Value = "Tên bệnh nhân";
                    workSheet.Cells["C3:E3"].Merge = true;
                    workSheet.Cells["C3"].Value = item.benhNhan.ten;

                    workSheet.Cells["F3:G3"].Merge = true;
                    workSheet.Cells["F3"].Value = "Ngày sinh";
                    workSheet.Cells["H3:J3"].Merge = true;
                    DateTime time = (DateTime)item.benhNhan.ngaySinh;
                    workSheet.Cells["H3"].Value = time.ToString("dd/MM/yyyy");
                    //
                    workSheet.Cells["A4:B4"].Merge = true;
                    workSheet.Cells["A4"].Value = "Ngày nhập viện";
                    workSheet.Cells["C4:E4"].Merge = true;
                    time = (DateTime)item.ngayNhapVien;
                    workSheet.Cells["C4"].Value = time.ToString("dd/MM/yyyy");

                    workSheet.Cells["F4:G4"].Merge = true;
                    workSheet.Cells["F4"].Value = "Ngày sinh";
                    workSheet.Cells["H4:J4"].Merge = true;
                    time = (item.ngayXuatVien==null? (DateTime)item.ngayXuatVien:new DateTime());
                    workSheet.Cells["H4"].Value = time.ToString("dd/MM/yyyy");
                    //
                    workSheet.Cells["A5:B5"].Merge = true;
                    workSheet.Cells["A5"].Value = "Triệu chứng";
                    workSheet.Cells["C5:J12"].Merge = true;
                    workSheet.Cells["C5"].Value = item.trieuChung;

                    workSheet.Cells["A13:B13"].Merge = true;
                    workSheet.Cells["F3"].Value = "Chẩn đoán";
                    workSheet.Cells["C13:J20"].Merge = true;
                    workSheet.Cells["C13"].Value = item.chanDoan;
                    count_ws++;
                    workSheet.Cells.AutoFitColumns();
                }
                var file = excelPackage.GetAsByteArray();
                excelPackage.Dispose();
                return file;
            }

        }
        private byte[] xuatTTTruyVet(List<ThongTinTruyVet> tttv, BenhNhan bn)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPackage = new ExcelPackage(new FileInfo("C:\\Users\\toank\\toan2k.xlsx")))
            {
                // Tạo author cho file Excel
                // Tạo title cho file Excel
                excelPackage.Workbook.Properties.Title = "Bệnh Án";
                excelPackage.Workbook.Worksheets.Add("Thông tin truy vết" + bn.ten);
                ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets[0];

                workSheet.Cells["A1:J1"].Merge = true;
                workSheet.Cells["A1:J1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                workSheet.Cells["A1:J1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells["A1"].Value = "THÔNG TIN TRUY VẾT COVID-19";

                workSheet.Cells["A3:B3"].Merge = true;
                workSheet.Cells["A3"].Value = "Tên bệnh nhân";
                workSheet.Cells["C3:E3"].Merge = true;
                workSheet.Cells["C3"].Value = bn.ten;


                workSheet.Cells["F3:G3"].Merge = true;
                workSheet.Cells["F3"].Value = "Ngày nhập viện";
                workSheet.Cells["H3:J3"].Merge = true;
                DateTime time = (DateTime)bn.ngaySinh;
                workSheet.Cells["H3"].Value = time.ToString("dd/MM/yyyy");
                //
                workSheet.Cells["A5" + ":B5"].Merge = true;
                workSheet.Cells["A5"].Value = "Thời gian";
                workSheet.Cells["C5:J5"].Merge = true;
                workSheet.Cells["C5"].Value = "Địa chỉ";
                for (int i=0;i<tttv.Count;i++)
                {
                    int j = i + 6;
                    workSheet.Cells["A"+j+":B"+j].Merge = true;
                    time = (DateTime)tttv[i].thoiGian;
                    workSheet.Cells["A"+j].Value = time.ToString("dd/MM/yyyy");
                    workSheet.Cells["C"+j+":J"+j].Merge = true;
                    workSheet.Cells["C"+j].Value = tttv[i].xa.tenXa+" "+tttv[i].xa.huyen.tenHuyen+" "+tttv[i].xa.huyen.tinh.tenTinh;
                }

                

                workSheet.Cells.AutoFitColumns();
                var file = excelPackage.GetAsByteArray();
                excelPackage.Dispose();
                return file;
            }

        }
        private byte[] xuatTTDieuTri(List<ThongTinDieuTri> ttdt, BenhNhan bn)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPackage = new ExcelPackage(new FileInfo("C:\\Users\\toank\\toan2k.xlsx")))
            {
                // Tạo author cho file Excel
                // Tạo title cho file Excel
                excelPackage.Workbook.Properties.Title = "Bệnh Án";
                excelPackage.Workbook.Worksheets.Add("Thông tin truy vết" + bn.ten);
                ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets[0];

                workSheet.Cells["A1:J1"].Merge = true;
                workSheet.Cells["A1:J1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                workSheet.Cells["A1:J1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells["A1"].Value = "THÔNG TIN ĐIỀU TRỊ COVID-19";

                workSheet.Cells["A3:B3"].Merge = true;
                workSheet.Cells["A3"].Value = "Tên bệnh nhân";
                workSheet.Cells["C3:E3"].Merge = true;
                workSheet.Cells["C3"].Value = bn.ten;


                workSheet.Cells["F3:G3"].Merge = true;
                workSheet.Cells["F3"].Value = "Ngày nhập viện";
                workSheet.Cells["H3:J3"].Merge = true;
                DateTime time = (DateTime)bn.ngaySinh;
                workSheet.Cells["H3"].Value = time.ToString("dd/MM/yyyy");
                //
                workSheet.Cells["A5" + ":B5"].Merge = true;
                workSheet.Cells["A5"].Value = "Ngày";
                workSheet.Cells["C5:D5"].Merge = true;
                workSheet.Cells["C5"].Value = "Thời gian";
                workSheet.Cells["E5:G5"].Merge = true;
                workSheet.Cells["E5"].Value = "Tình trạng bệnh";
                workSheet.Cells["H5:K5"].Merge = true;
                workSheet.Cells["H5"].Value = "Y lệnh";
                workSheet.Cells["L5:M5"].Merge = true;
                workSheet.Cells["L5"].Value = "Bác sỹ";

                for (int i=0;i<ttdt.Count;i++)
                {
                    int j = i + 6;
                    workSheet.Cells["A"+j+":B"+j].Merge = true;
                    time = (DateTime)ttdt[i].ngay;
                    workSheet.Cells["A"+j].Value = time.ToString("dd/MM/yyyy");
                    workSheet.Cells["C"+j+":D"+j].Merge = true;
                    workSheet.Cells["C"+j].Value = ttdt[i].gioPhut;
                    workSheet.Cells["E"+j+":G"+j].Merge = true;
                    workSheet.Cells["E"+j].Value = ttdt[i].tinhTrangBenh;
                    workSheet.Cells["H"+j+":K"+j].Merge = true;
                    workSheet.Cells["H"+j].Value = ttdt[i].yLenh;
                    workSheet.Cells["L"+j+":M"+j].Merge = true;
                    workSheet.Cells["L"+j].Value = ttdt[i].nhanVienYTe.ten;

                }

                

                workSheet.Cells.AutoFitColumns();
                var file = excelPackage.GetAsByteArray();
                excelPackage.Dispose();
                return file;
            }

        }
        private byte[] xuatBaoCaoCaNhiem(dynamic cn)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPackage = new ExcelPackage(new FileInfo("C:\\Users\\toank\\toan2k.xlsx")))
            {
                // Tạo author cho file Excel
                // Tạo title cho file Excel
                excelPackage.Workbook.Properties.Title = "Bệnh Án";
                excelPackage.Workbook.Worksheets.Add("Báo cáo ca nhiễm");
                ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets[0];

                DateTime time;
                workSheet.Cells["A1:J1"].Merge = true;
                workSheet.Cells["A1:J1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                workSheet.Cells["A1:J1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells["A1"].Value = "BÁO CÁO CÁC CA NHIỄM COVID-19";
                workSheet.Cells["A2:C2"].Merge = true;
                workSheet.Cells["A2"].Value = cn[0].thoiGian;

                workSheet.Cells["A3"].Value = "Tên bệnh nhân";
                workSheet.Cells["B3"].Value = "Ngày sinh";
                workSheet.Cells["C3"].Value = "CMND";
                workSheet.Cells["D3"].Value = "Số điện thoại";
                workSheet.Cells["E3"].Value = "Ngày nhiễm bệnh";
                workSheet.Cells["F3"].Value = "Phòng bệnh";
                workSheet.Cells["G3"].Value = "Trạng thái";

                for (int i=0;i<cn.Count;i++)
                {
                    int j = i + 4;
                    workSheet.Cells["A" + j].Value = cn[i].tenBenhNhan;
                    if (cn[i].ngaySinh == null) time = DateTime.Today;
                    else time = (DateTime)cn[i].ngaySinh;
                    workSheet.Cells["B"+j].Value = time.ToString("dd/MM/yyyy");
                    workSheet.Cells["C"+j].Value = cn[i].CMND;
                    workSheet.Cells["D"+j].Value = cn[i].soDienThoai;
                    if (cn[i].ngayNhiemBenh == null) time = DateTime.Today;
                    else time = (DateTime)cn[i].ngayNhiemBenh;
                    workSheet.Cells["E"+j].Value = time.ToString("dd/MM/yyyy");
                    workSheet.Cells["F"+j].Value = cn[i].phongBenh;
                    workSheet.Cells["G"+j].Value = cn[i].trangThai;

                }
                workSheet.Cells.AutoFitColumns();
                var file = excelPackage.GetAsByteArray();
                excelPackage.Dispose();
                return file;
            }

        }
        private byte[] xuatBaoCaoCaTuVong(dynamic cn)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPackage = new ExcelPackage(new FileInfo("C:\\Users\\toank\\toan2k.xlsx")))
            {
                // Tạo author cho file Excel
                // Tạo title cho file Excel
                excelPackage.Workbook.Properties.Title = "Bệnh Án";
                excelPackage.Workbook.Worksheets.Add("Báo cáo ca nhiễm");
                ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets[0];

                DateTime time;
                workSheet.Cells["A1:J1"].Merge = true;
                workSheet.Cells["A1:J1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                workSheet.Cells["A1:J1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells["A1"].Value = "BÁO CÁO CÁC CA NHIỄM COVID-19";
                workSheet.Cells["A2:C2"].Merge = true;
                workSheet.Cells["A2"].Value = cn[0].thoiGian;

                workSheet.Cells["A3"].Value = "Tên bệnh nhân";
                workSheet.Cells["B3"].Value = "Ngày sinh";
                workSheet.Cells["C3"].Value = "CMND";
                workSheet.Cells["D3"].Value = "Số điện thoại";
                workSheet.Cells["E3"].Value = "Ngày nhiễm bệnh";
                workSheet.Cells["F3"].Value = "Phòng bệnh";
                workSheet.Cells["G3"].Value = "Trạng thái";

                for (int i=0;i<cn.Count;i++)
                {
                    int j = i + 4;
                    workSheet.Cells["A" + j].Value = cn[i].tenBenhNhan;
                    if (cn[i].ngaySinh == null) time = DateTime.Today;
                    else time = (DateTime)cn[i].ngaySinh;
                    workSheet.Cells["B"+j].Value = time.ToString("dd/MM/yyyy");
                    workSheet.Cells["C"+j].Value = cn[i].CMND;
                    workSheet.Cells["D"+j].Value = cn[i].soDienThoai;
                    if (cn[i].ngayNhiemBenh == null) time = DateTime.Today;
                    else time = (DateTime)cn[i].ngayNhiemBenh;
                    workSheet.Cells["E"+j].Value = time.ToString("dd/MM/yyyy");
                    workSheet.Cells["F"+j].Value = cn[i].phongBenh;
                    workSheet.Cells["G"+j].Value = cn[i].trangThai;

                }
                workSheet.Cells.AutoFitColumns();
                var file = excelPackage.GetAsByteArray();
                excelPackage.Dispose();
                return file;
            }

        }
        private byte[] xuatBaoCaoCaKhoiBenh(dynamic cn)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var excelPackage = new ExcelPackage(new FileInfo("C:\\Users\\toank\\toan2k.xlsx")))
            {
                // Tạo author cho file Excel
                // Tạo title cho file Excel
                excelPackage.Workbook.Properties.Title = "Bệnh Án";
                excelPackage.Workbook.Worksheets.Add("Báo cáo ca nhiễm");
                ExcelWorksheet workSheet = excelPackage.Workbook.Worksheets[0];

                DateTime time;
                workSheet.Cells["A1:J1"].Merge = true;
                workSheet.Cells["A1:J1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                workSheet.Cells["A1:J1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Cells["A1"].Value = "BÁO CÁO CÁC CA NHIỄM COVID-19";
                workSheet.Cells["A2:C2"].Merge = true;
                workSheet.Cells["A2"].Value = cn[0].thoiGian;

                workSheet.Cells["A3"].Value = "Tên bệnh nhân";
                workSheet.Cells["B3"].Value = "Ngày sinh";
                workSheet.Cells["C3"].Value = "CMND";
                workSheet.Cells["D3"].Value = "Số điện thoại";
                workSheet.Cells["E3"].Value = "Ngày nhiễm bệnh";
                workSheet.Cells["F3"].Value = "Phòng bệnh";
                workSheet.Cells["G3"].Value = "Trạng thái";

                for (int i=0;i<cn.Count;i++)
                {
                    int j = i + 4;
                    workSheet.Cells["A" + j].Value = cn[i].tenBenhNhan;
                    if (cn[i].ngaySinh == null) time = DateTime.Today;
                    else time = (DateTime)cn[i].ngaySinh;
                    workSheet.Cells["B"+j].Value = time.ToString("dd/MM/yyyy");
                    workSheet.Cells["C"+j].Value = cn[i].CMND;
                    workSheet.Cells["D"+j].Value = cn[i].soDienThoai;
                    if (cn[i].ngayNhiemBenh == null) time = DateTime.Today;
                    else time = (DateTime)cn[i].ngayNhiemBenh;
                    workSheet.Cells["E"+j].Value = time.ToString("dd/MM/yyyy");
                    workSheet.Cells["F"+j].Value = cn[i].phongBenh;
                    workSheet.Cells["G"+j].Value = cn[i].trangThai;

                }
                workSheet.Cells.AutoFitColumns();
                var file = excelPackage.GetAsByteArray();
                excelPackage.Dispose();
                return file;
            }

        }

    }
}