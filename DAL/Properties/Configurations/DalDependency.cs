using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ORM;
using Ninject.Web.Common;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL.Configurations
{
    public class DalDependency : NinjectModule
    {
        private string connection;

        public DalDependency(string conn)
        {
            connection = conn;
        }
        public override void Load()
        {    
            Bind<DbContext>().To<EpamKnowledgeSystemDbContext>().InRequestScope().WithConstructorArgument("connectionString", connection);
            Bind<IUserRepository>().To<UserRepository>();
            Bind<ITestRepository>().To<TestRepository>();
            Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
        }
    }
}
