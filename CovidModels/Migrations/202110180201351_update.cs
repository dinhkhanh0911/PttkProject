namespace CovidModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_benhAn",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ngayNhapVien = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ngayXuatVien = c.DateTime(precision: 7, storeType: "datetime2"),
                        chuanDoan = c.String(maxLength: 255),
                        trieuChung = c.String(maxLength: 255),
                        moTa = c.String(maxLength: 255),
                        benhNhanID = c.Int(nullable: false),
                        phongBenhID = c.Int(),
                        trangThaiID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_benhNhan", t => t.benhNhanID)
                .ForeignKey("dbo.tbl_phongBenh", t => t.phongBenhID)
                .ForeignKey("dbo.tbl_trangThai", t => t.trangThaiID, cascadeDelete: true)
                .Index(t => t.benhNhanID)
                .Index(t => t.phongBenhID)
                .Index(t => t.trangThaiID);
            
            CreateTable(
                "dbo.tbl_nguoi",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ten = c.String(),
                        ngaySinh = c.DateTime(nullable: false),
                        CMND = c.String(nullable: false),
                        gioiTinh = c.String(),
                        diaChiID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_diaChi", t => t.diaChiID, cascadeDelete: true)
                .Index(t => t.diaChiID);
            
            CreateTable(
                "dbo.tbl_diaChi",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        chiTiet = c.String(),
                        moTa = c.String(),
                        xaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_xa", t => t.xaID, cascadeDelete: true)
                .Index(t => t.xaID);
            
            CreateTable(
                "dbo.tbl_xa",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        tenXa = c.String(),
                        moTa = c.String(),
                        huyenID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_huyen", t => t.huyenID, cascadeDelete: true)
                .Index(t => t.huyenID);
            
            CreateTable(
                "dbo.tbl_huyen",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        tenHuyen = c.String(),
                        moTa = c.String(),
                        tinhID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_tinh", t => t.tinhID, cascadeDelete: true)
                .Index(t => t.tinhID);
            
            CreateTable(
                "dbo.tbl_tinh",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        tenTinh = c.String(),
                        moTa = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_phongBenh",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        tenPhong = c.String(),
                        soGiuongToiDa = c.Int(nullable: false),
                        soGiuongHienTai = c.Int(nullable: false),
                        benhVienID = c.Int(nullable: false),
                        loaiPhongID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_benhVien", t => t.benhVienID, cascadeDelete: true)
                .ForeignKey("dbo.tbl_loaiPhong", t => t.loaiPhongID, cascadeDelete: true)
                .Index(t => t.benhVienID)
                .Index(t => t.loaiPhongID);
            
            CreateTable(
                "dbo.tbl_benhVien",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        tenBenhVien = c.String(),
                        moTa = c.String(),
                        diaChiID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_diaChi", t => t.diaChiID, cascadeDelete: true)
                .Index(t => t.diaChiID);
            
            CreateTable(
                "dbo.tbl_loaiPhong",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        tenLoaiPhong = c.String(),
                        moTa = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_thongTinDieuTri",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        gioPhut = c.String(),
                        ngay = c.DateTime(nullable: false),
                        tinhTrangBenh = c.String(),
                        yLenh = c.String(),
                        moTa = c.String(),
                        benhAnID = c.Int(nullable: false),
                        nhanVienYTeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_benhAn", t => t.benhAnID, cascadeDelete: true)
                .ForeignKey("dbo.tbl_nhanVienYTe", t => t.nhanVienYTeID)
                .Index(t => t.benhAnID)
                .Index(t => t.nhanVienYTeID);
            
            CreateTable(
                "dbo.tbl_viTriLamViec",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        tenViTri = c.String(),
                        moTa = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_thongTinTruyVet",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        thoiGian = c.DateTime(nullable: false),
                        moTa = c.String(),
                        benhAnID = c.Int(nullable: false),
                        diaChiID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_benhAn", t => t.benhAnID, cascadeDelete: true)
                .ForeignKey("dbo.tbl_diaChi", t => t.diaChiID, cascadeDelete: true)
                .Index(t => t.benhAnID)
                .Index(t => t.diaChiID);
            
            CreateTable(
                "dbo.tbl_trangThai",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        tinhTrang = c.String(),
                        moTa = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_benhNhan",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        maBHYT = c.String(),
                        sdtBenhNhan = c.String(),
                        sdtNguoiThan = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_nguoi", t => t.ID)
                .Index(t => t.ID);
            
            CreateTable(
                "dbo.tbl_nguoiDung",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        taiKhoan = c.String(),
                        matKhau = c.String(),
                        viTriLamViecID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_nguoi", t => t.ID)
                .ForeignKey("dbo.tbl_viTriLamViec", t => t.viTriLamViecID, cascadeDelete: true)
                .Index(t => t.ID)
                .Index(t => t.viTriLamViecID);
            
            CreateTable(
                "dbo.tbl_nhanVienYTe",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        chuyenKhoa = c.String(),
                        bangCap = c.String(),
                        namKinhNghiem = c.Int(nullable: false),
                        moTa = c.String(),
                        viTriLamViecID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_nguoi", t => t.ID)
                .ForeignKey("dbo.tbl_viTriLamViec", t => t.viTriLamViecID, cascadeDelete: true)
                .Index(t => t.ID)
                .Index(t => t.viTriLamViecID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_nhanVienYTe", "viTriLamViecID", "dbo.tbl_viTriLamViec");
            DropForeignKey("dbo.tbl_nhanVienYTe", "ID", "dbo.tbl_nguoi");
            DropForeignKey("dbo.tbl_nguoiDung", "viTriLamViecID", "dbo.tbl_viTriLamViec");
            DropForeignKey("dbo.tbl_nguoiDung", "ID", "dbo.tbl_nguoi");
            DropForeignKey("dbo.tbl_benhNhan", "ID", "dbo.tbl_nguoi");
            DropForeignKey("dbo.tbl_nguoi", "diaChiID", "dbo.tbl_diaChi");
            DropForeignKey("dbo.tbl_benhAn", "trangThaiID", "dbo.tbl_trangThai");
            DropForeignKey("dbo.tbl_thongTinTruyVet", "diaChiID", "dbo.tbl_diaChi");
            DropForeignKey("dbo.tbl_thongTinTruyVet", "benhAnID", "dbo.tbl_benhAn");
            DropForeignKey("dbo.tbl_thongTinDieuTri", "nhanVienYTeID", "dbo.tbl_nhanVienYTe");
            DropForeignKey("dbo.tbl_thongTinDieuTri", "benhAnID", "dbo.tbl_benhAn");
            DropForeignKey("dbo.tbl_phongBenh", "loaiPhongID", "dbo.tbl_loaiPhong");
            DropForeignKey("dbo.tbl_phongBenh", "benhVienID", "dbo.tbl_benhVien");
            DropForeignKey("dbo.tbl_benhVien", "diaChiID", "dbo.tbl_diaChi");
            DropForeignKey("dbo.tbl_benhAn", "phongBenhID", "dbo.tbl_phongBenh");
            DropForeignKey("dbo.tbl_xa", "huyenID", "dbo.tbl_huyen");
            DropForeignKey("dbo.tbl_huyen", "tinhID", "dbo.tbl_tinh");
            DropForeignKey("dbo.tbl_diaChi", "xaID", "dbo.tbl_xa");
            DropForeignKey("dbo.tbl_benhAn", "benhNhanID", "dbo.tbl_benhNhan");
            DropIndex("dbo.tbl_nhanVienYTe", new[] { "viTriLamViecID" });
            DropIndex("dbo.tbl_nhanVienYTe", new[] { "ID" });
            DropIndex("dbo.tbl_nguoiDung", new[] { "viTriLamViecID" });
            DropIndex("dbo.tbl_nguoiDung", new[] { "ID" });
            DropIndex("dbo.tbl_benhNhan", new[] { "ID" });
            DropIndex("dbo.tbl_thongTinTruyVet", new[] { "diaChiID" });
            DropIndex("dbo.tbl_thongTinTruyVet", new[] { "benhAnID" });
            DropIndex("dbo.tbl_thongTinDieuTri", new[] { "nhanVienYTeID" });
            DropIndex("dbo.tbl_thongTinDieuTri", new[] { "benhAnID" });
            DropIndex("dbo.tbl_benhVien", new[] { "diaChiID" });
            DropIndex("dbo.tbl_phongBenh", new[] { "loaiPhongID" });
            DropIndex("dbo.tbl_phongBenh", new[] { "benhVienID" });
            DropIndex("dbo.tbl_huyen", new[] { "tinhID" });
            DropIndex("dbo.tbl_xa", new[] { "huyenID" });
            DropIndex("dbo.tbl_diaChi", new[] { "xaID" });
            DropIndex("dbo.tbl_nguoi", new[] { "diaChiID" });
            DropIndex("dbo.tbl_benhAn", new[] { "trangThaiID" });
            DropIndex("dbo.tbl_benhAn", new[] { "phongBenhID" });
            DropIndex("dbo.tbl_benhAn", new[] { "benhNhanID" });
            DropTable("dbo.tbl_nhanVienYTe");
            DropTable("dbo.tbl_nguoiDung");
            DropTable("dbo.tbl_benhNhan");
            DropTable("dbo.tbl_trangThai");
            DropTable("dbo.tbl_thongTinTruyVet");
            DropTable("dbo.tbl_viTriLamViec");
            DropTable("dbo.tbl_thongTinDieuTri");
            DropTable("dbo.tbl_loaiPhong");
            DropTable("dbo.tbl_benhVien");
            DropTable("dbo.tbl_phongBenh");
            DropTable("dbo.tbl_tinh");
            DropTable("dbo.tbl_huyen");
            DropTable("dbo.tbl_xa");
            DropTable("dbo.tbl_diaChi");
            DropTable("dbo.tbl_nguoi");
            DropTable("dbo.tbl_benhAn");
        }
    }
}
