
using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IUserService
    {
        UserEntity GetUserEntity(int id);
        UserEntity GetUserByLogin(string login);
        UserEntity GetUserByEmail(string email);
        IEnumerable<UserEntity> GetAllUserEntities();
        void CreateUser(UserEntity user);
        void DeleteUser(UserEntity user);
        void UpdateUser(UserEntity user);
    }
}
