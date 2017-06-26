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
    public class QuestionRepository : IQuestionRepository
    {
        public void Create(DalQuestion item)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalQuestion item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalQuestion> Find(Func<DalQuestion, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public DalQuestion Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DalQuestion> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(DalQuestion item)
        {
            throw new NotImplementedException();
        }
    }
}
