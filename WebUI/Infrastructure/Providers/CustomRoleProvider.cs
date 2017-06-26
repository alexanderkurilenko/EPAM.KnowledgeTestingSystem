
using BLL.Entities;
using BLL.Services;
using BLL.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebUI.Util;

namespace WebUI.Infrastructure.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        private readonly IUserService _userService = System.Web.Mvc.DependencyResolver.Current.GetService<UserService>();
        private readonly IRoleService _roleService = System.Web.Mvc.DependencyResolver.Current.GetService<RoleService>();

        public override string ApplicationName { get; set; }

        public override bool IsUserInRole(string email, string roleName)
        {
            var role = _roleService.GetRoleEntity(_userService.GetUserByEmail(email).RoleId);
            if (role.Name == roleName)
                return true;
            return false;
        }

        public override string[] GetRolesForUser(string name)
        {
            var roles = new string[] { };
            var users = _userService.GetAllUserEntities();
            var user = users.FirstOrDefault(u => u.Login == name);

            if (user == null) return roles;

            var role = _roleService.GetRoleEntity(user.RoleId);
            return new[] { role.Name };
        }

        public override void CreateRole(string roleName)
        {
            var newRole = new RoleEntity { Name = roleName };
            _roleService.CreateRole(newRole);
        }

        #region not implemented

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}