using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class ProfileViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SurName { get; set; }

        public UserViewModel User { get; set; }

        public IList<TestViewModel> Tests { get; set; }

        public ProfileViewModel()
        {
            Tests = new List<TestViewModel>();
        }
    }
}