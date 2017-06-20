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
    public class RoleRepository:IRoleRepository
    {
        private DbContext db;

        public RoleRepository(DbContext context)
        {
            db = context;
        }

        public void Create(Role item)
        {
            db.Set<Role>().Add(item);
        }

        public void Delete(Role item)
        {
            db.Set<Role>().Remove(item);
        }

        public void Delete(int id)
        {
            Role Role = db.Set<Role>().Find(id);
            if (Role != null)
            {
                db.Set<Role>().Remove(Role);
            }
        }

        public IEnumerable<Role> Find(Func<Role, bool> predicate)
        {
            return db.Set<Role>().Where(predicate).ToList();
        }

        public Role Get(int id)
        {
            return db.Set<Role>().Find(id);
        }

        public IEnumerable<Role> GetAll()
        {
            return db.Set<Role>().ToList();
        }

        public Role GetRoleByName(string name)
        {
            return db.Set<Role>().FirstOrDefault(role => role.Name.ToLower() == name.ToLower());
        }

        public void Update(Role item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
