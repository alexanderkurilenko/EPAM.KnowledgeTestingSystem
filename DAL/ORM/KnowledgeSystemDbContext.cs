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
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
             modelBuilder.Entity<User>()
                 .HasMany(i => i.Roles)
                 .WithMany(u => u.Users)
                 .Map(m =>
                 {
            m.ToTable("UserRole");
            m.MapLeftKey("UserId");
            m.MapRightKey("RoleId");
                            });
 
             modelBuilder.Entity<User>()
                 .HasMany(i => i.TestResults)
                 .WithRequired(u => u.User);
 
             modelBuilder.Entity<Test>()
                 .HasMany(i => i.Questions)
                 .WithRequired(u => u.Test);
 
             modelBuilder.Entity<Test>()
                 .HasMany(i => i.Answers)
                 .WithRequired(u => u.Test);
         }

        public DbSet<User> Users { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<TestResult> Results { get; set; }
        public DbSet<Question> Questions { get; set; }
        
    }
}
