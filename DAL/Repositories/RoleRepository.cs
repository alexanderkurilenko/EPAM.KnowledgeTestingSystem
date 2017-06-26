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
    public class RoleRepository : IRoleRepository
    {
        private readonly DbContext _context;

        public RoleRepository(DbContext context)
        {
            _context = context;
        }

        public DalRole GetRoleByName(string id)
        {
            var ormUser = _context.Set<Role>().FirstOrDefault(test => test.Name == id);
            if (ormUser != null)
                return ormUser.ToDal();
            return null;
        }

        public IEnumerable<DalRole> GetAll()
        {
            var roles = _context.Set<Role>().ToList();
            return roles.Select(u => u.ToDal());
        }

        public DalRole Get(int id)
        {
            return _context.Set<Role>().FirstOrDefault(r => r.Id == id).ToDal();

        }

        public void Create(DalRole item)
        {
            throw new NotImplementedException();
        }

        public void Update(DalRole item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

       

        IEnumerable<DalRole> IRepository<DalRole>.GetAll()
        {
            throw new NotImplementedException();
        }


        public IEnumerable<DalRole> Find(Func<DalRole, bool> predicate)
        {
            throw new NotImplementedException();
        }


      

        public void Delete(DalRole item)
        {
            throw new NotImplementedException();
        }
    }
}
