namespace Votex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCandidates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        MiddleName = c.String(maxLength: 80),
                        LastName = c.String(nullable: false, maxLength: 100),
                        VoteCount = c.Int(nullable: false),
                        PoliticalPartyId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PoliticalParties", t => t.PoliticalPartyId, cascadeDelete: true)
                .Index(t => t.PoliticalPartyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidates", "PoliticalPartyId", "dbo.PoliticalParties");
            DropIndex("dbo.Candidates", new[] { "PoliticalPartyId" });
            DropTable("dbo.Candidates");
        }
    }
}
