namespace Votex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVoters : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Voters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BirthDate = c.DateTime(nullable: false),
                        RegistrationId = c.String(maxLength: 10),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Voters", "UserId", "dbo.User");
            DropIndex("dbo.Voters", new[] { "UserId" });
            DropTable("dbo.Voters");
        }
    }
}
