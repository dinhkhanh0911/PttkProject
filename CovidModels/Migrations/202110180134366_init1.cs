namespace CovidModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.tbl_diaChi", "huyenID", "dbo.tbl_huyen");
            DropForeignKey("dbo.tbl_diaChi", "tinhID", "dbo.tbl_tinh");
            DropIndex("dbo.tbl_diaChi", new[] { "tinhID" });
            DropIndex("dbo.tbl_diaChi", new[] { "huyenID" });
            DropColumn("dbo.tbl_diaChi", "tinhID");
            DropColumn("dbo.tbl_diaChi", "huyenID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_diaChi", "huyenID", c => c.Int(nullable: false));
            AddColumn("dbo.tbl_diaChi", "tinhID", c => c.Int(nullable: false));
            CreateIndex("dbo.tbl_diaChi", "huyenID");
            CreateIndex("dbo.tbl_diaChi", "tinhID");
            AddForeignKey("dbo.tbl_diaChi", "tinhID", "dbo.tbl_tinh", "ID", cascadeDelete: true);
            AddForeignKey("dbo.tbl_diaChi", "huyenID", "dbo.tbl_huyen", "ID", cascadeDelete: true);
        }
    }
}
