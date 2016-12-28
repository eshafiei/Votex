namespace Votex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GeneralUpdate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Voters", "CreatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Voters", "CreatedBy", c => c.String(maxLength: 256));
            AddColumn("dbo.Voters", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Voters", "UpdatedBy", c => c.String(maxLength: 256));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Voters", "UpdatedBy");
            DropColumn("dbo.Voters", "UpdatedDate");
            DropColumn("dbo.Voters", "CreatedBy");
            DropColumn("dbo.Voters", "CreatedDate");
        }
    }
}
