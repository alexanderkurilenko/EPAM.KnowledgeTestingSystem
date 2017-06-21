using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class TestEditorViewModel
    {
        public IEnumerable<TestViewModel> Tests { get; set; }
        public PageInfoViewModel PageInfo { get; set; }

        [Display(Name = "Show is not valid tests:")]
        public bool ShowNotValid { get; set; }
    }
}