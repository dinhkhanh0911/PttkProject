namespace DBCovid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class capnhatdb1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_BenhAns", "phongBenhID", "dbo.tbl_PhongBenhs");
            DropForeignKey("dbo.tbl_ThongTinDieuTris", "nhanVienYTeID", "dbo.Tbl_NhanVienYTes");
            DropIndex("dbo.tbl_BenhAns", new[] { "phongBenhID" });
            DropIndex("dbo.tbl_ThongTinDieuTris", new[] { "nhanVienYTeID" });
            AlterColumn("dbo.tbl_BenhAns", "phongBenhID", c => c.Int(nullable: false));
            AlterColumn("dbo.tbl_ThongTinDieuTris", "nhanVienYTeID", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_BenhAns", "phongBenhID");
            CreateIndex("dbo.tbl_ThongTinDieuTris", "nhanVienYTeID");
            AddForeignKey("dbo.tbl_BenhAns", "phongBenhID", "dbo.tbl_PhongBenhs", "ID", cascadeDelete: false);
            AddForeignKey("dbo.tbl_ThongTinDieuTris", "nhanVienYTeID", "dbo.Tbl_NhanVienYTes", "ID", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_ThongTinDieuTris", "nhanVienYTeID", "dbo.Tbl_NhanVienYTes");
            DropForeignKey("dbo.tbl_BenhAns", "phongBenhID", "dbo.tbl_PhongBenhs");
            DropIndex("dbo.tbl_ThongTinDieuTris", new[] { "nhanVienYTeID" });
            DropIndex("dbo.tbl_BenhAns", new[] { "phongBenhID" });
            AlterColumn("dbo.tbl_ThongTinDieuTris", "nhanVienYTeID", c => c.Int());
            AlterColumn("dbo.tbl_BenhAns", "phongBenhID", c => c.Int());
            CreateIndex("dbo.tbl_ThongTinDieuTris", "nhanVienYTeID");
            CreateIndex("dbo.tbl_BenhAns", "phongBenhID");
            AddForeignKey("dbo.tbl_ThongTinDieuTris", "nhanVienYTeID", "dbo.Tbl_NhanVienYTes", "ID");
            AddForeignKey("dbo.tbl_BenhAns", "phongBenhID", "dbo.tbl_PhongBenhs", "ID");
        }
    }
}
