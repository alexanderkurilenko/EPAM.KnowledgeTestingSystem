using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TestDTO
    {
        public TestDTO()
        {
            Questions = new List<QuestionDTO>();
            Answers = new List<AnswerDTO>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int Time { get; set; }
        public string Description { get; set; }
        public int GoodAnswers { get; set; }

        public int BadAnswers { get; set; }
        public bool IsValid { get; set; }
        public string Creator { get; set; }
        public IList<AnswerDTO> Answers { get; set; }
        public IList<QuestionDTO> Questions { get; set; }
    }
}
