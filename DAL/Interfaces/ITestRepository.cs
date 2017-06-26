using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.ORM;
using DAL.DTO;

namespace DAL.Interfaces
{
    public interface ITestRepository:IRepository<DalTest>
    {
        IEnumerable<DalTest> GetTestByName(string name);
    }
}
