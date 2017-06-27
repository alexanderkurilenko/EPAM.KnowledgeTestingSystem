using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class ResultViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Test name")]
        public string Name { get; set; }

        [Display(Name = "Count of correct answers")]
        public int CorrectAnswerCount { get; set; }

        public int CountOfQuestion { get; set; }

        public double PassingProcent { get; set; }

        public TimeSpan PassingTime { get; set; }

        [Display(Name = "Is passed the test")]
        public bool IsPassed { get; set; }
    }
}