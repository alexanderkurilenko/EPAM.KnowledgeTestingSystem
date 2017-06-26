using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class DalQuestion : IEntity
    {
        public DalQuestion()
        {
            Answers = new List<DalAnswer>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public int TestId { get; set; }
        public ICollection<DalAnswer> Answers { get; set; }
    }
}
