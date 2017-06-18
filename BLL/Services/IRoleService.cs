using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IRoleService
    {
        RoleDTO GetRoleByName(string name);
        IEnumerable<RoleDTO> GetAllRoles();
        RoleDTO GetRole(int id);
        void CreateRole(RoleDTO role);
        void DeleteRole(RoleDTO role);
        void UpdateRole(RoleDTO role);
    }
}
