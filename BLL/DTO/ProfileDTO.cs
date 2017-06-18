using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ProfileDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SurName { get; set; }

        public  UserDTO User { get; set; }

        public ICollection<TestDTO> Tests { get; set; }

        public ProfileDTO()
        {
            Tests = new List<TestDTO>();
        }
    }
}
