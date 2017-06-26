
using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IRoleService
    {
        RoleEntity GetRoleEntity(int id);
        IEnumerable<RoleEntity> GetAllRoleEntities();
        void CreateRole(RoleEntity role);
        void DeleteRole(RoleEntity role);
        RoleEntity GetRoleByName(string id);
    }
}
