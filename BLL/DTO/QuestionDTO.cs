using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Text { get; set; }

        public virtual ICollection<AnswerDTO> Answers { get; set; }



        public QuestionDTO()
        {
            Answers = new List<AnswerDTO>();
        }

    }
}
