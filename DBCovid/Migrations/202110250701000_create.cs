namespace DBCovid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_BenhAns",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ngayNhapVien = c.DateTime(storeType: "date"),
                        ngayXuatVien = c.DateTime(storeType: "date"),
                        chuanDoan = c.String(maxLength: 255),
                        trieuChung = c.String(maxLength: 255),
                        moTa = c.String(maxLength: 255),
                        benhNhanID = c.Int(nullable: false),
                        phongBenhID = c.Int(nullable: false),
                        trangThaiID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_BenhNhans", t => t.benhNhanID, cascadeDelete: true)
                .ForeignKey("dbo.tbl_PhongBenhs", t => t.phongBenhID, cascadeDelete: true)
                .ForeignKey("dbo.tbl_TrangThais", t => t.trangThaiID, cascadeDelete: true)
                .Index(t => t.benhNhanID)
                .Index(t => t.phongBenhID)
                .Index(t => t.trangThaiID);
            
            CreateTable(
                "dbo.tbl_BenhNhans",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        maBHYT = c.String(),
                        sdtBenhNhan = c.String(),
                        tenNguoiThan = c.String(),
                        sdtNguoiThan = c.String(),
                        doiTuongCachLy = c.String(nullable: false),
                        ten = c.String(nullable: false),
                        ngaySinh = c.DateTime(storeType: "date"),
                        CMND = c.String(nullable: false),
                        moTa = c.String(),
                        gioiTinh = c.String(nullable: false),
                        diaChiID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_DiaChis", t => t.diaChiID, cascadeDelete: true)
                .Index(t => t.diaChiID);
            
            CreateTable(
                "dbo.tbl_DiaChis",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        chiTiet = c.String(),
                        moTa = c.String(),
                        xaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_Xa", t => t.xaID, cascadeDelete: true)
                .Index(t => t.xaID);
            
            CreateTable(
                "dbo.tbl_Xa",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        tenXa = c.String(),
                        moTa = c.String(),
                        huyenID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_Huyen", t => t.huyenID, cascadeDelete: true)
                .Index(t => t.huyenID);
            
            CreateTable(
                "dbo.tbl_Huyen",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        tenHuyen = c.String(nullable: false),
                        moTa = c.String(),
                        tinhID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_Tinhs", t => t.tinhID, cascadeDelete: true)
                .Index(t => t.tinhID);
            
            CreateTable(
                "dbo.tbl_Tinhs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        tenTinh = c.String(nullable: false),
                        moTa = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_PhongBenhs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        tenPhong = c.String(nullable: false),
                        soGiuongToiDa = c.Int(nullable: false),
                        soGiuongHienTai = c.Int(nullable: false),
                        benhVienID = c.Int(nullable: false),
                        loaiPhongID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_BenhViens", t => t.benhVienID, cascadeDelete: true)
                .ForeignKey("dbo.tbl_LoaiPhongs", t => t.loaiPhongID)
                .Index(t => t.benhVienID)
                .Index(t => t.loaiPhongID);
            
            CreateTable(
                "dbo.tbl_BenhViens",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        tenBenhVien = c.String(nullable: false),
                        moTa = c.String(),
                        diaChiID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_DiaChis", t => t.diaChiID)
                .Index(t => t.diaChiID);
            
            CreateTable(
                "dbo.tbl_LoaiPhongs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        tenLoaiPhong = c.String(nullable: false),
                        moTa = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_TrangThais",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        tinhTrang = c.String(nullable: false),
                        moTa = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tbl_NguoiDungs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        taiKhoan = c.String(nullable: false),
                        matKhau = c.String(nullable: false),
                        viTriLamViecID = c.Int(nullable: false),
                        ten = c.String(nullable: false),
                        ngaySinh = c.DateTime(storeType: "date"),
                        CMND = c.String(nullable: false),
                        moTa = c.String(),
                        gioiTinh = c.String(nullable: false),
                        diaChiID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_DiaChis", t => t.diaChiID, cascadeDelete: true)
                .ForeignKey("dbo.tbl_ViTriLamViecs", t => t.viTriLamViecID, cascadeDelete: true)
                .Index(t => t.viTriLamViecID)
                .Index(t => t.diaChiID);
            
            CreateTable(
                "dbo.tbl_ViTriLamViecs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        tenViTri = c.String(nullable: false),
                        moTa = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tbl_NhanVienYTes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        chuyenKhoa = c.String(),
                        bangCap = c.String(),
                        namKinhNghiem = c.Int(nullable: false),
                        viTriLamViecID = c.Int(nullable: false),
                        ten = c.String(nullable: false),
                        ngaySinh = c.DateTime(storeType: "date"),
                        CMND = c.String(nullable: false),
                        moTa = c.String(),
                        gioiTinh = c.String(nullable: false),
                        diaChiID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_DiaChis", t => t.diaChiID, cascadeDelete: true)
                .ForeignKey("dbo.tbl_ViTriLamViecs", t => t.viTriLamViecID, cascadeDelete: true)
                .Index(t => t.viTriLamViecID)
                .Index(t => t.diaChiID);
            
            CreateTable(
                "dbo.tbl_ThongTinDieuTris",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        gioPhut = c.String(),
                        ngay = c.DateTime(nullable: false, storeType: "date"),
                        tinhTrangBenh = c.String(),
                        yLenh = c.String(),
                        moTa = c.String(),
                        benhAnID = c.Int(nullable: false),
                        nhanVienYTeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_BenhAns", t => t.benhAnID, cascadeDelete: true)
                .ForeignKey("dbo.Tbl_NhanVienYTes", t => t.nhanVienYTeID, cascadeDelete: false)
                .Index(t => t.benhAnID)
                .Index(t => t.nhanVienYTeID);
            
            CreateTable(
                "dbo.tbl_ThongTinTruyVets",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        thoiGian = c.DateTime(nullable: false, storeType: "date"),
                        moTa = c.String(),
                        benhAnID = c.Int(nullable: false),
                        diaChiID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tbl_BenhAns", t => t.benhAnID, cascadeDelete: true)
                .ForeignKey("dbo.tbl_DiaChis", t => t.diaChiID, cascadeDelete: false)
                .Index(t => t.benhAnID)
                .Index(t => t.diaChiID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_ThongTinTruyVets", "diaChiID", "dbo.tbl_DiaChis");
            DropForeignKey("dbo.tbl_ThongTinTruyVets", "benhAnID", "dbo.tbl_BenhAns");
            DropForeignKey("dbo.tbl_ThongTinDieuTris", "nhanVienYTeID", "dbo.Tbl_NhanVienYTes");
            DropForeignKey("dbo.tbl_ThongTinDieuTris", "benhAnID", "dbo.tbl_BenhAns");
            DropForeignKey("dbo.Tbl_NhanVienYTes", "viTriLamViecID", "dbo.tbl_ViTriLamViecs");
            DropForeignKey("dbo.Tbl_NhanVienYTes", "diaChiID", "dbo.tbl_DiaChis");
            DropForeignKey("dbo.Tbl_NguoiDungs", "viTriLamViecID", "dbo.tbl_ViTriLamViecs");
            DropForeignKey("dbo.Tbl_NguoiDungs", "diaChiID", "dbo.tbl_DiaChis");
            DropForeignKey("dbo.tbl_BenhAns", "trangThaiID", "dbo.tbl_TrangThais");
            DropForeignKey("dbo.tbl_BenhAns", "phongBenhID", "dbo.tbl_PhongBenhs");
            DropForeignKey("dbo.tbl_PhongBenhs", "loaiPhongID", "dbo.tbl_LoaiPhongs");
            DropForeignKey("dbo.tbl_PhongBenhs", "benhVienID", "dbo.tbl_BenhViens");
            DropForeignKey("dbo.tbl_BenhViens", "diaChiID", "dbo.tbl_DiaChis");
            DropForeignKey("dbo.tbl_BenhAns", "benhNhanID", "dbo.tbl_BenhNhans");
            DropForeignKey("dbo.tbl_BenhNhans", "diaChiID", "dbo.tbl_DiaChis");
            DropForeignKey("dbo.tbl_DiaChis", "xaID", "dbo.tbl_Xa");
            DropForeignKey("dbo.tbl_Xa", "huyenID", "dbo.tbl_Huyen");
            DropForeignKey("dbo.tbl_Huyen", "tinhID", "dbo.tbl_Tinhs");
            DropIndex("dbo.tbl_ThongTinTruyVets", new[] { "diaChiID" });
            DropIndex("dbo.tbl_ThongTinTruyVets", new[] { "benhAnID" });
            DropIndex("dbo.tbl_ThongTinDieuTris", new[] { "nhanVienYTeID" });
            DropIndex("dbo.tbl_ThongTinDieuTris", new[] { "benhAnID" });
            DropIndex("dbo.Tbl_NhanVienYTes", new[] { "diaChiID" });
            DropIndex("dbo.Tbl_NhanVienYTes", new[] { "viTriLamViecID" });
            DropIndex("dbo.Tbl_NguoiDungs", new[] { "diaChiID" });
            DropIndex("dbo.Tbl_NguoiDungs", new[] { "viTriLamViecID" });
            DropIndex("dbo.tbl_BenhViens", new[] { "diaChiID" });
            DropIndex("dbo.tbl_PhongBenhs", new[] { "loaiPhongID" });
            DropIndex("dbo.tbl_PhongBenhs", new[] { "benhVienID" });
            DropIndex("dbo.tbl_Huyen", new[] { "tinhID" });
            DropIndex("dbo.tbl_Xa", new[] { "huyenID" });
            DropIndex("dbo.tbl_DiaChis", new[] { "xaID" });
            DropIndex("dbo.tbl_BenhNhans", new[] { "diaChiID" });
            DropIndex("dbo.tbl_BenhAns", new[] { "trangThaiID" });
            DropIndex("dbo.tbl_BenhAns", new[] { "phongBenhID" });
            DropIndex("dbo.tbl_BenhAns", new[] { "benhNhanID" });
            DropTable("dbo.tbl_ThongTinTruyVets");
            DropTable("dbo.tbl_ThongTinDieuTris");
            DropTable("dbo.Tbl_NhanVienYTes");
            DropTable("dbo.tbl_ViTriLamViecs");
            DropTable("dbo.Tbl_NguoiDungs");
            DropTable("dbo.tbl_TrangThais");
            DropTable("dbo.tbl_LoaiPhongs");
            DropTable("dbo.tbl_BenhViens");
            DropTable("dbo.tbl_PhongBenhs");
            DropTable("dbo.tbl_Tinhs");
            DropTable("dbo.tbl_Huyen");
            DropTable("dbo.tbl_Xa");
            DropTable("dbo.tbl_DiaChis");
            DropTable("dbo.tbl_BenhNhans");
            DropTable("dbo.tbl_BenhAns");
        }
    }
}
