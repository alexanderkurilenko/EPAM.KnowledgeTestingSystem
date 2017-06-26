using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using WebUI.Infrastructure.Providers;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService userService;

        public AccountController(IUserService service)
        {
            userService = service;
        }


        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            var type = HttpContext.User.GetType();
            var iden = HttpContext.User.Identity.GetType();
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LogOnViewModel viewModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(viewModel.Login, viewModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Login, viewModel.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Test");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect login or password.");
                }
            }
            return View(viewModel);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var anyUser = userService.GetAllUserEntities().Any(u => u.Email.Contains(viewModel.Email));

                if (anyUser)
                {
                    ModelState.AddModelError("", "User with this address already registered.");
                    return View(viewModel);
                }

                if (ModelState.IsValid)
                {
                    CustomMembershipProvider pr = new CustomMembershipProvider();
                    var membershipUser = pr.CreateUser(viewModel.Login,
                        Crypto.HashPassword(viewModel.Password), viewModel.Email, viewModel.Name);


                    if (membershipUser != null)
                    {
                        FormsAuthentication.SetAuthCookie(viewModel.Login, false);
                        return RedirectToAction("Index", "Test");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error registration.");
                    }
                }
            }
            return View(viewModel);
        }

        [ChildActionOnly]
        public ActionResult LoginPartial()
        {
            return PartialView("_LoginPartial");
        }
    }
}