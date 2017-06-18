using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TestDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Topic { get; set; }

        public TimeSpan Time { get; set; }

        public  ICollection<QuestionDTO> Questions { get; set; }
        public  ICollection<TestResultDTO> Result { get; set; }
        public  ICollection<ProfileDTO> Profiles { get; set; }

        public TestDTO()
        {
            Questions = new List<QuestionDTO>();
        }
    }
}
