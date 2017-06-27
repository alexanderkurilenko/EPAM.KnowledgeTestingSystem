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
using System.Data.Entity.Migrations;
using DAL.DTO;
using DAL.Mapper;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _context;

        public UserRepository(DbContext uow)
        {
            _context = uow;
        }


        public DalUser GetByEmail(string email)
        {
            var ormUser = _context.Set<User>().FirstOrDefault(test => test.Email == email);
            if (ormUser != null)
                return ormUser.ToDal();
            return null;
        }


        public DalUser GetByLogin(string login)
        {
            var ormUser = _context.Set<User>().FirstOrDefault(test => test.Login == login);
            if (ormUser != null)
                return ormUser.ToDal();
            return null;
        }

        public IEnumerable<DalUser> GetAll()
        {
            return _context.Set<User>().ToList().Select(u => u.ToDal());

        }

        public DalUser GetById(int id)
        {
            var ormUser = _context.Set<User>().FirstOrDefault(test => test.Id == id);
            if (ormUser != null)
                return ormUser.ToDal();
            return null;
        }

        public void Create(DalUser item)
        {
            var user = item.ToEntity();
            _context.Set<User>().Add(user);
        }

        public void Update(DalUser item)
        {
            var user = item.ToEntity();

            _context.Set<User>().AddOrUpdate(user);
        }

        public void Delete(int id)
        {
            var user = _context.Set<User>().Single(u => u.Id == id);
            _context.Set<User>().Remove(user);

        }

        public void UpdatePassword(User user)
        {
            throw new NotImplementedException();
        }

        public DalUser Get(int id)
        {
            var ormUser = _context.Set<User>().FirstOrDefault(test => test.Id == id);
            if (ormUser != null)
                return ormUser.ToDal();
            return null;
        }

        public IEnumerable<DalUser> Find(Func<DalUser, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public void Delete(DalUser item)
        {
            throw new NotImplementedException();
        }
    }
}
