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
        public DateTime DateComplete { get; set; }
        public int GoodAnswers { get; set; }
        public int BadAnswers { get; set; }
        public User User { get; set; }
    }
}
