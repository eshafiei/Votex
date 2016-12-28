namespace Votex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIssues : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Issues", "BallotId", "dbo.Ballots");
            DropIndex("dbo.Issues", new[] { "BallotId" });
            AlterColumn("dbo.Issues", "YesCount", c => c.Int());
            AlterColumn("dbo.Issues", "VoteCount", c => c.Int());
            AlterColumn("dbo.Issues", "BallotId", c => c.Int());
            CreateIndex("dbo.Issues", "BallotId");
            AddForeignKey("dbo.Issues", "BallotId", "dbo.Ballots", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Issues", "BallotId", "dbo.Ballots");
            DropIndex("dbo.Issues", new[] { "BallotId" });
            AlterColumn("dbo.Issues", "BallotId", c => c.Int(nullable: false));
            AlterColumn("dbo.Issues", "VoteCount", c => c.Int(nullable: false));
            AlterColumn("dbo.Issues", "YesCount", c => c.Int(nullable: false));
            CreateIndex("dbo.Issues", "BallotId");
            AddForeignKey("dbo.Issues", "BallotId", "dbo.Ballots", "Id", cascadeDelete: true);
        }
    }
}
