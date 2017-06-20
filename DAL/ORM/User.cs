using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM
{
    public class User
    {
        public User()
        {
            Roles = new List<Role>();
            TestResults = new List<TestResult>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Age { get; set; }

        public IList<Role> Roles { get; set; }
        public IList<TestResult> TestResults { get; set; }

    }
}
