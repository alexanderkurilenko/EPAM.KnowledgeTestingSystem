namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tests", "UserId", "dbo.Users");
            DropIndex("dbo.Tests", new[] { "UserId" });
            RenameColumn(table: "dbo.Questions", name: "TestId", newName: "Test_Id");
            RenameColumn(table: "dbo.Answers", name: "QuestionId", newName: "Question_Id");
            RenameIndex(table: "dbo.Questions", name: "IX_TestId", newName: "IX_Test_Id");
            RenameIndex(table: "dbo.Answers", name: "IX_QuestionId", newName: "IX_Question_Id");
            AddColumn("dbo.Tests", "Profile_Id", c => c.Int());
            CreateIndex("dbo.Tests", "Profile_Id");
            AddForeignKey("dbo.Tests", "Profile_Id", "dbo.Profiles", "Id");
            DropColumn("dbo.Tests", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tests", "UserId", c => c.Int());
            DropForeignKey("dbo.Tests", "Profile_Id", "dbo.Profiles");
            DropIndex("dbo.Tests", new[] { "Profile_Id" });
            DropColumn("dbo.Tests", "Profile_Id");
            RenameIndex(table: "dbo.Answers", name: "IX_Question_Id", newName: "IX_QuestionId");
            RenameIndex(table: "dbo.Questions", name: "IX_Test_Id", newName: "IX_TestId");
            RenameColumn(table: "dbo.Answers", name: "Question_Id", newName: "QuestionId");
            RenameColumn(table: "dbo.Questions", name: "Test_Id", newName: "TestId");
            CreateIndex("dbo.Tests", "UserId");
            AddForeignKey("dbo.Tests", "UserId", "dbo.Users", "Id");
        }
    }
}
