namespace Votex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePoliticalPartyId : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PoliticalParties");
            AlterColumn("dbo.PoliticalParties", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.PoliticalParties", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PoliticalParties");
            AlterColumn("dbo.PoliticalParties", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.PoliticalParties", "Id");
        }
    }
}
