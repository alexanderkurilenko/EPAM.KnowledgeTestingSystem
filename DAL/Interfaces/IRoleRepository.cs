﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ORM;
using DAL.DTO;

namespace DAL.Interfaces
{
    public interface IRoleRepository:IRepository<DalRole>
    {
        DalRole GetRoleByName(string name);
    }
}
