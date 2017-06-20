using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM
{
    public class EpamKnowledgeSystemDbContext:DbContext
    {
        static EpamKnowledgeSystemDbContext()
        {
            
            Database.SetInitializer<EpamKnowledgeSystemDbContext>(new DbContextInitializer());
        }
        public EpamKnowledgeSystemDbContext() { }
        public EpamKnowledgeSystemDbContext(string connectionString) : base(connectionString)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TestResult> Results { get; set; }
        public DbSet<Question> Questions { get; set; }
        
    }
}
