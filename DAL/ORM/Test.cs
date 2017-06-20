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
        public int Id { get; set; }

        public string Name { get; set; }

        public TimeSpan Time { get; set; }
        public string Description { get; set; }
        public int GoodAnswers { get; set; }

        public int BadAnswers { get; set; }
        public bool IsValid { get; set; }
        public string Creator { get; set; }
        public IList<Answer> Answers { get; set; }
        public IList<Question> Questions { get; set; }

    }
}
