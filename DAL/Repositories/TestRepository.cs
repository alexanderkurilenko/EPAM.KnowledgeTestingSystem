using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ORM;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class TestRepository : ITestRepository
    {
        private DbContext db;

        public TestRepository(DbContext context)
        {
            db = context;
        }

        public void Create(Test item)
        {
            db.Set<Test>().Add(item);
        }

        public void Delete(Test item)
        {
            db.Set<Test>().Remove(item);
        }

        public void Delete(int id)
        {
            Test test = db.Set<Test>().Find(id);
            if (test != null)
            {
                db.Set<Test>().Remove(test);
            }
        }

        public IEnumerable<Test> Find(Func<Test, bool> predicate)
        {
            return db.Set<Test>().Where(predicate).ToList();
        }

        public Test Get(int id)
        {
            return db.Set<Test>().Find(id);
        }

        public IEnumerable<Test> GetAll()
        {
            return db.Set<Test>().ToList();
        }

        public void Update(Test test)
        {
            var entity = db.Set<Test>().Find(test.Id);
            entity.Name = test.Name;
            entity.Questions = test.Questions;
            entity.Answers = test.Answers;
            entity.GoodAnswers = test.GoodAnswers;
            entity.BadAnswers = test.BadAnswers;
            entity.Time = test.Time;
            entity.TestResultId = test.TestResultId;
            entity.IsValid = test.IsValid;
           db.Entry(entity).State = EntityState.Modified;
        }
    }
}
