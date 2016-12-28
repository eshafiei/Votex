namespace Votex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBallotElections : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BallotElections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BallotId = c.Int(nullable: false),
                        ElectionId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ballots", t => t.BallotId, cascadeDelete: true)
                .ForeignKey("dbo.Elections", t => t.ElectionId, cascadeDelete: true)
                .Index(t => t.BallotId)
                .Index(t => t.ElectionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BallotElections", "ElectionId", "dbo.Elections");
            DropForeignKey("dbo.BallotElections", "BallotId", "dbo.Ballots");
            DropIndex("dbo.BallotElections", new[] { "ElectionId" });
            DropIndex("dbo.BallotElections", new[] { "BallotId" });
            DropTable("dbo.BallotElections");
        }
    }
}
