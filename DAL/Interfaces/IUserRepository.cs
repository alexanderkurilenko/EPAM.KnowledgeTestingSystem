using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ORM;

namespace DAL.Interfaces
{
    public interface IUserRepository:IRepository<User>
    {
        User GetByEmail(string email);

        User GetByLogin(string login);

        void UpdatePassword(User user);
    }
}
