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
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime DateComplete { get; set; }
        public virtual int GoodAnswers { get; set; }
        public virtual int BadAnswers { get; set; }
        public virtual User User { get; set; }
    }
}
