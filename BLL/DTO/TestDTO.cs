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

        public  IList<QuestionDTO> Questions { get; set; }
        public  IList<TestResultDTO> Result { get; set; }
        public  IList<ProfileDTO> Profiles { get; set; }

        public TestDTO()
        {
            Questions = new List<QuestionDTO>();
            Result = new List<TestResultDTO>();
        }
    }
}
