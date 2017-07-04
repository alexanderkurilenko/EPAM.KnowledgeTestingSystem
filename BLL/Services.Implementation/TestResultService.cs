
using BLL.Entities;
using BLL.Mapper;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementation
{
    public class TestResultService:IResultService
    {
        private readonly IUnitOfWork _uow;
        private readonly IResultRepository repo;
        private readonly ITestRepository _trepo;

        public TestResultService(IUnitOfWork uow, IResultRepository rep,ITestRepository trep)
        {
            this._uow = uow;
            this.repo = rep;
            this._trepo = trep;
        }

        public void CreateTestResult(ResultEntity test)
        {
            repo.Create(test.ToDal());
            _uow.Save();
        }

        public void DeleteTestResult(ResultEntity test)
        {
            repo.Delete(test.Id);
            _uow.Save();
        }

        public IEnumerable<ResultEntity> GetAllResults()
        {
            return repo.GetAll().Select(r => r.ToBll());
        }

        public ResultEntity GetResultById(int id)
        {
            return repo.Get(id).ToBll();
        }

        public TimeSpan FindAverageTime(IEnumerable<ResultEntity> results)
        {
            double allTime = 0;
            foreach (var result in results)
            {
                allTime += result.PassingTime.TotalMinutes;
            }
            return TimeSpan.FromMinutes(allTime / results.Count());
        }

        public double FindAverageProcent(IEnumerable<ResultEntity> results)
        {
            double allProcent = 0;
            foreach (var result in results)
            {
                allProcent += result.PassingProcent;
            }
            return allProcent / results.Count();
        }

        public ResultEntity CheckTest(TestEntity currentTest)
        {
            var result = new ResultEntity();
            result.TestId = currentTest.Id;
            result.CorrectAnswerCount = CountOfCorrectAnswer(currentTest);
            result.PassingProcent = CalculatePassingProcent(result.CorrectAnswerCount,
    currentTest.Questions.Count);
            result.IsPassed = IsPassed(currentTest);

            return result;
        }
        #region Private Method
        private double CalculatePassingProcent(double correctCount, double countOfQuestion)
        {
            
            return ((double)correctCount / (double)countOfQuestion) * 100;
        }

        private bool IsPassed(TestEntity test)
        {
            int correctCount = CountOfCorrectAnswer(test);
            int countOfQuestion = test.Questions.Count;
            if (test.MinProcentToPassTest - CalculatePassingProcent(correctCount, countOfQuestion)>0)
                return false;
            else
                return true;
        }

        private int CountOfCorrectAnswer(TestEntity currentTest)
        {
            int correctAnswer = 0;
            var questions = _trepo.Get(currentTest.Id).Questions.ToList();
            foreach (var q in questions)
            {
                foreach (var a in q.Answers)
                {
                    if (currentTest.Questions.FirstOrDefault(m => q.Id == m.Id).SelectedAnswer == a.Id && a.IsCorrect)
                        correctAnswer++;
                }
            }
            return correctAnswer;
        }
        #endregion
    }
}
