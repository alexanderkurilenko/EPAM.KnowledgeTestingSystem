using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using BLL.Mapper;
using BLL.Entities;

namespace BLL.Services.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork uow;

        public RoleService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public RoleEntity GetRoleEntity(int id)
        {
            return uow.Roles.Get(id).ToBll();
        }

        public IEnumerable<RoleEntity> GetAllRoleEntities()
        {
            return uow.Roles.GetAll().Select(r => r.ToBll());
        }

        public void CreateRole(RoleEntity role)
        {
            throw new NotImplementedException();
        }

        public void DeleteRole(RoleEntity role)
        {
            throw new NotImplementedException();
        }

        public RoleEntity GetRoleByName(string id)
        {
            return uow.Roles.GetRoleByName(id).ToBll();
        }
    }
}
