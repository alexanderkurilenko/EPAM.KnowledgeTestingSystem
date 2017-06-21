namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tests", "TestResultId", c => c.Int());
            CreateIndex("dbo.Tests", "TestResultId");
            AddForeignKey("dbo.Tests", "TestResultId", "dbo.TestResults", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tests", "TestResultId", "dbo.TestResults");
            DropIndex("dbo.Tests", new[] { "TestResultId" });
            DropColumn("dbo.Tests", "TestResultId");
        }
    }
}
