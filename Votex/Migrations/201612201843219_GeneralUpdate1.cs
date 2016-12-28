namespace Votex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GeneralUpdate1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.PoliticalParties");
            AddColumn("dbo.PoliticalParties", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PoliticalParties", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.PoliticalParties", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.PoliticalParties", "UpdatedBy", c => c.String(maxLength: 256));
            AlterColumn("dbo.PoliticalParties", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.PoliticalParties", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.PoliticalParties");
            AlterColumn("dbo.PoliticalParties", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.PoliticalParties", "UpdatedBy");
            DropColumn("dbo.PoliticalParties", "UpdatedDate");
            DropColumn("dbo.PoliticalParties", "CreatedBy");
            DropColumn("dbo.PoliticalParties", "CreatedDate");
            AddPrimaryKey("dbo.PoliticalParties", "Id");
        }
    }
}
