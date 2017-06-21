using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.ORM;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private DbContext db;

        public AnswerRepository(DbContext context)
        {
            db = context;
        }

        public void Create(Answer item)
        {
            db.Set<Answer>().Add(item);
        }

        public void Delete(Answer item)
        {
            db.Set<Answer>().Remove(item);
        }

        public void Delete(int id)
        {
            Answer answer = db.Set<Answer>().Find(id);
            if (answer != null)
            {
                db.Set<Answer>().Remove(answer);
            }
        }

        public IEnumerable<Answer> Find(Func<Answer, bool> predicate)
        {
            return db.Set<Answer>().Where(predicate).ToList();
        }

        public Answer Get(int id)
        {
            return db.Set<Answer>().Find(id);
        }

        public IEnumerable<Answer> GetAll()
        {
            return db.Set<Answer>().ToList();
        }

        public void Update(Answer item)
        {
            var entity = db.Set<Answer>().Find(item.Id);
            entity.Value =item.Value;
            db.Entry(entity).State = EntityState.Modified;
        }
    }
}
