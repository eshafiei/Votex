namespace Votex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateElections : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Elections", "BallotId", "dbo.Ballots");
            DropForeignKey("dbo.Elections", "CandidateId", "dbo.Candidates");
            DropIndex("dbo.Elections", new[] { "BallotId" });
            DropIndex("dbo.Elections", new[] { "CandidateId" });
            AlterColumn("dbo.Elections", "VoteCount", c => c.Int());
            AlterColumn("dbo.Elections", "BallotId", c => c.Int());
            AlterColumn("dbo.Elections", "CandidateId", c => c.Int());
            CreateIndex("dbo.Elections", "BallotId");
            CreateIndex("dbo.Elections", "CandidateId");
            AddForeignKey("dbo.Elections", "BallotId", "dbo.Ballots", "Id");
            AddForeignKey("dbo.Elections", "CandidateId", "dbo.Candidates", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Elections", "CandidateId", "dbo.Candidates");
            DropForeignKey("dbo.Elections", "BallotId", "dbo.Ballots");
            DropIndex("dbo.Elections", new[] { "CandidateId" });
            DropIndex("dbo.Elections", new[] { "BallotId" });
            AlterColumn("dbo.Elections", "CandidateId", c => c.Int(nullable: false));
            AlterColumn("dbo.Elections", "BallotId", c => c.Int(nullable: false));
            AlterColumn("dbo.Elections", "VoteCount", c => c.Int(nullable: false));
            CreateIndex("dbo.Elections", "CandidateId");
            CreateIndex("dbo.Elections", "BallotId");
            AddForeignKey("dbo.Elections", "CandidateId", "dbo.Candidates", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Elections", "BallotId", "dbo.Ballots", "Id", cascadeDelete: true);
        }
    }
}
