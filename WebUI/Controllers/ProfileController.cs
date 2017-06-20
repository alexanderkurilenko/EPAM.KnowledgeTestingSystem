using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.ViewModels;
using WebUI.Infrastructure;

namespace WebUI.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly ITestService _testService;
    

        public ProfileController(IUserService service, ITestService testResult)
        {
            _userService = service;
            _testService = testResult;
         
        }
        // GET: Profile
        public String Information()
        {
            
            return "lalka";
        }
    }
}