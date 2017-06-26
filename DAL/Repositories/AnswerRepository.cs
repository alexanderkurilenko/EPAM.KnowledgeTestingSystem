using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.ORM;
using System.Data.Entity;
using DAL.DTO;

namespace DAL.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        public void Create(DalAnswer item)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalAnswer item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalAnswer> Find(Func<DalAnswer, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public DalAnswer Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalAnswer> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(DalAnswer item)
        {
            throw new NotImplementedException();
        }
    }
}
