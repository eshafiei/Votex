namespace Votex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddElectoralDistrict : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ElectoralDistricts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(maxLength: 256),
                        UpdatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ElectoralDistricts");
        }
    }
}
