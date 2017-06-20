﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM
{
    public class Role
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public  IList<User> Users { get; set; }

        
    }
}
