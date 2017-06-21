using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM
{
    public class Test
    {
        public Test()
        {
            Questions = new List<Question>();
            Answers = new List<Answer>();
        }
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual int  Time { get; set; }
        public virtual string Description { get; set; }
        public virtual int GoodAnswers { get; set; }

        public virtual int BadAnswers { get; set; }
        public virtual bool IsValid { get; set; }
        public virtual string Creator { get; set; }
        public virtual IList<Answer> Answers { get; set; }
        public virtual IList<Question> Questions { get; set; }

        public int? TestResultId { get; set; }
        public virtual TestResult TestResult { get; set; }

    }
}
