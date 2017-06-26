using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM
{
    public class Answer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Questions { get; set; }

    }
}
