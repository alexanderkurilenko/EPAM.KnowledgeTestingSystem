﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class Statistics
    {
        [Display(Name = "Test name")]
        public string Name { get; set; }

        [Display(Name = "Good answers")]
        public int GoodAnswers { get; set; }

        [Display(Name = "Bad answers")]
        public int BadAnswers { get; set; }
        [Display(Name = "Answers")]
        public int Answers { get; set; }

        [Display(Name = "Percentage of correct")]
        public string Percentage { get; set; }
        [Display(Name = "Creator")]
        public string Creator { get; set; }
    }
}