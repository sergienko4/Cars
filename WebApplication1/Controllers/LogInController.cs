using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BL;
using Dal.Model;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LogInController : Controller
    {
        private readonly Manager _manager = new Manager();
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LogIn user)
        {
            if (ModelState.IsValid)
            {
                var _user = _manager.IsValidLogin(user.UserName, user.Password);

                if (_user != null)
                {
                    var context = Request.GetOwinContext();
                    context.Authentication.SignIn(new AuthenticationProperties()
                    {
                        IsPersistent = true,
                    },
                        new ClaimsIdentity(new[]
                            {
                                new Claim(ClaimsIdentity.DefaultNameClaimType, _user.UserName),

                                new Claim(ClaimTypes.Sid, _user.UserID.ToString()),
                            },
                            DefaultAuthenticationTypes.ApplicationCookie));
                    context.Response.Headers.Add("Location", new[] { "/" });


                    string TypeName = _manager.GetUserByID(_user.UserID).UserType.Name;
                    Session["UserType"] = TypeName;

                    //bool isAdmin = HttpContext.User.IsInRole(TypeName);
                    return RedirectToActionPermanent("Index", "Index");
                }
                else
                {
                    ModelState.AddModelError("LogOnError", "The user name or password provided is incorrect.");

                }
            }

            return View();
        }
        public ActionResult Registration()
        {
            if (Session["UserType"] != null)
            {
                if (Session["UserType"].Equals("Manager"))
                {
                    var userTypes = _manager.GetCarTypes();
                    ViewBag.ItemsSelect = new SelectList(userTypes, "UserTypeID", "Name", userTypes[0]);
                }
            }
            List<Char> gender = new List<Char>() { 'M', 'F' };
            ViewBag.Gender = new SelectList(gender, gender[0]);
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Registration registration)
        {
            if (ModelState.IsValid)
            {
                    User newUser = new Helper.Convertor().GetUserFromREgistration(registration);
                    _manager.AddNewUser(newUser);
            }
            return RedirectToAction("LogIn", "LogIn");
        }



    }
}
