using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class DalResult : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CorrectAnswerCount { get; set; }
        public bool IsPassed { get; set; }
        public double PassingProcent { get; set; }

        public TimeSpan PassingTime { get; set; }

        public int UserId { get; set; }
        public int TestId { get; set; }
    }
}
