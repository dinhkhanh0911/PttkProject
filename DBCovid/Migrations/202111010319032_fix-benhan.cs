namespace DBCovid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixbenhan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_BenhAns", "chanDoan", c => c.String(maxLength: 255));
            DropColumn("dbo.tbl_BenhAns", "chuanDoan");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_BenhAns", "chuanDoan", c => c.String(maxLength: 255));
            DropColumn("dbo.tbl_BenhAns", "chanDoan");
        }
    }
}
