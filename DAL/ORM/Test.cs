using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }
        public int Time { get; set; }
        public int MinProcentToPassTest { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public Test()
        {
            Questions = new List<Question>();
        }
    }
}
