using BLL.DTO;
using BLL.Mapper;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementation
{
    public class TestService:ITestService
    {
        private readonly IUnitOfWork _uow;

        public TestService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public void CreateTest(TestDTO test)
        {
            _uow.Test.Create(test.ToTestEntity());
        }

        public void DeleteTest(int id)
        {
            _uow.Test.Delete(id);
        }

        public void DeleteTest(TestDTO test)
        {
            _uow.Test.Delete(test.ToTestEntity());
        }

        public IEnumerable<TestDTO> GetAllTests()
        {
            return _uow.Test.GetAll().Select(test => test.ToTestDto());
        }

        public TestDTO GetTest(int id)
        {
            var test = _uow.Test.Get(id);
            if (ReferenceEquals(test, null))
                return null;
            return test.ToTestDto();
        }

        public void UpdateTest(TestDTO test)
        {
            _uow.Test.Update(test.ToTestEntity());
        }

        public TestResultDTO CheckAnswers(TestDTO test)
        {
            var entityModel = _uow.Test.Get(test.Id).ToTestDto();
            List<AnswerDTO> lhs = entityModel.Answers.ToList();
            List<string> rhs = new List<string>();
            foreach (var answer in test.Answers)
            {
                if (!ReferenceEquals(answer.Value, null))
                    rhs.Add(answer.Value);
                else
                {
                    rhs.Add(String.Empty);
                }
            }
            foreach (var answer in entityModel.Answers)
            {
                if (ReferenceEquals(answer.Value, null))
                    answer.Value = String.Empty;
            }
            int goodAnswers = 0;
            for (int i = 0; i < test.Answers.Count; i++)
            {
                if (lhs[i].Value.ToLower() == rhs[i].ToLower())
                    goodAnswers++;
            }
            int badAnswers = test.Answers.Count - goodAnswers;
            return new TestResultDTO()
            {
                GoodAnswers = goodAnswers,
                BadAnswers = badAnswers
            };
        }
    }
}
