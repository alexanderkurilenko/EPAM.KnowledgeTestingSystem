using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM
{
    public class Answer
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public Test Test { get; set; }

    }
}
