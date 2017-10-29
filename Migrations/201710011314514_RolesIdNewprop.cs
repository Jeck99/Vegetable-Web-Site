namespace VegetableWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RolesIdNewprop : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "RolesId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "RolesId", c => c.String());
        }
    }
}
