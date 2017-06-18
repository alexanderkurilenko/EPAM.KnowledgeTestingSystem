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

        public string Title { get; set; }

        public string Topic { get;set;}

        public TimeSpan Time { get; set; }

        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Profile> Profiles { get; set; }
        public virtual ICollection<TestResult> Result { get; set; }

        public Test()
        {
            Questions = new List<Question>();
            Profiles = new List<Profile>();
            Result = new List<TestResult>();
        }
    }
}
