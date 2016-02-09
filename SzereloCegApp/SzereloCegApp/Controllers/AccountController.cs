using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SzereloCegApp.Models;
using WebMatrix.WebData;

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
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                if(WebSecurity.Login(login.Username,login.Password))
                {                    
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    ModelState.AddModelError("", "Hibás belépési adatok");
                    return View(login);
                }                
            }            
            return View(login);
        }
        [Authorize(Roles ="Admin")]
        [HttpGet]
        public ActionResult Register()
        {
            RolesDropDown();
            return View();
        }        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register register,string roles)
        {
            RolesDropDown();
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(register.Username, register.Password);
                    Roles.AddUserToRole(register.Username, roles);
                    return RedirectToAction("Index", "Home");
                }       
                catch
                {
                    ModelState.AddModelError("", "A felhasználó már létezik");
                    return View(register);
                }  
            }            
            return View(register);
        }
        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index", "Home");
        }


        #region dropdowns
        private void RolesDropDown(object selectedRoles = null)
        {            
            var Query = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "Admin",
                    Value = "Admin"
                },
                new SelectListItem()
                {
                    Text = "Normál",
                    Value = "Normál"
                },
                new SelectListItem()
                {
                    Text = "Alacsony",
                    Value = "Alacsony"
                }
            };
            ViewBag.roles = new SelectList(Query, "Text", "Value", selectedRoles);
        }
        #endregion
    }
}