using DAL.ORM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.DTO;
using DAL.Mapper;

namespace DAL.Repositories
{
    public class TestResultRepository:IResultRepository
    {
        private readonly DbContext _context;

        public TestResultRepository(DbContext context)
        {
            _context = context;
        }
        public void Create(DalResult item)
        {
            var result = item.ToEntity();
            _context.Set<TestResult>().Add(result);
        }

        public void Delete(int id)
        {
            var item = _context.Set<DalResult>().Single(test => id == test.Id);
            _context.Set<DalResult>().Remove(item);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalResult> GetAll()
        {
            return _context.Set<TestResult>().ToList().Select(r => r.ToDal());
        }

        public DalResult Get(int id)
        {
            return _context.Set<TestResult>().FirstOrDefault(r => r.Id == id).ToDal();
        }

        public void Update(DalResult item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalResult> Find(Func<DalResult, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalResult item)
        {
            throw new NotImplementedException();
        }
    }
}
