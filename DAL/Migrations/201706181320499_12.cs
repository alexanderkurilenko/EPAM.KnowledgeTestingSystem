namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "Description", c => c.String());
            AlterColumn("dbo.Roles", "Type", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Roles", "Type", c => c.Int(nullable: false));
            DropColumn("dbo.Roles", "Description");
        }
    }
}
