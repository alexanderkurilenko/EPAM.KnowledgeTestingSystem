using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ORM;
using BLL.DTO;

namespace BLL.Mapper
{
    public static class CustomBLLMapper
    {
        #region user mapping
        /// <summary>
        /// The method converts an object of type User to an object of type UserDTO.
        /// </summary>
        /// <param name="userEntity">An object of type User.</param>
        /// <returns>An object of type UserDTO.</returns>
        public static UserDTO ToUserDto(this User userEntity)
        {
            if (ReferenceEquals(userEntity, null))
                return null;
            return new UserDTO()
            {
                Id = userEntity.Id,              
                Email = userEntity.Email,
                Password = userEntity.Password, 
                Roles = userEntity.Roles.ToRoleDtoCollection().ToList(),
                Login=userEntity.Login,
                UserProfile=userEntity.UserProfile.ToProfileDto()
            };
        }

        /// <summary>
        /// The method converts an object of type UserDTO to an object of type User.
        /// </summary>
        /// <param name="userDto">An object of type UserDTO.</param>
        /// <returns>An object of type User.</returns>
        public static User ToUserEntity(this UserDTO userDto)
        {
            return new User()
            {
                Id = userDto.Id,
                Email = userDto.Email,
                Password = userDto.Password,
                Login = userDto.Login,
                Roles = userDto.Roles.ToRoleCollection().ToList(),
                UserProfile=userDto.UserProfile.ToProfileEntity()
            };
        }
        #endregion

        #region  profile mapping
        
        public static ProfileDTO ToProfileDto(this Profile profileEntity)
        {
            if (ReferenceEquals(profileEntity, null))
                return null;
            return new ProfileDTO()
            {
                FirstName = profileEntity.FirstName,
                SurName = profileEntity.SurName,
                Id=profileEntity.Id,
                User=profileEntity.User.ToUserDto(),
                Tests=profileEntity.Tests.ToTestDTOCollection().ToList()
            };
        }

        public static Profile ToProfileEntity(this ProfileDTO profileDto)
        {
            if (ReferenceEquals(profileDto, null))
                return null;
            return new Profile()
            {
                Id = profileDto.Id,
                FirstName=profileDto.FirstName,
                SurName=profileDto.SurName,
                Tests=profileDto.Tests.ToTestCollection().ToList()
            };
        }
        #endregion

        #region test mapping
        /// <summary>
        /// The method converts an object of type Test to an object of type TestDTO.
        /// </summary>
        /// <param name="testEntity">An object of type Test.</param>
        /// <returns>An object of type TestDTO.</returns>
        public static TestDTO ToTestDto(this Test testEntity)
        {
            if (ReferenceEquals(testEntity, null))
                return null;
            return new TestDTO()
            {
                Id = testEntity.Id,
                Topic=testEntity.Topic,
                Time=testEntity.Time,
                Title=testEntity.Title,
                Result=testEntity.Result.ToTestResultDtoCollection().ToList(),
                Questions=testEntity.Questions.ToQuestionDtoCollection().ToList(),
                Profiles=testEntity.Profiles.ToProfileDtoCollection().ToList()
            };
        }

        /// <summary>
        /// The method converts an object of type TestDTO to an object of type Test.
        /// </summary>
        /// <param name="testDto">An object of type TestDTO.</param>
        /// <returns>An object of type Test.</returns>
        public static Test ToTestEntity(this TestDTO testDto)
        {
            return new Test()
            {
                Id = testDto.Id,
                Title = testDto.Title,
                Time = testDto.Time,
                Result = testDto.Result.ToTestResultCollection().ToList(),
                Questions = testDto.Questions.ToQuestionCollection().ToList(),
                Topic = testDto.Topic,
                Profiles = testDto.Profiles.ToProfileCollection().ToList()

            };
        }

        #endregion

        #region test RESULT  mapping
       
        public static TestResultDTO ToTestResultDto(this TestResult testResultEntity)
        {
            if (ReferenceEquals(testResultEntity, null))
                return null;
            return new TestResultDTO()
            {
                Id = testResultEntity.Id,
                DateComplete = testResultEntity.DateComplete,
                CorrectAnswers = testResultEntity.CorrectAnswers,
                IncorrectAnswers=testResultEntity.IncorrectAnswers,
                Name=testResultEntity.Name,
               
            };
        }

        public static TestResult ToTestResultEntity(this TestResultDTO testResultDto)
        {
            return new TestResult()
            {
                Id=testResultDto.Id,
                IncorrectAnswers=testResultDto.IncorrectAnswers,
                CorrectAnswers=testResultDto.CorrectAnswers,
              
                DateComplete=testResultDto.DateComplete,
                Name=testResultDto.Name
                
            };
        }
        #endregion

        #region Question  mapping

        public static QuestionDTO ToQuestionDto(this Question questionEntity)
        {
            if (ReferenceEquals(questionEntity, null))
                return null;
            return new QuestionDTO()
            {
                Id=questionEntity.Id,
                Answers=questionEntity.Answers.ToAnswerDtoCollection().ToList(),
                Text=questionEntity.Text,
                Type=questionEntity.Type

            };
        }

    
        public static Question ToQuestionEntity(this QuestionDTO questionDto)
        {
            return new Question()
            {
               Id=questionDto.Id,
               Answers=questionDto.Answers.ToAnswerCollection().ToList(),
               Text=questionDto.Text,
               Type=questionDto.Type
            };
        }
        #endregion

        #region Answer Mapping

        public static AnswerDTO ToAnswerDto(this Answer answerEntity)
        {
            if (ReferenceEquals(answerEntity, null))
                return null;
            return new AnswerDTO()
            {
               Id=answerEntity.Id,
               IsCorrect=answerEntity.IsCorrect,
               Text=answerEntity.Text
               

            };
        }


        public static Answer ToAnswerEntity(this AnswerDTO answerDto)
        {
            return new Answer()
            {
                Id=answerDto.Id,
                IsCorrect=answerDto.IsCorrect,
                Text=answerDto.Text
            };
        }

        #endregion

        #region Role Mapping

        public static RoleDTO ToRoleDto(this Role roleEntity)
        {
            if (ReferenceEquals(roleEntity, null))
                return null;
            return new RoleDTO()
            {
                Id=roleEntity.Id,
                Type=roleEntity.Type,
                Description=roleEntity.Description,

                Users=roleEntity.Users.ToUserDtoCollection().ToList()

            };
        }


        public static Role ToRoleEntity(this RoleDTO roleDto)
        {
            return new Role()
            {
                Id=roleDto.Id,
                Type=roleDto.Type,
                Description=roleDto.Description,
                Users=roleDto.Users.ToUserCollection().ToList()
            };
        }

        #endregion

        #region private methods

        private static IEnumerable<TestResult> ToTestResultCollection(this IEnumerable<TestResultDTO> collectionTestResultDto)
        {
            foreach (var testResultDto in collectionTestResultDto)
            {
                yield return testResultDto.ToTestResultEntity();
            }
        }

        private static IEnumerable<TestResultDTO> ToTestResultDtoCollection(this IEnumerable<TestResult> collectionTestResult)
        {
            foreach (var testResult in collectionTestResult)
            {
                yield return testResult.ToTestResultDto();
            }
        }

        private static IEnumerable<Profile> ToProfileCollection(this IEnumerable<ProfileDTO> collectionProfileDto)
        {
            foreach (var profileDTO in collectionProfileDto)
            {
                yield return profileDTO.ToProfileEntity();
            }
        }

        private static IEnumerable<ProfileDTO> ToProfileDtoCollection(this IEnumerable<Profile> collectionProfile)
        {
            foreach (var Profile in collectionProfile)
            {
                yield return Profile.ToProfileDto();
            }
        }

        private static IEnumerable<User> ToUserCollection(this IEnumerable<UserDTO> collectionUserDto)
        {
            foreach (var userDTO in collectionUserDto)
            {
                yield return userDTO.ToUserEntity();
            }
        }

        private static IEnumerable<UserDTO> ToUserDtoCollection(this IEnumerable<User> collectionUser)
        {
            foreach (var user in collectionUser)
            {
                yield return user.ToUserDto();
            }
        }

        private static IEnumerable<Role> ToRoleCollection(this IEnumerable<RoleDTO> collectionRoleDto)
        {
            foreach (var roleDTO in collectionRoleDto)
            {
                yield return roleDTO.ToRoleEntity();
            }
        }

        private static IEnumerable<RoleDTO> ToRoleDtoCollection(this IEnumerable<Role> collectionRole)
        {
            foreach (var role in collectionRole)
            {
                yield return role.ToRoleDto();
            }
        }

        private static IEnumerable<Answer> ToAnswerCollection(this IEnumerable<AnswerDTO> collectionAnswerDto)
        {
            foreach (var AnswerDTO in collectionAnswerDto)
            {
                yield return AnswerDTO.ToAnswerEntity();
            }
        }

        private static IEnumerable<AnswerDTO> ToAnswerDtoCollection(this IEnumerable<Answer> collectionAnswer)
        {
            foreach (var answer in collectionAnswer)
            {
                yield return answer.ToAnswerDto();
            }
        }
        private static IEnumerable<Question> ToQuestionCollection(this IEnumerable<QuestionDTO> collectionQuestionDto)
        {
            foreach (var questionDTO in collectionQuestionDto)
            {
                yield return questionDTO.ToQuestionEntity();
            }
        }

        private static IEnumerable<QuestionDTO> ToQuestionDtoCollection(this IEnumerable<Question> collectionQuestion)
        {
            foreach (var question in collectionQuestion)
            {
                yield return question.ToQuestionDto();
            }
        }
        private static IEnumerable<Test> ToTestCollection(this IEnumerable<TestDTO> collectionTestDto)
        {
            foreach (var testDTO in collectionTestDto)
            {
                yield return testDTO.ToTestEntity();
            }
        }

        private static IEnumerable<TestDTO> ToTestDTOCollection(this IEnumerable<Test> collectionTest)
        {
            foreach (var testResult in collectionTest)
            {
                yield return testResult.ToTestDto();
            }
        }
        #endregion
    }
}
       