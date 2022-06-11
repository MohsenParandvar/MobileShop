namespace MobileShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Customer_UserId", "dbo.UserProfile");
            DropIndex("dbo.Orders", new[] { "Customer_UserId" });
            AddColumn("dbo.Orders", "UserProfileId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "UserProfile_UserId", c => c.Int());
            AddForeignKey("dbo.Orders", "UserProfile_UserId", "dbo.UserProfile", "UserId");
            CreateIndex("dbo.Orders", "UserProfile_UserId");
            DropColumn("dbo.Orders", "CustomerId");
            DropColumn("dbo.Orders", "Customer_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Customer_UserId", c => c.Int());
            AddColumn("dbo.Orders", "CustomerId", c => c.Int(nullable: false));
            DropIndex("dbo.Orders", new[] { "UserProfile_UserId" });
            DropForeignKey("dbo.Orders", "UserProfile_UserId", "dbo.UserProfile");
            DropColumn("dbo.Orders", "UserProfile_UserId");
            DropColumn("dbo.Orders", "UserProfileId");
            CreateIndex("dbo.Orders", "Customer_UserId");
            AddForeignKey("dbo.Orders", "Customer_UserId", "dbo.UserProfile", "UserId");
        }
    }
}
