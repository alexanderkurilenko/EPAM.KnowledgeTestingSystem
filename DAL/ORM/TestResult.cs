using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM
{
    public class TestResult
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CorrectAnswerCount { get; set; }
        public bool IsPassed { get; set; }
        public double PassingProcent { get; set; }
        public TimeSpan PassingTime { get; set; }

        public int UserId { get; set; }
        public int TestId { get; set; }
        public User User { get; set; }
        public Test Test { get; set; }
    }
}
