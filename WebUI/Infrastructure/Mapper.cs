using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.ViewModels;
using BLL.Mapper;

namespace WebUI.Infrastructure
{
    public static class Mapper
    {
        #region user mapping
        public static UserViewModel ToMvcUser(this UserDTO userEntity)
        {
            return new UserViewModel()
            {
                Id = userEntity.Id,
                Login = userEntity.Login,
                Email = userEntity.Email,
                Roles = userEntity.Roles,
                Password = userEntity.Password,
                OldPassword = userEntity.OldPassword,
                NewPassword = userEntity.NewPassword,
                ConfirmPassword = userEntity.ConfirmPassword,
                UserProfile = userEntity.UserProfile

            };
        }

        public static UserDTO ToBllUser(this UserViewModel userViewModel)
        {
            return new UserDTO()
            {
                Id = userViewModel.Id,
                Login = userViewModel.Login,
                Email = userViewModel.Email,
                Roles = userViewModel.Roles,
                Password = userViewModel.Password,
                OldPassword = userViewModel.OldPassword,
                NewPassword = userViewModel.NewPassword,
                ConfirmPassword = userViewModel.ConfirmPassword,
                UserProfile = userViewModel.UserProfile
            };
        }
        #endregion

        #region  Profile Mapping
        public static ProfileViewModel ToMvcProfile(this ProfileDTO profileEntity)
        {
            return new ProfileViewModel()
            {
                Id = profileEntity.Id,
                FirstName=profileEntity.FirstName,
                SurName=profileEntity.SurName,
                Tests=profileEntity.Tests.Select(t=>t.ToMvcTest()).ToList()

            };
        }
        public static ProfileDTO ToBllProfile(this ProfileViewModel profileViewModel)
        {
            return new ProfileDTO()
            {
                Id=profileViewModel.Id,
                SurName=profileViewModel.SurName,
                FirstName=profileViewModel.FirstName,
                Tests=profileViewModel.Tests.Select(t=>t.ToBllTest()).ToList()
            };
        }
        #endregion

        #region Test mapping
        public static TestViewModel ToMvcTest(this TestDTO entityTest)
        {
            return new TestViewModel()
            {
                Id = entityTest.Id,
                Questions = entityTest.Questions,
                Result = entityTest.Result,
                Time = entityTest.Time,
                Title = entityTest.Title,
                Topic = entityTest.Topic
            };
        }
        public static TestDTO ToBllTest(this TestViewModel test)
        {
            if (test == null)
            {
                return null;
            }
            return new TestDTO()
            {
                Id = test.Id,
                Questions = test.Questions,
                Time = test.Time,
                Result = test.Result,
                Title = test.Title,
                Topic = test.Topic
            };
        }
        #endregion
    }
}