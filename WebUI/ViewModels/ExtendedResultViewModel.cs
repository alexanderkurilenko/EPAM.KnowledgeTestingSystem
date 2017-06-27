using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class ExtendedResultViewModel
    {
        [Display(Name = "Total average time to pass tests")]
        public TimeSpan AverageTime { get; set; }
        [Display(Name = "Total average procents of passing tests")]
        public double AverageProcent { get; set; }
    }
}