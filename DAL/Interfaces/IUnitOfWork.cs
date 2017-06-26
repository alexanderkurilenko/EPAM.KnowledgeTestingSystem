using DAL.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IResultRepository Results { get; }
        //IQuestionRepository Questions { get; }
       // IAnswerRepository Answers { get; }
        ITestRepository Test { get; }

        void Save();
    }
}
