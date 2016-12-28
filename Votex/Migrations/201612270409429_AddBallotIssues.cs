namespace Votex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBallotIssues : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BallotIssues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BallotId = c.Int(nullable: false),
                        IssueId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ballots", t => t.BallotId, cascadeDelete: true)
                .ForeignKey("dbo.Issues", t => t.IssueId, cascadeDelete: true)
                .Index(t => t.BallotId)
                .Index(t => t.IssueId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BallotIssues", "IssueId", "dbo.Issues");
            DropForeignKey("dbo.BallotIssues", "BallotId", "dbo.Ballots");
            DropIndex("dbo.BallotIssues", new[] { "IssueId" });
            DropIndex("dbo.BallotIssues", new[] { "BallotId" });
            DropTable("dbo.BallotIssues");
        }
    }
}
