namespace Votex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPoliticalParties : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PoliticalParties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PoliticalParties");
        }
    }
}
