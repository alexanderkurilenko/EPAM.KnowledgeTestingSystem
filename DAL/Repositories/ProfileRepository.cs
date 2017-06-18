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
    public class ProfileRepository : IProfileRepository
    {
        private DbContext db;

        public ProfileRepository(DbContext context)
        {
            db = context;
        }

        public void ChangeName(Profile profile)
        {

            var selectedUser = db.Set<Profile>().FirstOrDefault(tmp => tmp.Id == profile.Id);
            if (selectedUser != null)
            {
                selectedUser.FirstName = profile.FirstName;
            }
        }

        public void ChangeSurName(Profile profile)
        {
            var selectedUser = db.Set<Profile>().FirstOrDefault(tmp => tmp.Id == profile.Id);
            if (selectedUser != null)
            {
                selectedUser.SurName = profile.SurName;
            }
        }

        public void Create(Profile item)
        {
            db.Set<Profile>().Add(item);
        }

        public void Delete(Profile item)
        {
            db.Set<Profile>().Remove(item);
        }

        public void Delete(int id)
        {
            Profile profile = db.Set<Profile>().Find(id);
            if (profile != null)
            {
                db.Set<Profile>().Remove(profile);
            }
        }

        public IEnumerable<Profile> Find(Func<Profile, bool> predicate)
        {
            return db.Set<Profile>().Where(predicate).ToList();
        }

        public Profile Get(int id)
        {
            return db.Set<Profile>().Find(id);
        }

        public IEnumerable<Profile> GetAll()
        {
            return db.Set<Profile>().ToList();
        }

        public void Update(Profile item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
