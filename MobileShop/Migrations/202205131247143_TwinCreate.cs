namespace MobileShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TwinCreate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CategoryId" });
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id");
            CreateIndex("dbo.Products", "Category_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            RenameColumn(table: "dbo.Products", name: "Category_Id", newName: "CategoryId");
            CreateIndex("dbo.Products", "CategoryId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
