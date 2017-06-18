﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Services.Implementation;
using BLL.Services;

namespace WebUI.Controllers
{
    public class TestController : Controller
    {
        IUserService srv;
        public TestController(IUserService service)
        {
            srv = service;
        }

        // GET: Test
        public String Index()
        {
            /*using (KnowledgeSystemDbContext db=new KnowledgeSystemDbContext("name = KnowledgeSystemDbContext"))
            {
                UserRepository rep = new UserRepository(db);
                db.Users.Add(new DAL.ORM.User() { Email = "lllll@mail.ru", Login = "vasya" });
                db.SaveChanges();
                 UnitOfWork x = new UnitOfWork("name = KnowledgeSystemDbContext");
            x.Users.Create(new User() { Login = "login", Password = "pass", Email = "alexander@gmail.com" });
            x.Users.Delete(1);
            x.Save(); ;

            UnitOfWork x = new UnitOfWork("name = KnowledgeSystemDbContext");
            UserService s = new UserService(x);
            s.CreateUser(new BLL.DTO.UserDTO() { Email = "123@mail.ru", Login = "logggg", Password = "12345" });
           
            }
            */
            srv.CreateUser(new BLL.DTO.UserDTO() { Email = "123@mail.ru", Login = "logggg", Password = "12345678910" });

            return "hello";
        }
            
        
    }
}