using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ORM;

namespace DAL.Interfaces
{
    public interface IProfileRepository:IRepository<Profile>
    {
        void ChangeName(Profile profile);
        void ChangeSurName(Profile profile);
    }
}
