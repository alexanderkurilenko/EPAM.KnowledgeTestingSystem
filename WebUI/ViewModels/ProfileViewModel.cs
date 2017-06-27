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

        [Display(Name = "User's login")]
        public string Login { get; set; }

        [Display(Name = "User's email")]
        public string Email { get; set; }

        [Display(Name = "User's role")]
        public string Role { get; set; }

        [Display(Name = "User's Name")]
        public string Name { get; set; }

        public int RoleId { get; set; }

        public IEnumerable<ResultViewModel> Result { get; set; }
    }
}