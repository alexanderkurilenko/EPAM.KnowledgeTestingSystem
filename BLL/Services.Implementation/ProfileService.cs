using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using DAL.Interfaces;
using BLL.Mapper;

namespace BLL.Services.Implementation
{
    public class ProfileService : IProfileService
    {
        private IUnitOfWork _uow;

        public ProfileService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public void CreateProfile(ProfileDTO profile)
        {
            _uow.Profiles.Create(profile.ToProfileEntity());
            _uow.Save();
        }

        public void DeleteProfile(int id)
        {
            _uow.Profiles.Delete(id);
            _uow.Save();
        }

        public void DeleteProfile(ProfileDTO profile)
        {
            _uow.Profiles.Delete(profile.ToProfileEntity());
            _uow.Save();
        }

        public IEnumerable<ProfileDTO> GetAllprofiles()
        {
            return _uow.Profiles.GetAll().Select(profile => profile.ToProfileDto());
        }

        public ProfileDTO GetProfile(int id)
        {
            var profile = _uow.Profiles.Get(id);
            if (ReferenceEquals(profile, null))
                return null;
            return profile.ToProfileDto();
        }

        public IEnumerable<ProfileDTO> GetProfileBySurName(string surname)
        {
            var profile = _uow.Profiles.Find(prof => prof.SurName == surname);
            if (ReferenceEquals(profile, null))
                return null;
            var result = new List<ProfileDTO>();
            foreach(var res in profile)
            {
                result.Add(res.ToProfileDto());
            }
            return result;
        }

        public void UpdateProfile(ProfileDTO profile)
        {
            _uow.Profiles.Update(profile.ToProfileEntity());
            _uow.Profiles.ChangeName(profile.ToProfileEntity());
            _uow.Profiles.ChangeSurName(profile.ToProfileEntity());
            _uow.Save();
        }      
    }
}
