using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI.ViewModels;

namespace WebUI.Infrastructure.Mapper
{
    public static  class CustomPlMapper
    {
        #region Test
        public static TestEntity ToBll(this CreateTestViewModel test)
        {
            var testEntity = new TestEntity()
            {

                Time = test.Time,
                Creator = test.Creator,
                Description = test.Description,
                Name = test.Name,
                Questions = test.Questions?.Select(q => q.ToBll()).ToList(),
                MinProcentToPassTest=test.MinProcentToPassTest
                
            };
           
            return testEntity;
        }

        public static TestViewModel ToMvc(this TestEntity test)
        {
            var testMvc = new TestViewModel()
            {

                Id = test.Id,
                Creator = test.Creator,
                Description = test.Description,
                Name = test.Name,
                Time = test.Time
                
            };
            testMvc.Questions = new List<QuestionViewModel>();
            foreach (var q in test.Questions)
            {
                testMvc.Questions.Add(q.ToMvc());
            }

            return testMvc;
        }

        public static TestEntity ToBll(this TestViewModel test)
        {
            var testEntity = new TestEntity()
            {

                Id = test.Id,
                Creator = test.Creator,
                Description = test.Description,
                Name = test.Name,
                Time = test.Time,
                Questions=test.Questions?.Select(q=>q.ToBll()).ToList()

             };
           


            return testEntity;
        }

#endregion
        #region Questuion

        public static QuestionViewModel ToMvc(this QuestionEntity question)
        {
            var modelQuestion = new QuestionViewModel()
            {
                Id = question.Id,
                Text = question.Description,
                SelectedAnswer = question.SelectedAnswer,
                TestId = question.TestId

            };
            modelQuestion.Answers = new List<AnswerViewModel>();
            foreach (var q in question.Answers)
            {
                modelQuestion.Answers.Add(q.ToMvc());
            }
            return modelQuestion;
        }


        public static QuestionEntity ToBll(this QuestionViewModel question)
        {
            var questionEntity = new QuestionEntity()
            {
                Description = question.Text,
                SelectedAnswer = question.SelectedAnswer,
                Id = question.Id,
                TestId = question.TestId
            };
            questionEntity.Answers = new List<AnswerEntity>();
            if (question.Answers == null)
                return questionEntity;
            foreach (var q in question.Answers)
            {
                questionEntity.Answers.Add(q.ToBll());
            }
            return questionEntity;
        }



        #endregion

        #region Answer

        public static AnswerViewModel ToMvc(this AnswerEntity answer)
        {
            var dalAnswer = new AnswerViewModel()
            {
                Id = answer.Id,
                Text = answer.Description,
                IsCorrect = answer.IsCorrect,
                QuestionId = answer.QuestionId,
            };
            return dalAnswer;
        }

        public static AnswerEntity ToBll(this AnswerViewModel answer)
        {
            var answerEntity = new AnswerEntity()
            {
                QuestionId = answer.QuestionId,
                Description = answer.Text,
                IsCorrect = answer.IsCorrect,
                Id = answer.Id,
            };
            return answerEntity;
        }

        #endregion

        #region Result
        public static ResultViewModel ToMvc(this ResultEntity result)
        {
            var dalResult = new ResultViewModel()
            {
                Id = result.Id,
                CorrectAnswerCount = result.CorrectAnswerCount,
                IsPassed = result.IsPassed,
                PassingProcent = result.PassingProcent,
                PassingTime = result.PassingTime,
                Name = result.Name
            };
            return dalResult;
        }

        public static ResultEntity ToBll(this ResultViewModel result)
        {
            var resultEntity = new ResultEntity()
            {
                Id = result.Id,
                CorrectAnswerCount = result.CorrectAnswerCount,
                IsPassed = result.IsPassed,
                Name = result.Name
            };
            return resultEntity;
        }

        #endregion

        #region User
        public static ProfileViewModel ToMvc(this UserEntity user)
        {
            var userModel = new ProfileViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                Login = user.Login,
                RoleId = user.RoleId,
                Name = user.Name
            };
            return userModel;
        }

        public static EditProfileViewModel ToMvcEditProfile(this UserEntity user)
        {
            var userModel = new EditProfileViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                Login = user.Login,
                Name = user.Name,
                SelectedRole = user.RoleId,

            };
            return userModel;
        }


        public static EditUserViewModel ToMvcEditUser(this UserEntity user)
        {
            var userModel = new EditUserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                Login = user.Login,
                Name = user.Name,
                SelectedRole = user.RoleId,

            };
            return userModel;
        }

        public static UserEntity ToBll(this EditProfileViewModel user)
        {
            var userModel = new UserEntity()
            {
                Id = user.Id,
                Email = user.Email,
                Login = user.Login,
                Name = user.Name,
                Password = user.Password,
            };
            return userModel;
        }

        public static UserEntity ToBll(this EditUserViewModel user)
        {
            var userModel = new UserEntity()
            {
                Id = user.Id,
                Email = user.Email,
                Login = user.Login,
                Name = user.Name,
                RoleId = (int)user.SelectedRole
            };
            return userModel;
        }

        public static UserEntity ToBll(this ProfileViewModel user)
        {
            var userEntity = new UserEntity()
            {
                Id = user.Id,
                Email = user.Email,
                Login = user.Login,
                RoleId = user.RoleId,
                Name = user.Name
            };
            return userEntity;
        }
        #endregion
        public static RoleViewModel ToMvc(this RoleEntity role)
        {
            var roleModel = new RoleViewModel()
            {
                Id = role.Id,
                Name = role.Name

            };
            return roleModel;
        }
    }
}