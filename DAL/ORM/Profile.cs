using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM
{
    public class Profile
    {
       
        [Key, ForeignKey("User")]
        public int Id { get; set; }
         
        public string FirstName { get; set; }

        public string SurName { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Test> Tests { get; set; }

        public Profile()
        {
            Tests = new List<Test>();
        }
    }
}
