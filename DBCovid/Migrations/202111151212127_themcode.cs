namespace DBCovid.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class themcode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Xa", "code", c => c.Int(nullable: false));
            AddColumn("dbo.tbl_Huyen", "code", c => c.Int(nullable: false));
            AddColumn("dbo.tbl_Tinhs", "code", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Tinhs", "code");
            DropColumn("dbo.tbl_Huyen", "code");
            DropColumn("dbo.tbl_Xa", "code");
        }
    }
}
