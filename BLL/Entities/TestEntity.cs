using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Entities
{
    public class TestEntity
    {
        public TestEntity()
        {
            Questions = new List<QuestionEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }
        public int MinProcentToPassTest { get; set; }
        public int Time { get; set; }
        public ICollection<QuestionEntity> Questions { get; set; }
    }
    
}
