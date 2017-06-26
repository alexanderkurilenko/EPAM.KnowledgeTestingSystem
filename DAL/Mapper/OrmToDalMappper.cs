using DAL.DTO;
using DAL.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Mapper
{
    public static class OrmToDalMappper
    {
        #region Test

        public static DalTest ToDal(this Test test)
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
            foreach (var t in test.Questions)
            {
                dalTest.Questions.Add(t.ToDal());
            }
            return dalTest;
        }

        public static Test ToEntity(this DalTest test)
        {
            var testEntity = new Test()
            {

                Id = test.Id,
                Creator = test.Creator,
                Description = test.Description,
                Name = test.Name,
                MinProcentToPassTest = test.MinProcentToPassTest,
                Time = test.Time

            };
            foreach (var t in test.Questions)
            {
                testEntity.Questions.Add(t.ToEntity());
            }
            return testEntity;
        }
        #endregion

        #region Questuion

        public static DalQuestion ToDal(this Question question)
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

        public static Question ToEntity(this DalQuestion question)
        {
            var questionEntity = new Question()
            {
                Id = question.Id,
                Description = question.Description,
                TestId = question.TestId,

            };
            foreach (var q in question.Answers)
            {
                questionEntity.Answers.Add(q.ToEntity());
            }
            return questionEntity;
        }

        #endregion

        #region Answer

        public static DalAnswer ToDal(this Answer answer)
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

        public static Answer ToEntity(this DalAnswer answer)
        {
            var answerEntity = new Answer()
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

        public static DalRole ToDal(this Role role)
        {
            var dalRole = new DalRole()
            {
                Id = role.Id,
                Name = role.Name,
            };
            return dalRole;
        }

        public static Role ToEntity(this DalRole role)
        {
            var roleEntity = new Role()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description
            };
            return roleEntity;
        }


        #endregion

        #region Result
        public static DalResult ToDal(this TestResult result)
        {
            var dalResult = new DalResult()
            {
                Id = result.Id,
                CorrectAnswerCount = result.CorrectAnswerCount,
                Name = result.Name,
                IsPassed = result.IsPassed,
                PassingTime = result.PassingTime,
                PassingProcent = result.PassingProcent,
                TestId = result.TestId,
                UserId = result.UserId
            };
            return dalResult;
        }

        public static TestResult ToEntity(this DalResult result)
        {
            var resultEntity = new TestResult()
            {
                Id = result.Id,
                CorrectAnswerCount = result.CorrectAnswerCount,
                IsPassed = result.IsPassed,
                Name = result.Name,
                PassingTime = result.PassingTime,
                PassingProcent = result.PassingProcent,
                TestId = result.TestId,
                UserId = result.UserId,
            };
            return resultEntity;
        }


        #endregion

        #region User
        public static DalUser ToDal(this User user)
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

        public static User ToEntity(this DalUser user)
        {
            var userEntity = new User()
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
