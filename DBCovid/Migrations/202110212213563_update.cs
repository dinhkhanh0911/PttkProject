namespace DBCovid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tbl_nguoiDung",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        taiKhoan = c.String(),
                        matKhau = c.String(),
                        viTriLamViecID = c.Int(nullable: false),
                        ten = c.String(),
                        ngaySinh = c.DateTime(nullable: false),
                        CMND = c.String(nullable: false),
                        gioiTinh = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.tbl_nhanVienYTe",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        chuyenKhoa = c.String(),
                        bangCap = c.String(),
                        namKinhNghiem = c.Int(nullable: false),
                        moTa = c.String(),
                        ten = c.String(),
                        ngaySinh = c.DateTime(nullable: false),
                        CMND = c.String(nullable: false),
                        gioiTinh = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbl_nhanVienYTe");
            DropTable("dbo.tbl_nguoiDung");
        }
    }
}
