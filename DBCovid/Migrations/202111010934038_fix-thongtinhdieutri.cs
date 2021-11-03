namespace DBCovid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixthongtinhdieutri : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tbl_ThongTinDieuTris", "tinhTrangBenh", c => c.String(nullable: false));
            AlterColumn("dbo.tbl_ThongTinDieuTris", "yLenh", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_ThongTinDieuTris", "yLenh", c => c.String());
            AlterColumn("dbo.tbl_ThongTinDieuTris", "tinhTrangBenh", c => c.String());
        }
    }
}
