using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Interfaces;
using BLL.Mapper;

namespace BLL.Services.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _uow;

        public RoleService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public RoleDTO GetRole(int id)
        {
            return _uow.Roles.Get(id).ToRoleDto();
        }

        public IEnumerable<RoleDTO> GetAllRoles()
        {
            return _uow.Roles.GetAll().Select(role => role.ToRoleDto());
        }

        public void CreateRole(RoleDTO role)
        {
            _uow.Roles.Create(role.ToRoleEntity());
        }

        public void DeleteRole(RoleDTO role)
        {
            _uow.Roles.Delete(role.ToRoleEntity());
        }

        public void UpdateRole(RoleDTO role)
        {
            _uow.Roles.Update(role.ToRoleEntity());
        }

        public RoleDTO GetRoleByName(string name)
        {
            return _uow.Roles.GetRoleByName(name).ToRoleDto();
        }
    }
}
