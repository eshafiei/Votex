namespace Votex.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddTablesIssuesElectionsBallots : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ballots",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OpenDate = c.DateTime(nullable: false),
                        CloseDate = c.DateTime(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Elections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Office = c.String(maxLength: 255),
                        IsPartisan = c.Boolean(nullable: false),
                        VoteCount = c.Int(nullable: false),
                        BallotId = c.Int(nullable: false),
                        CandidateId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ballots", t => t.BallotId, cascadeDelete: true)
                .ForeignKey("dbo.Candidates", t => t.CandidateId, cascadeDelete: true)
                .Index(t => t.BallotId)
                .Index(t => t.CandidateId);
            
            CreateTable(
                "dbo.Issues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Question = c.String(nullable: false),
                        YesCount = c.Int(nullable: false),
                        VoteCount = c.Int(nullable: false),
                        BallotId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ballots", t => t.BallotId, cascadeDelete: true)
                .Index(t => t.BallotId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Issues", "BallotId", "dbo.Ballots");
            DropForeignKey("dbo.Elections", "CandidateId", "dbo.Candidates");
            DropForeignKey("dbo.Elections", "BallotId", "dbo.Ballots");
            DropIndex("dbo.Issues", new[] { "BallotId" });
            DropIndex("dbo.Elections", new[] { "CandidateId" });
            DropIndex("dbo.Elections", new[] { "BallotId" });
            DropTable("dbo.Issues");
            DropTable("dbo.Elections");
            DropTable("dbo.Ballots");
        }
    }
}
