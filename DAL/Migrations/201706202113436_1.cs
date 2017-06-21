namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Test_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.Test_Id, cascadeDelete: true)
                .Index(t => t.Test_Id);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Time = c.Int(nullable: false),
                        Description = c.String(),
                        GoodAnswers = c.Int(nullable: false),
                        BadAnswers = c.Int(nullable: false),
                        IsValid = c.Boolean(nullable: false),
                        Creator = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.String(),
                        Test_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tests", t => t.Test_Id, cascadeDelete: true)
                .Index(t => t.Test_Id);
            
            CreateTable(
                "dbo.TestResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateComplete = c.DateTime(nullable: false),
                        GoodAnswers = c.Int(nullable: false),
                        BadAnswers = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestResults", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.Users");
            DropForeignKey("dbo.Questions", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.Answers", "Test_Id", "dbo.Tests");
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.TestResults", new[] { "User_Id" });
            DropIndex("dbo.Questions", new[] { "Test_Id" });
            DropIndex("dbo.Answers", new[] { "Test_Id" });
            DropTable("dbo.UserRole");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.TestResults");
            DropTable("dbo.Questions");
            DropTable("dbo.Tests");
            DropTable("dbo.Answers");
        }
    }
}
