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
        private readonly IRoleRepository repo;

        public RoleService(IUnitOfWork uow,IRoleRepository rep)
        {
            this.uow = uow;
            this.repo = rep;
        }
        public RoleEntity GetRoleEntity(int id)
        {
            return repo.Get(id).ToBll();
        }

        public IEnumerable<RoleEntity> GetAllRoleEntities()
        {
            return repo.GetAll().Select(r => r.ToBll());
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
            return repo.GetRoleByName(id).ToBll();
        }
    }
}
