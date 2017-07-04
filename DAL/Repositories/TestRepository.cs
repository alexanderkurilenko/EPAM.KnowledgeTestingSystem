using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ORM;
using System.Data.Entity;
using DAL.DTO;
using DAL.Mapper;

namespace DAL.Repositories
{
    public class TestRepository : ITestRepository
    {
        private readonly DbContext _context;

        public TestRepository(DbContext context)
        {
            _context = context;
        }

        public DalTest Get(int id)
        {
            var ormtest = _context.Set<Test>().FirstOrDefault(test => test.Id == id);
            if (ormtest != null)
                return ormtest.ToDal();
            return null;
        }

        public void Create(DalTest item)
        {
            var test = item.ToEntity();
            _context.Set<Test>().Add(test);
        }

        public void Update(DalTest item)
        {

            var entity = item.ToEntity();
            _context.Set<Test>().Attach(entity);
            if (entity.Questions != null)
            {
                foreach (var question in entity.Questions)
                {
                    if (question != null)
                    {
                        _context.Set<Question>().Attach(question);
                        _context.Entry(question).State = EntityState.Modified;
                        foreach (var answer in question.Answers)
                        {
                            _context.Set<Answer>().Attach(answer);
                            _context.Entry(answer).State = EntityState.Modified;
                        }
                    }
                }
            }
            _context.Entry(entity).State = EntityState.Modified;
        }


        public void Delete(int id)
        {
            var item = _context.Set<Test>().Single(test => id == test.Id);
            _context.Set<Test>().Remove(item);
        }

        public IEnumerable<DalTest> GetAll()
        {

            return _context.Set<Test>().
                ToList().
                Select(t => t.ToDal());
        }

        public IEnumerable<DalTest> GetTestByName(string name)
        {
            return _context.Set<Test>().ToList().
                FindAll(test => test.Name == name).
                Select(t => t.ToDal());
        }

        public IEnumerable<DalTest> Find(Func<DalTest, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalTest item)
        {
            throw new NotImplementedException();
        }
    }
}
