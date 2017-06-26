using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class DalTest:IEntity
    {
        public DalTest()
        {
            Questions = new List<DalQuestion>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }
        public int Time { get; set; }
        public int MinProcentToPassTest { get; set; }

        public ICollection<DalQuestion> Questions { get; set; }
    }
}
