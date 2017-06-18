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
        IProfileRepository Profiles { get; }
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }
        IResultRepository Results { get; }
        IQuestionRepository Questions { get; }
        IAnswerRepository Answers { get; }
        ITestRepository Test { get; }

        void Save();
    }
}
