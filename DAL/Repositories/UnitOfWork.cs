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
        private DbContext db;

        public UnitOfWork(DbContext context)
        {
            db = context;
            //IKernel ninjectKernel = new StandardKernel(new DalDependency(connection));
            //db = ninjectKernel.Get<KnowledgeSystemDbContext>();
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


