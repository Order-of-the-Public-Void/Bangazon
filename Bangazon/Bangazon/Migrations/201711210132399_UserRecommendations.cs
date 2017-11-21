namespace Bangazon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserRecommendations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recommendations", "User_UserId", c => c.Int());
            CreateIndex("dbo.Recommendations", "User_UserId");
            AddForeignKey("dbo.Recommendations", "User_UserId", "dbo.Users", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recommendations", "User_UserId", "dbo.Users");
            DropIndex("dbo.Recommendations", new[] { "User_UserId" });
            DropColumn("dbo.Recommendations", "User_UserId");
        }
    }
}
