namespace Votex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GeneralUpdate4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Elections", "BallotId", "dbo.Ballots");
            DropForeignKey("dbo.Issues", "BallotId", "dbo.Ballots");
            DropIndex("dbo.Elections", new[] { "BallotId" });
            DropIndex("dbo.Issues", new[] { "BallotId" });
            DropColumn("dbo.Elections", "BallotId");
            DropColumn("dbo.Issues", "BallotId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Issues", "BallotId", c => c.Int());
            AddColumn("dbo.Elections", "BallotId", c => c.Int());
            CreateIndex("dbo.Issues", "BallotId");
            CreateIndex("dbo.Elections", "BallotId");
            AddForeignKey("dbo.Issues", "BallotId", "dbo.Ballots", "Id");
            AddForeignKey("dbo.Elections", "BallotId", "dbo.Ballots", "Id");
        }
    }
}
