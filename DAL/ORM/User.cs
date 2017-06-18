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

        public virtual ICollection<Role> Roles { get; set; }

        public virtual Profile UserProfile { get; set; }

        public User()
        {
            Roles = new List<Role>();
            
        } 
    }
}
