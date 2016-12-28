namespace Votex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateBallots : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ballots", "ElectoralDistrictId", c => c.Int());
            CreateIndex("dbo.Ballots", "ElectoralDistrictId");
            AddForeignKey("dbo.Ballots", "ElectoralDistrictId", "dbo.ElectoralDistricts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ballots", "ElectoralDistrictId", "dbo.ElectoralDistricts");
            DropIndex("dbo.Ballots", new[] { "ElectoralDistrictId" });
            DropColumn("dbo.Ballots", "ElectoralDistrictId");
        }
    }
}
