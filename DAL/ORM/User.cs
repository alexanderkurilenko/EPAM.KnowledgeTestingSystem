using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get;set;}

        public string Email { get; set; }

        public string Password { get; set; }

        public IList<Role> Roles { get; set; }

        public Profile UserProfile { get; set; }

        
    }
}
