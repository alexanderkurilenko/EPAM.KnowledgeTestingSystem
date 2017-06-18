using DAL.ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class TestResultRepository:IResultRepository
    {
        private DbContext db;

        public TestResultRepository(DbContext context)
        {
            db = context;
        }

        public void Create(TestResult item)
        {
            db.Set<TestResult>().Add(item);
        }

        public void Delete(TestResult item)
        {
            db.Set<TestResult>().Remove(item);
        }

        public void Delete(int id)
        {
            TestResult testResult = db.Set<TestResult>().Find(id);
            if (testResult != null)
            {
                db.Set<TestResult>().Remove(testResult);
            }
        }

        public IEnumerable<TestResult> Find(Func<TestResult, bool> predicate)
        {
            return db.Set<TestResult>().Where(predicate).ToList();
        }

        public TestResult Get(int id)
        {
            return db.Set<TestResult>().Find(id);
        }

        public IEnumerable<TestResult> GetAll()
        {
            return db.Set<TestResult>().ToList();
        }

        public void Update(TestResult item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
