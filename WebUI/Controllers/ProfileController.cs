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
        private readonly IProfileService _profileService;

        public ProfileController(IUserService service, ITestService testResult,IProfileService profileService)
        {
            _userService = service;
            _testService = testResult;
            _profileService = profileService;
        }
        // GET: Profile
        public ActionResult Information()
        {
            var profile = new ProfileViewModel();
            var user = new UserViewModel();
            var model = new UserDataViewModel();
            user=_userService.GetUserByEmail(User.Identity.Name).ToMvcUser();
            profile = _userService.GetUserByEmail(User.Identity.Name).UserProfile.ToMvcProfile();
            return View(model);
        }
    }
}