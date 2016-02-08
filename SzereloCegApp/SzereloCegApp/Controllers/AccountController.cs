using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SzereloCegApp.Models;

namespace SzereloCegApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login login)
        {
            return Content(login.Username+ ' ' + login.Password);
        }
        public ActionResult Register()
        {
            return View();
        }
    }
}