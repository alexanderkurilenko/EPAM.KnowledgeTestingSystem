﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ORM
{
    public class Role
    {
        public Role()
        {
            Users = new List<User>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IList<User> Users { get; set; }
    }
}
