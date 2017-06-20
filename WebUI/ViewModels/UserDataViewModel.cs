using BLL.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class UserDataViewModel
    {
       public UserViewModel User { get; set; }
       public ProfileViewModel Profile { get; set; }
    }
}