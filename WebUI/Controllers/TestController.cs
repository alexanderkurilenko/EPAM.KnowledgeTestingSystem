﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Services.Implementation;
using BLL.Services;
using BLL.DTO;
using WebUI.ViewModels;
using WebUI.Infrastructure.Mapper;

namespace WebUI.Controllers
{
    public class TestController : Controller
    {
        private readonly ITestService _testService;
        private readonly ITestResultService _testResultService;
        private readonly IUserService _userService;

        public TestController(ITestService testService, ITestResultService testResultService, IUserService userService)
        {
            _testService = testService;
            _testResultService = testResultService;
            _userService = userService;

        }

        public ActionResult Home(string searchItem, int page = 1)
        {
            List<TestViewModel> tests;
            var model = new HomeViewModel();
            if (ReferenceEquals(searchItem, null))
            {
                tests =
                    _testService.GetAllTests()
                        .Select(u => u.ToMvcTest())
                        .Where(m => m.IsValid)
                        .ToList();
                model.PageInfo = new PageInfoViewModel(page, 5, tests.Count, null);
            }
            else
            {
                tests =
                    _testService.GetAllTests()
                        .Select(u => u.ToMvcTest())
                        .Where(m => m.IsValid && m.Name.Contains(searchItem))
                        .ToList();
                model.PageInfo = new PageInfoViewModel(page, 5, tests.Count, searchItem);
            }
            model.Tests = tests.Skip((page - 1) * 5).Take(5);
            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }
            return View(model);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public ActionResult CreateTest(CreateTestViewModel model)
        {
            if (!ModelState.IsValid) return PartialView("CreateTest");
            var test = model.ToBllTest();
            test.Creator = User.Identity.Name;
            _testService.CreateTest(test);
            return Redirect(Url.Action("Home", "Test"));
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public ActionResult CreateTest() => View();

        public ActionResult AddQuestion() => PartialView("QuestionPartial");

        [HttpGet]
        public ActionResult Passing(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                var model = _testService.GetTest(id).ToMvcPassing();
                model.StartPassingTest = DateTime.Now;
                return View(model);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpPost]
        public ActionResult Passing(PassingViewModel model)
        {
            int checkeTestTime = (DateTime.Now - model.StartPassingTest).Minutes * 60 +
                                 (DateTime.Now - model.StartPassingTest).Seconds - 10;
            if (checkeTestTime > model.Time * 60)
                return Redirect(Url.Action("NotCompleteTest", "Error"));
            var resultModel = _testService.CheckAnswers(model.ToBllTest());
            var entityTest = _testService.GetTest(model.Id);
            entityTest.GoodAnswers += resultModel.GoodAnswers;
            entityTest.BadAnswers += resultModel.BadAnswers;
            _testService.UpdateTest(entityTest);
            resultModel.Name = entityTest.Name;
            resultModel.User = _userService.GetUserByEmail(User.Identity.Name);
            resultModel.DateCompleted = DateTime.Now;
            _testResultService.CreateTestResult(resultModel);
            return RedirectToAction("TestComplete", resultModel.ToMvcTestComplete());
        }

        public ActionResult Statistics(string searchItem, int page = 1)
        {
            var model = new StatisticsViewModel();
            List<Statistics> tests;

            if (ReferenceEquals(searchItem, null))
            {
                tests =
                        _testService.GetAllTests()
                        .Select(u => u.ToMvcStatistics())
                        .Where(a => a.Answers != 0)
                        .ToList();
                model.PageInfo = new PageInfoViewModel(page, 8, tests.Count, null);
            }
            else
            {
                tests =
                        _testService.GetAllTests()
                        .Select(u => u.ToMvcStatistics())
                        .Where(a => a.Name.Contains(searchItem) && a.Answers != 0)
                        .ToList();
                model.PageInfo = new PageInfoViewModel(page, 8, tests.Count, searchItem);
            }
            model.StatisticsOfTests = tests.Skip((page - 1) * 8).Take(8);
            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }
            return View(model);

        }
        public ActionResult TestComplete(TestCompleteViewModel testViewModel) => View(testViewModel);

        public ActionResult About() => View();

    }
}