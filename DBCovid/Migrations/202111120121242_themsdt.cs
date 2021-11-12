namespace DBCovid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themsdt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tbl_NguoiDungs", "sdt", c => c.String());
            AddColumn("dbo.Tbl_NhanVienYTes", "sdt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tbl_NhanVienYTes", "sdt");
            DropColumn("dbo.Tbl_NguoiDungs", "sdt");
        }
    }
}
