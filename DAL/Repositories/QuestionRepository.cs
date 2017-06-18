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
    public class QuestionRepository : IQuestionRepository
    {
        private DbContext db;

        public QuestionRepository(DbContext context)
        {
            db = context;
        }

        public void Create(Question item)
        {
            db.Set<Question>().Add(item);
        }

        public void Delete(Question item)
        {
            db.Set<Question>().Remove(item);
        }

        public void Delete(int id)
        {
            Question question = db.Set<Question>().Find(id);
            if (question != null)
            {
                db.Set<Question>().Remove(question);
            }
        }

        public IEnumerable<Question> Find(Func<Question, bool> predicate)
        {
            return db.Set<Question>().Where(predicate).ToList();
        }

        public Question Get(int id)
        {
            return db.Set<Question>().Find(id);
        }

        public IEnumerable<Question> GetAll()
        {
            return db.Set<Question>().ToList();
        }

        public void Update(Question item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

    }
}
