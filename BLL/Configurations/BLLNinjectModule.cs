using DAL.Configurations;
using DAL.Interfaces;
using DAL.Repositories;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Configurations
{
    public class BLLNinjectModule : NinjectModule
    {
        private string connectionString;
        public BLLNinjectModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
           
            Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
           
            Kernel.Load(new DALNinjectModule());

        }
    }
}
