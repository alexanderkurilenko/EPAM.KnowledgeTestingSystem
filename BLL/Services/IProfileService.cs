using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IProfileService
    {
        void UpdateProfile(ProfileDTO profile);

        ProfileDTO GetProfile(int id);
        IEnumerable<ProfileDTO> GetProfileBySurName(string surname);

        IEnumerable<ProfileDTO> GetAllprofiles();
        void CreateProfile(ProfileDTO profile);
        void DeleteProfile(ProfileDTO profile);
        void DeleteProfile(int id);
    }
}
