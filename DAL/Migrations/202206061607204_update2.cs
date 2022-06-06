namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MuonTraSach", "MaThuThu", "dbo.ThuThu");
            DropIndex("dbo.MuonTraSach", new[] { "MaThuThu" });
            DropColumn("dbo.MuonTraSach", "MaThuThu");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MuonTraSach", "MaThuThu", c => c.Long(nullable: false));
            CreateIndex("dbo.MuonTraSach", "MaThuThu");
            AddForeignKey("dbo.MuonTraSach", "MaThuThu", "dbo.ThuThu", "MaThuThu", cascadeDelete: true);
        }
    }
}
