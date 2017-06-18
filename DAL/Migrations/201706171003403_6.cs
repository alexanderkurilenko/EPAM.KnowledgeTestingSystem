namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestResults",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(),
                        DateComplete = c.DateTime(nullable: false),
                        CorrectAnswers = c.Int(nullable: false),
                        IncorrectAnswers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.Id)
                .Index(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestResults", "Id", "dbo.Tests");
            DropIndex("dbo.TestResults", new[] { "Id" });
            DropTable("dbo.TestResults");
        }
    }
}
