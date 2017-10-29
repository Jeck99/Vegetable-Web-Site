namespace VegetableWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeForProducts2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "productName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "productName", c => c.String());
        }
    }
}
