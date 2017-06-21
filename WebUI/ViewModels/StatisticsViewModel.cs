using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class StatisticsViewModel
    {
        public IEnumerable<Statistics> StatisticsOfTests { get; set; }
        public PageInfoViewModel PageInfo { get; set; }
    }
}