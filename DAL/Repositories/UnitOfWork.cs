using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using System.Data.Entity;
using DAL.ORM;
using Ninject;
using DAL.Configurations;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private AnswerRepository answerRepository;
        private QuestionRepository questionRepository;
        private TestResultRepository testResultRepository;
        private RoleRepository roleRepository;
        private TestRepository testRepository;
        private UserRepository userRepository;

        private EpamKnowledgeSystemDbContext db;

        public UnitOfWork(string connection)
        {
            db = new EpamKnowledgeSystemDbContext(connection);
            //IKernel ninjectKernel = new StandardKernel(new DalDependency(connection));
            //db = ninjectKernel.Get<KnowledgeSystemDbContext>();
        }

        public IAnswerRepository Answers
        {
            get
            {
                if (answerRepository == null)
                    answerRepository = new AnswerRepository(db);
                return answerRepository;
            }
        }

        
        public IQuestionRepository Questions
        {
            get
            {
                if (questionRepository == null)
                    questionRepository = new QuestionRepository(db);
                return questionRepository;
            }
        }


        public IResultRepository Results
        {
            get
            {
                if (testResultRepository == null)
                    testResultRepository = new TestResultRepository(db);
                return testResultRepository;
            }
        }


        public IRoleRepository Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(db);
                return roleRepository;
            }
        }

        public ITestRepository Test
        {
            get
            {
                if (testRepository == null)
                    testRepository = new TestRepository(db);
                return testRepository;
            }
        }

        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}


