using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM
{
    public class User
    {
       
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }

        public virtual string Email { get; set; }

        public virtual string Password { get; set; }

        public virtual int Age { get; set; }

        public virtual IList<Role> Roles { get; set; }
        public virtual IList<TestResult> TestResults { get; set; }


        public User()
        {
            Roles = new List<Role>();
            TestResults = new List<TestResult>();
        }

    }
}
