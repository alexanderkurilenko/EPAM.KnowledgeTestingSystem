using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ORM;
using DAL.DTO;

namespace DAL.Interfaces
{
    public interface IUserRepository:IRepository<DalUser>
    {
        DalUser GetByEmail(string email);

        DalUser GetByLogin(string login);

        void UpdatePassword(User user);
    }
}
