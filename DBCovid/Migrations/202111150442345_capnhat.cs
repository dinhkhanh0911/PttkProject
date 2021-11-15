namespace DBCovid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class capnhat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tbl_NguoiDungs", "taiKhoan", c => c.String());
            AlterColumn("dbo.Tbl_NguoiDungs", "matKhau", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tbl_NguoiDungs", "matKhau", c => c.String(nullable: false));
            AlterColumn("dbo.Tbl_NguoiDungs", "taiKhoan", c => c.String(nullable: false));
        }
    }
}
