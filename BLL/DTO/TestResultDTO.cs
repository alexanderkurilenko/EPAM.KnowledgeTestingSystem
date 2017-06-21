using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TestResultDTO : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GoodAnswers { get; set; }
        public int BadAnswers { get; set; }
        public UserDTO User { get; set; }
        public DateTime DateCompleted { get; set; }
    }
}
