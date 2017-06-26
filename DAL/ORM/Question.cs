using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM
{
    public class Question
    {
        public Question()
        {
            Answers = new List<Answer>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

    }
}
