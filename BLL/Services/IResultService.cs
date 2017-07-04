using BLL.Entities;
using System;
using System.Collections.Generic;

namespace BLL.Services
{
    public interface IResultService
    {
        ResultEntity GetResultById(int id);
        IEnumerable<ResultEntity> GetAllResults();
        void CreateTestResult(ResultEntity test);
        void DeleteTestResult(ResultEntity test);
        ResultEntity CheckTest(TestEntity test);
        TimeSpan FindAverageTime(IEnumerable<ResultEntity> results);
        double FindAverageProcent(IEnumerable<ResultEntity> results);
    }
}
