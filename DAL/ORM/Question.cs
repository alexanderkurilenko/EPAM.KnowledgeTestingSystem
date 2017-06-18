using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM
{
    public class Question
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Text { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        

        public Question()
        {
            Answers = new List<Answer>();
        }

        
    }
}
