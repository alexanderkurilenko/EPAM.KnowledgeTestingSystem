using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ITestService
    {
        TestDTO GetTest(int id);

        IEnumerable<TestDTO> GetAllTests();
        void CreateTest(TestDTO test);
        void DeleteTest(TestDTO test);
        void DeleteTest(int id);
        void UpdateTest(TestDTO test);
        TestResultDTO CheckAnswers(TestDTO test);
    }
}
