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
    public class TestResultService:ITestResultService
    {

        private readonly IUnitOfWork _uow;

        public TestResultService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void CreateTestResult(TestResultDTO test)
        {
            _uow.Results.Create(test.ToTestResultEntity());
            _uow.Save();
        }

        public void DeleteTestResult(int id)
        {
            _uow.Results.Delete(id);
            _uow.Save();
        }

        public void DeleteTestResult(TestResultDTO test)
        {
            _uow.Results.Delete(test.ToTestResultEntity());
            _uow.Save();
        }

        public IEnumerable<TestResultDTO> GetAllTestResults()
        {
            return _uow.Results.GetAll().Select(test => test.ToTestResultDto());
            
        }

        public TestResultDTO GetTestResult(int id)
        {
            var testResult = _uow.Results.Get(id);
            if (ReferenceEquals(testResult, null))
                return null;
            return testResult.ToTestResultDto();
          
        }
    }
}
