using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class UserEditorViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }
        public PageInfoViewModel PageInfo { get; set; }
    }
}