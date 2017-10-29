namespace VegetableWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class onePropAddedInProductsAndOneOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "userEmail", c => c.String());
            AddColumn("dbo.Products", "productPic", c => c.String());
            AlterColumn("dbo.Products", "productName", c => c.String());
            DropColumn("dbo.Orders", "userId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "userId", c => c.Long(nullable: false));
            AlterColumn("dbo.Products", "productName", c => c.String(nullable: false));
            DropColumn("dbo.Products", "productPic");
            DropColumn("dbo.Orders", "userEmail");
        }
    }
}
