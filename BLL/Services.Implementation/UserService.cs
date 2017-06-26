
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

        public UserService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public UserEntity GetUserEntity(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();
            return uow.Users.Get(id).ToBll();
        }


        public void DeleteUser(UserEntity user)
        {
            if (user == null)
                throw new ArgumentNullException();
            uow.Users.Delete(user.Id);
            uow.Save();
        }
        public IEnumerable<UserEntity> GetAllUserEntities()
        {
            return uow.Users.GetAll().Select(user => user.ToBll());
        }
        public void CreateUser(UserEntity user)
        {
            uow.Users.Create(user.ToDal());
            uow.Save();
        }

        public UserEntity GetUserByLogin(string login)
        {
            return uow.Users.GetByLogin(login).ToBll();
        }

        public UserEntity GetUserByEmail(string email)
        {
            return uow.Users.GetByEmail(email).ToBll();
        }

        public void UpdateUser(UserEntity user)
        {
            var entityUser = uow.Users.Get(user.Id);
            if (user.Password != null)
                user.Password = Crypto.Hash(user.Password);
            else
                user.Password = entityUser.Password;
            uow.Users.Update(user.ToDal());
            uow.Save();
        }
    }
}
