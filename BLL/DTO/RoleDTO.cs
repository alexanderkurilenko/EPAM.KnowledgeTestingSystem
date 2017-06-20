﻿using DAL.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class RoleDTO
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Description { get; set; }

        public  IList<UserDTO> Users { get; set; }

       
    }
}

