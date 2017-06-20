using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.ORM;
using System.Data.Entity;
using Ninject;
using DAL.Configurations;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DbContext db;

        public UserRepository(DbContext context)
        {
            db = context;
        }

        public void Create(User item)
        {
            if (item == null)
            {
                throw new NullReferenceException();
            }
            db.Set<User>().Add(item);
        }

        public void Delete(User item)
        {
            db.Set<User>().Remove(item);
        }

        public void Delete(int id)
        {
            User user = db.Set<User>().Find(id);
            if (user != null)
            {
                db.Set<User>().Remove(user);
            }
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
           return  db.Set<User>().Where(predicate).ToList();
        }

        public User Get(int id)
        {
            return db.Set<User>().Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Set<User>().ToList();
        }

        public User GetByEmail(string email)
        {
            return db.Set<User>().FirstOrDefault(user => user.Email == email);
        }

        public User GetByLogin(string login)
        {
           return  db.Set<User>().FirstOrDefault(user => user.Name == login);
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public void UpdatePassword(User user)
        {
           var selectedUser= db.Set<User>().FirstOrDefault(tmp => tmp.Id == user.Id);
            if (selectedUser != null)
            {
                selectedUser.Password = user.Password;
            }
        }
    }
}
