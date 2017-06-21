using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM
{
    public class Question
    {

        public virtual int Id { get; set; }

        public virtual string Value { get; set; }
        public virtual Test Test { get; set; }

    }
}
