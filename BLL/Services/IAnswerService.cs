using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IAnswerService
    {
        AnswerDTO GetAnswer(int id);
        IEnumerable<AnswerDTO> GetAllAnswers();
        void CreateAnswer(AnswerDTO answer);
        void DeleteAnswer(AnswerDTO answer);
        void DeleteAnswer(int key);
        void UpdateAnswer(AnswerDTO answer);
    }
}
