﻿
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
        private readonly ITestRepository repo;

        public TestService(IUnitOfWork uow, ITestRepository rep)
        {
            this.uow = uow;
            this.repo = rep;
        }

        public TestEntity GetTestById(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException();
            return repo.Get(id).ToBll();
        }

        public IEnumerable<TestEntity> GetAllTestEntities()
        {
            return repo.GetAll().Select(t => t.ToBll());
        }

        public void CreateTest(TestEntity test)
        {
            if (test == null)
                throw new ArgumentNullException();
            repo.Create(test.ToDal());
            uow.Save();
        }

        public void DeleteTest(TestEntity test)
        {
            if (test == null)
                throw new ArgumentNullException();
            repo.Delete(test.Id);
            uow.Save();
        }

        public void UpdateTest(TestEntity test)
        {
            if (test == null)
                throw new ArgumentNullException();
            repo.Update(test.ToDal());
            uow.Save();
        }

        public IEnumerable<TestEntity> GetTestByName(string name)
        {
            if (name == null)
                throw new ArgumentNullException();
            var test = repo.GetTestByName(name);
            if (test == null)
                return null;
            return test.Select(t => t.ToBll());
        }
    }
}
