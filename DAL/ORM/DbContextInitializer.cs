
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
            User user1 = new User { Id = 10, Email = "Alex080397@mail.ru", Login = "alexanderkurilenko" };
            Role role = new Role { Type = "Admin"};
            Role role1 = new Role { Type = "Guest" };
            role.Users.Add(user1);
            user1.Roles.Add(role);
            user1.Roles.Add(role1);
            Profile prf = new Profile { Id = user1.Id, FirstName = "Alexander", SurName = "Kurilenko" };

            Test test = new Test { Title = "Quadro", Topic = "Math", Time = new TimeSpan(0, 1, 5) };

            Question q = new Question() { Text = "Sqrt of 4", Type = "sqrt" };
            Question q1 = new Question() { Text = "Sqrt of 9", Type = "sqrt" };

            Answer a = new Answer() { Text = "2", IsCorrect = true };
            Answer a1 = new Answer() { Text = "3", IsCorrect = false };

            Answer b = new Answer() { Text = "20", IsCorrect = false };
            Answer b1 = new Answer() { Text = "3", IsCorrect = true };

            q.Answers.Add(a);
            q.Answers.Add(a1);

            q1.Answers.Add(b);
            q1.Answers.Add(b1);

            test.Questions.Add(q);
            test.Questions.Add(q1);

            prf.Tests.Add(test);
            //TestResult rslt = new TestResult() { Test = test, CorrectAnswers = 1, IncorrectAnswers = 2, Name = "Test", DateComplete = DateTime.Now };
           
            db.Tests.Add(test);
            db.Users.Add(user1);
            db.Profiles.Add(prf);
            //db.Results.Add(rslt);
            db.SaveChanges();

        }
    }
}
