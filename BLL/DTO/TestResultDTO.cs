using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TestResultDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateComplete { get; set; }

        public int CorrectAnswers { get; set; }

        public int IncorrectAnswers { get; set; }

        public virtual TestDTO Test { get; set; }
    }
}
