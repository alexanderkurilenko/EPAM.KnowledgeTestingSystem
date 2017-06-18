namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.RoleUsers", new[] { "User_ID" });
            CreateIndex("dbo.RoleUsers", "User_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.RoleUsers", new[] { "User_Id" });
            CreateIndex("dbo.RoleUsers", "User_ID");
        }
    }
}
