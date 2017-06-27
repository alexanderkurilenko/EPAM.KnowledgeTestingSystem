using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebUI.Infrastructure.Mapper;
using WebUI.Infrastructure.Providers;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ITestService _testService;
        private readonly IResultService _resultService;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public AdminController(ITestService testService, IResultService resultService,
            IUserService userService, IRoleService roleService)
        {
            this._testService = testService;
            this._resultService = resultService;
            this._userService = userService;
            this._roleService = roleService;
        }

        // GET: Admin
        public ActionResult Index()
        {
            var user = _userService.GetUserByLogin(User.Identity.Name).ToMvc();
            user.Role = _roleService.GetRoleEntity(user.RoleId).Name;
            user.Result = _resultService.GetAllResults().Select(t => t.ToMvc());
            return View("Profile", user);
        }

        public ActionResult UsersDetails()
        {
            var users = _userService.GetAllUserEntities().Select(t => t.ToMvc());
            return View(users);
        }

        public ActionResult TestsDetails()
        {
            var tests = _testService.GetAllTestEntities().Select(t => t.ToMvc());
            return View(tests);
        }


        public ActionResult ExtendedStatistic()
        {
            var results = _resultService.GetAllResults();
            var stat = new ExtendedResultViewModel();
            stat.AverageProcent = _resultService.FindAverageProcent(results);
            stat.AverageTime = _resultService.FindAverageTime(results);

            return View(stat);
        }

        #region CRUD USER
        [HttpGet]
        public ActionResult EditUser(int id)
        {

            var user = _userService.GetUserEntity(id).ToMvcEditUser();
            user.Role = _roleService.GetAllRoleEntities().Select(r => r.ToMvc());
            return View(user);
        }
        [HttpPost]
        public ActionResult EditUser(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = model.ToBll();
                _userService.UpdateUser(model.ToBll());
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            var user = new EditProfileViewModel();
            user.Role = _roleService.GetAllRoleEntities().Select(r => r.ToMvc());
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(EditProfileViewModel model)
        {
            int rol = (int)model.SelectedRole;
            if (ModelState.IsValid)
            {
                CustomMembershipProvider pr = new CustomMembershipProvider();
                pr.CreateUser(model.Login,
                    Crypto.HashPassword(model.Password), model.Email, model.Name, (int)model.SelectedRole);
                //  _userService.CreateUser(model.ToBll());
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            var user = _userService.GetUserEntity(id).ToMvc();
            user.Role = _roleService.GetRoleEntity(user.RoleId).Name;
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpPost, ActionName("DeleteUser")]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = _userService.GetUserEntity(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            _userService.DeleteUser(user);
            return RedirectToAction("Index");
        }

        #endregion
    }
}