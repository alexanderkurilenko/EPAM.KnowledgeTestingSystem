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
    public class TestController : Controller
    {
        //
        // GET: /Test/

        private readonly ITestService _testService;
        private readonly IResultService _resultService;
        private readonly IUserService _userService;

        public TestController(ITestService testService, IResultService resultService, IUserService userService)
        {
            this._testService = testService;
            this._resultService = resultService;
            this._userService = userService;
        }


        public ActionResult Index(int page = 1)
        {

            var tests = _testService.GetAllTestEntities().Select(t => t.ToMvc());
            int pageSize = 3;
            IEnumerable<TestViewModel> testPerPages = tests.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = tests.Count() };
            IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Tests = testPerPages };

            return View(ivm);
        }


        [HttpGet]
        public ActionResult StartTest(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var test = _testService.GetTestById((int)id).ToMvc();
                if (test == null)
                {
                    return HttpNotFound();
                }
                test.StartTime = DateTime.Now;
                return View(test);
            }
            else
                return RedirectToAction("Login", "Account");
        }


        [HttpPost]
        public ActionResult StartTest(TestViewModel testModel)
        {
            var test = testModel.ToBll();
            test.MinProcentToPassTest = _testService.GetTestById(testModel.Id).MinProcentToPassTest;
            var result = _resultService.CheckTest(test);
            result.PassingTime = DateTime.Now - testModel.StartTime;
            var currentUser = _userService.GetUserByLogin(User.Identity.Name);
            result.UserId = currentUser.Id;
            result.Name = _testService.GetTestById(testModel.Id).Name;
            _resultService.CreateTestResult(result);

            var model = result.ToMvc();
            model.CountOfQuestion = _testService.GetTestById(testModel.Id).Questions.Count;
            return RedirectToAction("TestComplete", model);
        }

        public ActionResult TestComplete(ResultViewModel resultModel)
        {
            return View(resultModel);
        }

        [HttpPost]
        public ActionResult TestSearch(string name)
        {
            var tests = _testService.GetTestByName(name).Select(t => t.ToMvc());
            if (tests.Count() <= 0)
            {
                return HttpNotFound();
            }
            return PartialView(tests);
        }


        public ActionResult AutocompleteSearch(string term)
        {
            var tests = _testService.GetAllTestEntities().Select(t => t.ToMvc());
            var models = tests.Where(a => a.Name.Contains(term))
                            .Select(a => new { value = a.Name })
                            .Distinct();

            return Json(models, JsonRequestBehavior.AllowGet);
        }



        #region CRUD TEST

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult CreateTest()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult CreateTest(CreateTestViewModel test)
        {
            test.Creator = User.Identity.Name;
            _testService.CreateTest(test.ToBll());
            if (Request.IsAjaxRequest())
            {
                return Json(new { message = "Test successfully created" }, JsonRequestBehavior.AllowGet);
            }
            return View();           
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var test = _testService.GetTestById(id).ToMvc();
            if (test == null)
            {
                return HttpNotFound();
            }
            return View(test);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var test = _testService.GetTestById(id);
            if (test == null)
            {
                return HttpNotFound();
            }
            _testService.DeleteTest(test);
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult EditTest(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            var test = _testService.GetTestById((int)id).ToMvc();

            return View(test);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult EditTest(TestViewModel test)
        {
            if (ModelState.IsValid)
            {
                _testService.UpdateTest(test.ToBll());
                return RedirectToAction("Index");
            }
            return View(test);

        }
        #endregion
    }
}