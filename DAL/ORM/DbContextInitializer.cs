
using System;
using System.Collections.Generic;

using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM
{
    public class DbContextInitializer: DropCreateDatabaseIfModelChanges<KnowledgeSystemDbContext>
    {
        protected override void Seed(KnowledgeSystemDbContext db)
        {
            List<Question> q = new List<Question>();
            List<Answer> answer1 = new List<Answer>();
            List<Answer> answer2 = new List<Answer>();
            answer1.Add(new Answer()
            {
                QuestionId = 1,
                Description = "I am live in London.",
                IsCorrect = false,
            });
            answer1.Add(new Answer()
            {
                QuestionId = 1,
                Description = "I live in London.",
                IsCorrect = true,
            });
            answer2.Add(new Answer()
            {
                QuestionId = 2,
                Description = "No. My are American",
                IsCorrect = false,

            });
            answer2.Add(new Answer()
            {
                QuestionId = 2,
                IsCorrect = true,
                Description = "No. I am American."
            });
            q.Add(new Question()
            {
                TestId = 3,
                Description = "Where do you live?",
                Answers = answer1
            });
            q.Add(new Question()
            {
                TestId = 3,
                Description = "Are you German?",
                Answers = answer2
            });



            db.Roles.Add(new Role { Name = "Admin", Description = "This role have all feutures" });
            db.Roles.Add(new Role { Name = "Moderator", Description = "This role have much feutures" });
            db.Roles.Add(new Role { Name = "User", Description = "This role have little feutures" });
            db.Tests.Add(new Test { Name = "C#", Creator = "Jessica", Description = "Test your knowladge in C# beginner", MinProcentToPassTest = 10, Time = 20 });
            db.Tests.Add(new Test { Name = "History", Creator = "Jessica", Description = "Test your knowladge in world history", MinProcentToPassTest = 30, Time = 10 });
            db.Tests.Add(new Test { Name = "English Elementary", Creator = "Jessica", Description = "Test your knowladge in english elementary", Questions = q, MinProcentToPassTest = 20, Time = 20 });

            db.SaveChanges();

        }
    }
}
