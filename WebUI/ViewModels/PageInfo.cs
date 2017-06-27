using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class PageInfo
    {/// <summary>
     /// Current Page numbet
     /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// Count of object per page
        /// </summary>
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
    public class IndexViewModel
    {
        public IEnumerable<TestViewModel> Tests { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}