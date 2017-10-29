namespace VegetableWebSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revomeTwoTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "RoleId");
            DropTable("dbo.Roles");
            DropTable("dbo.UserRoles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UserId = c.Long(nullable: false),
                        RoleId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "RoleId", c => c.Long(nullable: false));
        }
    }
}
