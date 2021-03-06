using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PttkProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            /* Trang chủ */
            routes.MapRoute(
                name: "TrangChu",
                url: "trang-chu/index",
                defaults: new { controller = "TrangChu", action = "Index" }
            );
            routes.MapRoute(
                name: "CheckCoockie",
                url: "trang-chu/lay-coockie",
                defaults: new { controller = "TrangChu", action = "layCoockie" }
            );
            routes.MapRoute(
                name: "LayDuLieuBieuDoTron",
                url: "trang-chu/lay-du-lieu-bieu-do-tron",
                defaults: new { controller = "TrangChu", action = "layDuLieuBieuDoTron" }
            );
            routes.MapRoute(
                name: "QuanLyBenhNhan",
                url: "benh-nhan/index",
                defaults: new { controller = "BenhNhan", action = "Index" }
            );
            routes.MapRoute(
                name: "ThemBenhNhan",
                url: "benh-nhan/them-benh-nhan",
                defaults: new { controller = "BenhNhan", action = "thembenhnhan" }
            );
            routes.MapRoute(
                name: "TimKiemBenhNhan",
                url: "benh-nhan/tim-kiem-benh-nhan",
                defaults: new { controller = "BenhNhan", action = "timkiembenhnhan" }
            );
            routes.MapRoute(
                name: "LayDSBenhNhan",
                url: "benh-nhan/lay-danh-sach-benh-nhan",
                defaults: new { controller = "BenhNhan", action = "layDSBenhNhan" }
            );
            routes.MapRoute(
                name: "SuaThongTinBenhNhan",
                url: "benh-nhan/cap-nhat-thong-tin-benh-nhan/{ID}",
                defaults: new { controller = "BenhNhan", action = "capnhatTTbenhnhan" }
            );
            routes.MapRoute(
                name: "XoaBenhNhan",
                url: "benh-nhan/xoa-benh-nhan",
                defaults: new { controller = "BenhNhan", action = "xoaBenhNhan" }
            );
            routes.MapRoute(
                name: "ThemBenhAn",
                url: "benh-nhan/them-benh-an/{id}",
                defaults: new { controller = "BenhNhan", action = "thembenhan" }
            );
            routes.MapRoute(
                name: "ThemBenhAnPost",
                url: "benh-nhan/them-benh-an",
                defaults: new { controller = "BenhNhan", action = "thembenhan" }
            );
            routes.MapRoute(
                name: "CapNhatBenhAn",
                url: "benh-nhan/cap-nhat-benh-an/{id}",
                defaults: new { controller = "BenhNhan", action = "capnhatbenhan", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "LayDanhSachThongtin",
                url: "benh-nhan/lay-danh-sach-thong-tin",
                defaults: new { controller = "BenhNhan", action = "layDSThongTin" }
            );
            routes.MapRoute(
                name: "LayDanhSachPhongBenhTheoLoaiPhong",
                url: "benh-nhan/lay-danh-sach-phong-benh",
                defaults: new { controller = "BenhNhan", action = "layDSPhongBenh" }
            );
            routes.MapRoute(
                name: "ThemThongTinTruyVet",
                url: "benh-nhan/them-thong-tin-truy-vet/{id}",
                defaults: new { controller = "BenhNhan", action = "ThemThongTinTruyVet", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ThemThongTinTruyVetPost",
                url: "benh-nhan/them-thong-tin-truy-vet",
                defaults: new { controller = "BenhNhan", action = "ThemThongTinTruyVet" }
            );
            routes.MapRoute(
                name: "XoaThongTinTruyVet",
                url: "benh-nhan/xoa-thong-tin-truy-vet",
                defaults: new { controller = "BenhNhan", action = "xoaThongTinTruyVet" }
            );
            routes.MapRoute(
                name: "ThemThongTinDieuTri",
                url: "benh-nhan/them-thong-tin-dieu-tri/{id}",
                defaults: new { controller = "BenhNhan", action = "themThongTinDieuTri" }
            );
            routes.MapRoute(
                name: "ThemThongTinDieuTriPost",
                url: "benh-nhan/them-thong-tin-dieu-tri",
                defaults: new { controller = "BenhNhan", action = "themThongTinDieuTri" }
            );
            routes.MapRoute(
                name: "XoaThongTinDieuTri",
                url: "benh-nhan/xoa-thong-tin-dieu-tri",
                defaults: new { controller = "BenhNhan", action = "xoaThongTinDieuTri" }
            );
            /*Phòng bệnh*/
            routes.MapRoute(
                name: "QuanLyPhongBenh",
                url: "phong-benh/index",
                defaults: new { controller = "PhongBenh", action = "Index" }
            );
            routes.MapRoute(
                name: "ThemPhongBenh",
                url: "phong-benh/them-phong-benh",
                defaults: new { controller = "PhongBenh", action = "themphong" }
            );
            routes.MapRoute(
                name: "xoaPhong",
                url: "phong-benh/xoa-phong-benh/{id}",
                defaults: new { controller = "PhongBenh", action = "xoaPhong", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "TimKiemPhongBenh",
                url: "phong-benh/tim-kiem-phong-benh",
                defaults: new { controller = "PhongBenh", action = "timkiemphong" }
            );
            routes.MapRoute(
                name: "CapNhatPhongBenh",
                url: "phong-benh/cap-nhat-phong-benh/{id}",
                defaults: new { controller = "PhongBenh", action = "suaphong", id = UrlParameter.Optional }
            );
            /*Nhân viên y tế*/
            routes.MapRoute(
                name: "QuanLyNhanVienYTe",
                url: "nhan-vien-y-te/index",
                defaults: new { controller = "NhanVienYTe", action = "Index" }
            );
            routes.MapRoute(
                name: "xoaNvYte",
                url: "nhan-vien-y-te/xoa-nhan-vien-y-te/{id}",
                defaults: new { controller = "NhanVienYTe", action = "xoaNvYte", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ThemNhanVienYTe",
                url: "nhan-vien-y-te/them-nhan-vien-y-te",
                defaults: new { controller = "NhanVienYTe", action = "themnhanvienyte" }
            );
            routes.MapRoute(
                name: "TimKiemNhanVienYTe",
                url: "nhan-vien-y-te/tim-kiem-nhan-vien-y-te",
                defaults: new { controller = "NhanVienYTe", action = "timkiemnhanvienyte" }
            );
            routes.MapRoute(
               name: "CapNhatTTNhanVienYTe",
               url: "nhan-vien-y-te/cap-nhat-thong-tin-nhan-vien-y-te/{id}",
               defaults: new { controller = "NhanVienYTe", action = "capnhatttnhanvienyte", id = UrlParameter.Optional }
           );
            /*Người dùng*/
            routes.MapRoute(
                name: "QuanLyNguoiDung",
                url: "nguoi-dung/index",
                defaults: new { controller = "NguoiDung", action = "Index" }
            );
            routes.MapRoute(
                name: "xoaNguoiDung",
                url: "nguoi-dung/xoa-nguoi-dung/{id}",
                defaults: new { controller = "NguoiDung", action = "xoaNguoiDung", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "ThemNguoiDung",
                url: "nguoi-dung/them-nguoi-dung",
                defaults: new { controller = "NguoiDung", action = "themnguoidung" }
            );
            routes.MapRoute(
                name: "CapNhatTTNguoiDung",
                url: "nguoi-dung/cap-nhat-tt-nguoi-dung/{id}",
                defaults: new { controller = "NguoiDung", action = "suanguoidung", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "TimKiemNguoiDung",
                url: "nguoi-dung/tim-kiem-nguoi-dung",
                defaults: new { controller = "NguoiDung", action = "timkiemnguoidung" }
            );
            /*Xuất dữ liệu*/
            routes.MapRoute(
                name: "XuatDuLieuTrangChinh",
                url: "xuat-du-lieu/index",
                defaults: new { controller = "XuatDuLieu", action = "Index" }
            );
            routes.MapRoute(
                name: "XuatDuLieu",
                url: "xuat-du-lieu/xuat-bao-cao",
                defaults: new { controller = "XuatDuLieu", action = "xuatBaoCao" }
            );
            /*Thống kê*/
            routes.MapRoute(
                name: "ThongKe",
                url: "thong-ke/index",
                defaults: new { controller = "ThongKe", action = "Index" }
            );
            routes.MapRoute(
                name: "ThongKeCaNhiem",
                url: "thong-ke/thong-ke-ca-nhiem",
                defaults: new { controller = "ThongKe", action = "thongkecanhiem" }
            );
            routes.MapRoute(
                name: "ThongKeCaKhoiBenh",
                url: "thong-ke/thong-ke-ca-khoi-benh",
                defaults: new { controller = "ThongKe", action = "thongkecakhoibenh" }
            );
            routes.MapRoute(
                name: "ThongKeCaTuVong",
                url: "thong-ke/thong-ke-ca-tu-vong",
                defaults: new { controller = "ThongKe", action = "thongkecatuvong" }
            );
            routes.MapRoute(
                name: "ThongKeCaDuongTinhTroLai",
                url: "thong-ke/thong-ke-ca-duong-tinh-tro-lai",
                defaults: new { controller = "ThongKe", action = "thongkecaduongtinhtrolai" }
            );
            /* Đăng nhập */
            routes.MapRoute(
                name: "DangNhap",
                url: "dang-nhap/dang-nhap",
                defaults: new { controller = "DangNhap", action = "dangnhap" }
            );

            routes.MapRoute(
                name: "DangXuat",
                url: "dang-nhap/dang-xuat",
                defaults: new { controller = "DangNhap", action = "dangxuat" }
            );
            /* Admin */
            routes.MapRoute(
                name: "Trang chủ admin",
                url: "admin/index",
                defaults: new { controller = "Admin", action = "Index" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TrangChu", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
