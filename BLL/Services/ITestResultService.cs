using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ITestResultService
    {
        TestResultDTO GetTestResult(int id);
        void CreateTestResult(TestResultDTO test);
        void DeleteTestResult(TestResultDTO test);
        void DeleteTestResult(int id);

        IEnumerable<TestResultDTO> GetAllTestResults();
    }
}
