using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class QuestionEntity
    {
        public QuestionEntity()
        {
            Answers = new List<AnswerEntity>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int TestId { get; set; }
        public TestEntity Test { get; set; }
        public int? SelectedAnswer { get; set; }
        public ICollection<AnswerEntity> Answers { get; set; }
    }
}
