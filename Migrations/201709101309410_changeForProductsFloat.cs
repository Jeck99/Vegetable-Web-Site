namespace VegetableWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeForProductsFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "marketPrice", c => c.Single(nullable: false));
            AlterColumn("dbo.Products", "customerPrice", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "customerPrice", c => c.Long(nullable: false));
            AlterColumn("dbo.Products", "marketPrice", c => c.Long(nullable: false));
        }
    }
}
