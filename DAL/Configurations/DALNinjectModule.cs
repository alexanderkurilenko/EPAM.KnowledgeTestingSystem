using DAL.Interfaces;
using DAL.ORM;
using DAL.Repositories;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Configurations
{
    public class DALNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserRepository>().To<UserRepository>();
            Bind<ITestRepository>().To<TestRepository>();
            Bind<IRoleRepository>().To<RoleRepository>();
            Bind<IResultRepository>().To<TestResultRepository>();
            Bind<DbContext>().To<KnowledgeSystemDbContext>().InRequestScope();
           
        }
    }
}
