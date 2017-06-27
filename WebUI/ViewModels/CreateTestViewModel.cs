using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class CreateTestViewModel
    {
        [Display(Name = "Test name")]
        [StringLength(50)]
        [Required(ErrorMessage = "The field can not be empty!")]
        public string Name { get; set; }

        [Display(Name = "Time to pass test")]
        [Range(1, 60)]
        [Required(ErrorMessage = "The field can not be empty!")]
        public int Time { get; set; }

        [StringLength(200)]
        [Display(Name = "Desctiption of test")]
        [Required(ErrorMessage = "The field can not be empty!")]
        public string Description { get; set; }

        public string Creator { get; set; }

        [Display(Name = "Minimal procent to pass test")]
        [Required(ErrorMessage = "The field can not be empty!")]
        [Range(1, 60)]
        public int MinProcentToPassTest { get; set; }

        public List<QuestionViewModel> Questions { get; set; }
    }
}