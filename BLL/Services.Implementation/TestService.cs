
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
    public class TestService:ITestService
    {
        private readonly IUnitOfWork uow;

        public TestService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public TestEntity GetTestById(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();
            return uow.Test.Get(id).ToBll();
        }

        public IEnumerable<TestEntity> GetAllTestEntities()
        {
            return uow.Test.GetAll().Select(t => t.ToBll());
        }

        public void CreateTest(TestEntity test)
        {
            if (test == null)
                throw new ArgumentNullException();
            uow.Test.Create(test.ToDal());
            uow.Save();
        }

        public void DeleteTest(TestEntity test)
        {
            if (test == null)
                throw new ArgumentNullException();
            uow.Test.Delete(test.Id);
            uow.Save();
        }

        public void UpdateTest(TestEntity test)
        {
            if (test == null)
                throw new ArgumentNullException();
            uow.Test.Update(test.ToDal());
            uow.Save();
        }

        public IEnumerable<TestEntity> GetTestByName(string name)
        {
            if (name == null)
                throw new ArgumentNullException();
            var test = uow.Test.GetTestByName(name);
            if (test == null)
                return null;
            return test.Select(t => t.ToBll());
        }
    }
}
