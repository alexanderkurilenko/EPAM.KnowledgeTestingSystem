
using BLL.Entities;
using BLL.Mapper;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;

namespace BLL.Services.Implementation
{
    public class UserService:IUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IUserRepository repo;

        public UserService(IUnitOfWork uow, IUserRepository rep)
        {
            this.uow = uow;
            this.repo = rep;
        }

        public UserEntity GetUserEntity(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();
            return repo.Get(id).ToBll();
        }


        public void DeleteUser(UserEntity user)
        {
            if (user == null)
                throw new ArgumentNullException();
            repo.Delete(user.Id);
            uow.Save();
        }
        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            return repo.GetAll().Select(user => user.ToBll());
        }
        public void CreateUser(UserEntity user)
        {
            repo.Create(user.ToDal());
            uow.Save();
        }

        public UserEntity GetUserByLogin(string login)
        {
            return repo.GetByLogin(login).ToBll();
        }

        public UserEntity GetUserByEmail(string email)
        {
            return repo.GetByEmail(email).ToBll();
        }

        public void UpdateUser(UserEntity user)
        {
            var entityUser = repo.Get(user.Id);
            if (user.Password != null)
                user.Password = Crypto.Hash(user.Password);
            else
                user.Password = entityUser.Password;
            repo.Update(user.ToDal());
            uow.Save();
        }
    }
}
