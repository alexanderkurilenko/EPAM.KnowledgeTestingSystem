
using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ITestService
    {
        TestEntity GetTestById(int id);
        IEnumerable<TestEntity> GetAllTestEntities();
        void CreateTest(TestEntity test);
        void DeleteTest(TestEntity test);
        void UpdateTest(TestEntity test);
        IEnumerable<TestEntity> GetTestByName(string test);
    }
}
