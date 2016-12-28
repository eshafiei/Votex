namespace Votex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GeneralUpdate5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BallotElections", "VoteCount", c => c.Int());
            AddColumn("dbo.BallotIssues", "VoteCount", c => c.Int());
            AddColumn("dbo.Issues", "NoCount", c => c.Int());
            DropColumn("dbo.Elections", "VoteCount");
            DropColumn("dbo.Issues", "VoteCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Issues", "VoteCount", c => c.Int());
            AddColumn("dbo.Elections", "VoteCount", c => c.Int());
            DropColumn("dbo.Issues", "NoCount");
            DropColumn("dbo.BallotIssues", "VoteCount");
            DropColumn("dbo.BallotElections", "VoteCount");
        }
    }
}
