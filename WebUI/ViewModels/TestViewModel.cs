using BLL.DTO;
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

        [Display(Name = "Test name")]
        [StringLength(40, ErrorMessage = "The name must contain at least {2} characters", MinimumLength = 6)]
        public string Title { get; set; }

        [Display(Name = "Test time")]
        [Range(1, 60, ErrorMessage = "Invalid field of Time! Enter range from 5 to 40 minutes.")]
        public TimeSpan Time { get; set; }

        [Display(Name = "Discription")]
        public string Topic{ get; set; }

  
        [Display(Name = "Test is valid")]
        public bool IsValid { get; set; }

        public IList<QuestionDTO> Questions { get; set; }
        public IList<TestResultDTO> Result { get; set; }

        public TestViewModel()
        {
            Questions = new List<QuestionDTO>();
            Result = new List<TestResultDTO>();
        }

    }
}