using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ORM;

namespace DAL.Interfaces
{
    public interface IRoleRepository:IRepository<Role>
    {
        Role GetRoleByName(string name);
    }
}
