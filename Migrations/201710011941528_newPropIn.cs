namespace VegetableWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newPropIn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "RoleId", c => c.Long(nullable: false));
            DropColumn("dbo.Users", "RolesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "RolesId", c => c.Long(nullable: false));
            DropColumn("dbo.Users", "RoleId");
        }
    }
}
