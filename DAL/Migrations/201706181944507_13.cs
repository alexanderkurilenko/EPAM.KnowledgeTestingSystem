namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tests", "Profile_Id", "dbo.Profiles");
            DropForeignKey("dbo.TestResults", "Id", "dbo.Tests");
            DropIndex("dbo.Tests", new[] { "Profile_Id" });
            DropIndex("dbo.TestResults", new[] { "Id" });
            DropPrimaryKey("dbo.TestResults");
            CreateTable(
                "dbo.TestProfiles",
                c => new
                    {
                        Test_Id = c.Int(nullable: false),
                        Profile_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Test_Id, t.Profile_Id })
                .ForeignKey("dbo.Tests", t => t.Test_Id, cascadeDelete: true)
                .ForeignKey("dbo.Profiles", t => t.Profile_Id, cascadeDelete: true)
                .Index(t => t.Test_Id)
                .Index(t => t.Profile_Id);
            
            AddColumn("dbo.TestResults", "Test_Id", c => c.Int());
            AlterColumn("dbo.TestResults", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.TestResults", "Id");
            CreateIndex("dbo.TestResults", "Test_Id");
            AddForeignKey("dbo.TestResults", "Test_Id", "dbo.Tests", "Id");
            DropColumn("dbo.Tests", "Profile_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tests", "Profile_Id", c => c.Int());
            DropForeignKey("dbo.TestResults", "Test_Id", "dbo.Tests");
            DropForeignKey("dbo.TestProfiles", "Profile_Id", "dbo.Profiles");
            DropForeignKey("dbo.TestProfiles", "Test_Id", "dbo.Tests");
            DropIndex("dbo.TestProfiles", new[] { "Profile_Id" });
            DropIndex("dbo.TestProfiles", new[] { "Test_Id" });
            DropIndex("dbo.TestResults", new[] { "Test_Id" });
            DropPrimaryKey("dbo.TestResults");
            AlterColumn("dbo.TestResults", "Id", c => c.Int(nullable: false));
            DropColumn("dbo.TestResults", "Test_Id");
            DropTable("dbo.TestProfiles");
            AddPrimaryKey("dbo.TestResults", "Id");
            CreateIndex("dbo.TestResults", "Id");
            CreateIndex("dbo.Tests", "Profile_Id");
            AddForeignKey("dbo.TestResults", "Id", "dbo.Tests", "Id");
            AddForeignKey("dbo.Tests", "Profile_Id", "dbo.Profiles", "Id");
        }
    }
}
