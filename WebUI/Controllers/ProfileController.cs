using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Infrastructure.Mapper;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserService _userService;
        private readonly IResultService _resulttService;
        private readonly IRoleService _roleService;
        private readonly ITestService _testService;

        public ProfileController(IUserService userService, ITestService testService, IResultService resultService, IRoleService roleService)
        {
            this._userService = userService;
            this._resulttService = resultService;
            this._roleService = roleService;
            this._testService = testService;
        }

        public ActionResult Index()
        {
            var user = _userService.GetUserByLogin(User.Identity.Name).ToMvc();
            user.Role = _roleService.GetRoleEntity(user.RoleId).Name;
            user.Result = _resulttService.GetAllResults().Where(u => u.UserId == user.Id).Select(t => t.ToMvc());
            return View("Profile", user);
        }

        public ActionResult Statistic(int id)
        {
            var result = _resulttService.GetResultById(id).ToMvc();
            int testId = _resulttService.GetResultById(id).TestId;
            result.CountOfQuestion = _testService.GetTestById(testId).Questions.Count();
            return View(result);
        }


        [HttpGet]
        public ActionResult Setting()
        {

            var user = _userService.GetUserByLogin(User.Identity.Name).ToMvcEditProfile();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Setting(EditProfileViewModel profile)
        {
            if (ModelState.IsValid)
            {
                var user = profile.ToBll();
                user.RoleId = _userService.GetUserEntity(profile.Id).RoleId;
                _userService.UpdateUser(user);
            }
            return View(profile);
        }

    }
}