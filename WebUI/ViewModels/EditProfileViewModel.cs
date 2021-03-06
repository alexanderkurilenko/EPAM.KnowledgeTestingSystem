﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class EditProfileViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public int? SelectedRole { get; set; }

        public IEnumerable<RoleViewModel> Role { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [Display(Name = "User's name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        [Display(Name = "User's login")]
        public string Login { get; set; }

        [Display(Name = "Enter your e-mail")]
        [Required(ErrorMessage = "The field can not be empty!")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Uncorrect email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [StringLength(100, ErrorMessage = "The password must contain at least {2} characters", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Enter your password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm the password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm the password")]
        [Compare("Password", ErrorMessage = "Passwords must match")]
        public string ConfirmPassword { get; set; }

    }
}