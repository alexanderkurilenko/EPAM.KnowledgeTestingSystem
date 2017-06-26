using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ORM;
using BLL.Entities;
using DAL.DTO;

namespace BLL.Mapper
{
    public static class CustomBLLMapper
    {
        #region Test
        public static TestEntity ToBll(this DalTest test)
        {
            var testEntity = new TestEntity()
            {

                Id = test.Id,
                Creator = test.Creator,
                Description = test.Description,
                Name = test.Name,
                MinProcentToPassTest = test.MinProcentToPassTest,
                Time = test.Time,
            };
            foreach (var q in test.Questions)
            {
                testEntity.Questions.Add(q.ToBll());
            }
            return testEntity;
        }

        public static DalTest ToDal(this TestEntity test)
        {
            var dalTest = new DalTest()
            {

                Id = test.Id,
                Creator = test.Creator,
                Description = test.Description,
                Name = test.Name,
                MinProcentToPassTest = test.MinProcentToPassTest,
                Time = test.Time
            };
            foreach (var q in test.Questions)
            {
                dalTest.Questions.Add(q.ToDal());
            }
            return dalTest;
        }


        #endregion

        #region Questuion

        public static DalQuestion ToDal(this QuestionEntity question)
        {
            var dalQuastion = new DalQuestion()
            {
                Id = question.Id,
                Description = question.Description,
                TestId = question.TestId,
            };
            foreach (var q in question.Answers)
            {
                dalQuastion.Answers.Add(q.ToDal());
            }
            return dalQuastion;
        }

        public static QuestionEntity ToBll(this DalQuestion question)
        {
            var questionEntity = new QuestionEntity()
            {
                Id = question.Id,
                Description = question.Description,
                TestId = question.TestId,

            };
            foreach (var q in question.Answers)
            {
                questionEntity.Answers.Add(q.ToBll());
            }
            return questionEntity;
        }

        #endregion

        #region Answer

        public static DalAnswer ToDal(this AnswerEntity answer)
        {
            var dalAnswer = new DalAnswer()
            {
                Id = answer.Id,
                Description = answer.Description,
                IsCorrect = answer.IsCorrect,
                QuestionId = answer.QuestionId,
            };
            return dalAnswer;
        }

        public static AnswerEntity ToBll(this DalAnswer answer)
        {
            var answerEntity = new AnswerEntity()
            {
                Id = answer.Id,
                Description = answer.Description,
                IsCorrect = answer.IsCorrect,
                QuestionId = answer.QuestionId,
            };
            return answerEntity;
        }

        #endregion

        #region Role

        public static DalRole ToDal(this RoleEntity role)
        {
            var dalRole = new DalRole()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
            return dalRole;
        }

        public static RoleEntity ToBll(this DalRole role)
        {
            var roleEntity = new RoleEntity()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
            return roleEntity;
        }


        #endregion

        #region Result
        public static DalResult ToDal(this ResultEntity result)
        {
            var dalResult = new DalResult()
            {
                Id = result.Id,
                Name = result.Name,
                CorrectAnswerCount = result.CorrectAnswerCount,
                IsPassed = result.IsPassed,
                PassingTime = result.PassingTime,
                PassingProcent = result.PassingProcent,
                TestId = result.TestId,
                UserId = result.UserId
            };
            return dalResult;
        }

        public static ResultEntity ToBll(this DalResult result)
        {
            var resultEntity = new ResultEntity()
            {
                Id = result.Id,
                Name = result.Name,
                CorrectAnswerCount = result.CorrectAnswerCount,
                IsPassed = result.IsPassed,
                PassingTime = result.PassingTime,
                PassingProcent = result.PassingProcent,
                TestId = result.TestId,
                UserId = result.UserId
            };
            return resultEntity;
        }


        #endregion

        #region User
        public static DalUser ToDal(this UserEntity user)
        {
            var dalUser = new DalUser()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
                RoleId = user.RoleId,
            };

            return dalUser;
        }

        public static UserEntity ToBll(this DalUser user)
        {
            var userEntity = new UserEntity()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Login = user.Login,
                Password = user.Password,
                RoleId = user.RoleId,

            };
            return userEntity;
        }

        #endregion

    }
}
       