using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }

        public ICollection<RoleDTO> Roles { get; set; }

        public ProfileDTO UserProfile { get; set; }

        public UserDTO()
        {
            Roles = new List<RoleDTO>();

        }
    }
}
