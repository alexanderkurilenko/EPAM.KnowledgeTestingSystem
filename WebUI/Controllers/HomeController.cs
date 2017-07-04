using BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private 
            IRoleService service;

        public HomeController(IRoleService serv)
        {
            service = serv;
        }
        // GET: Home
        public string Index()
        {
            //service.CreateUser(new BLL.Entities.UserEntity() { Email = "fdlkf@mail.ru", Name = "alex", Login = "lalaa" });
            TimeSpan t = new TimeSpan();
            DateTime d = new DateTime();
            return d.ToString();
        }
    }
}