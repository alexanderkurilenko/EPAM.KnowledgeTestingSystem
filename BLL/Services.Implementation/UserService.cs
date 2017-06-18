using BLL.DTO;
using BLL.Mapper;
using DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;

namespace BLL.Services.Implementation
{
    public class UserService:IUserService
    {
        private IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public UserDTO GetUser(int id)
        {
            var user = _uow.Users.Get(id);
            if (ReferenceEquals(user, null))
                return null;
            return user.ToUserDto();
        }

        public UserDTO GetUserByEmail(string email)
        {
            var user = _uow.Users.GetByEmail(email);
            if (ReferenceEquals(user, null))
                return null;
            return user.ToUserDto();
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            return _uow.Users.GetAll().Select(user => user.ToUserDto());

        }

        public void CreateUser(UserDTO user)
        {
            _uow.Users.Create(user.ToUserEntity());
            _uow.Save();
        }

        public void DeleteUser(UserDTO user)
        {
            _uow.Users.Delete(user.ToUserEntity());
            _uow.Save();

        }

        public void UpdateUser(UserDTO user)
        {
            _uow.Users.Update(user.ToUserEntity());
            var entityUser = _uow.Users.Get(user.Id);
            if (!ReferenceEquals(user.OldPassword, null) && !ReferenceEquals(user.NewPassword, null)
                && user.NewPassword == user.ConfirmPassword && Crypto.VerifyHashedPassword(entityUser.Password, user.OldPassword))
            {
                user.Password = Crypto.HashPassword(user.NewPassword);
                _uow.Users.UpdatePassword(user.ToUserEntity());
            }
            _uow.Save();
        }

        public void DeleteUser(int id)
        {
            _uow.Users.Delete(id);
            _uow.Save();
        }
    }
}
