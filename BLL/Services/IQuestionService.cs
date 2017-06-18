using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IQuestionService
    {
        QuestionDTO GetQuestion(int id);
        IEnumerable<QuestionDTO> GetAllQuestions();
        void CreateQuestion(QuestionDTO question);
        void DeleteQuestion(QuestionDTO question);
        void DeleteQuestion(int id);
        void UpdateQuestion(QuestionDTO question);
    }
}
