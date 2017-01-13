namespace Votex.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GeneralUpdate6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BallotElections", "BallotId", "dbo.Ballots");
            DropForeignKey("dbo.BallotElections", "ElectionId", "dbo.Elections");
            DropForeignKey("dbo.Ballots", "ElectoralDistrictId", "dbo.ElectoralDistricts");
            DropForeignKey("dbo.Candidates", "PoliticalPartyId", "dbo.PoliticalParties");
            DropForeignKey("dbo.BallotIssues", "BallotId", "dbo.Ballots");
            DropForeignKey("dbo.BallotIssues", "IssueId", "dbo.Issues");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.Voters", "ElectoralDistrictId", "dbo.ElectoralDistricts");
            AddForeignKey("dbo.BallotElections", "BallotId", "dbo.Ballots", "Id");
            AddForeignKey("dbo.BallotElections", "ElectionId", "dbo.Elections", "Id");
            AddForeignKey("dbo.Ballots", "ElectoralDistrictId", "dbo.ElectoralDistricts", "Id");
            AddForeignKey("dbo.Candidates", "PoliticalPartyId", "dbo.PoliticalParties", "Id");
            AddForeignKey("dbo.BallotIssues", "BallotId", "dbo.Ballots", "Id");
            AddForeignKey("dbo.BallotIssues", "IssueId", "dbo.Issues", "Id");
            AddForeignKey("dbo.UserRole", "RoleId", "dbo.Role", "Id");
            AddForeignKey("dbo.UserClaim", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.UserLogin", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.UserRole", "UserId", "dbo.User", "Id");
            AddForeignKey("dbo.Voters", "ElectoralDistrictId", "dbo.ElectoralDistricts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Voters", "ElectoralDistrictId", "dbo.ElectoralDistricts");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropForeignKey("dbo.BallotIssues", "IssueId", "dbo.Issues");
            DropForeignKey("dbo.BallotIssues", "BallotId", "dbo.Ballots");
            DropForeignKey("dbo.Candidates", "PoliticalPartyId", "dbo.PoliticalParties");
            DropForeignKey("dbo.Ballots", "ElectoralDistrictId", "dbo.ElectoralDistricts");
            DropForeignKey("dbo.BallotElections", "ElectionId", "dbo.Elections");
            DropForeignKey("dbo.BallotElections", "BallotId", "dbo.Ballots");
            AddForeignKey("dbo.Voters", "ElectoralDistrictId", "dbo.ElectoralDistricts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRole", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserLogin", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserClaim", "UserId", "dbo.User", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserRole", "RoleId", "dbo.Role", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BallotIssues", "IssueId", "dbo.Issues", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BallotIssues", "BallotId", "dbo.Ballots", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Candidates", "PoliticalPartyId", "dbo.PoliticalParties", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Ballots", "ElectoralDistrictId", "dbo.ElectoralDistricts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BallotElections", "ElectionId", "dbo.Elections", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BallotElections", "BallotId", "dbo.Ballots", "Id", cascadeDelete: true);
        }
    }
}
