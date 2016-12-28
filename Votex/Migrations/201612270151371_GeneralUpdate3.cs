namespace Votex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GeneralUpdate3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ballots", "ElectoralDistrictId", "dbo.ElectoralDistricts");
            DropIndex("dbo.Ballots", new[] { "ElectoralDistrictId" });
            AlterColumn("dbo.Ballots", "ElectoralDistrictId", c => c.Int(nullable: false));
            CreateIndex("dbo.Ballots", "ElectoralDistrictId");
            AddForeignKey("dbo.Ballots", "ElectoralDistrictId", "dbo.ElectoralDistricts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ballots", "ElectoralDistrictId", "dbo.ElectoralDistricts");
            DropIndex("dbo.Ballots", new[] { "ElectoralDistrictId" });
            AlterColumn("dbo.Ballots", "ElectoralDistrictId", c => c.Int());
            CreateIndex("dbo.Ballots", "ElectoralDistrictId");
            AddForeignKey("dbo.Ballots", "ElectoralDistrictId", "dbo.ElectoralDistricts", "Id");
        }
    }
}
