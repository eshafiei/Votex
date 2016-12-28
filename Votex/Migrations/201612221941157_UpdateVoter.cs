namespace Votex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateVoter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Voters", "ElectoralDistrictId", c => c.Int(nullable: false));
            CreateIndex("dbo.Voters", "ElectoralDistrictId");
            AddForeignKey("dbo.Voters", "ElectoralDistrictId", "dbo.ElectoralDistricts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Voters", "ElectoralDistrictId", "dbo.ElectoralDistricts");
            DropIndex("dbo.Voters", new[] { "ElectoralDistrictId" });
            DropColumn("dbo.Voters", "ElectoralDistrictId");
        }
    }
}
