
using System;
using System.Collections.Generic;

using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM
{
    public class DbContextInitializer: DropCreateDatabaseIfModelChanges<EpamKnowledgeSystemDbContext>
    {
        protected override void Seed(EpamKnowledgeSystemDbContext db)
        {
            

        }
    }
}
