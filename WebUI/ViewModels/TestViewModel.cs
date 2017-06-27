using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class TestViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field can not be empty!")]
        public string Description { get; set; }

        public string Creator { get; set; }
        [Required(ErrorMessage = "The field can not be empty!")]
        public int Time { get; set; }

        public DateTime StartTime { get; set; }
        public List<QuestionViewModel> Questions { get; set; }

    }
}