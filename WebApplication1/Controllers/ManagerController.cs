using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using Dal.Model;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class ManagerController : Controller
    {
        private readonly Manager _manager = new Manager();
        public ActionResult Index()
        {
            return View(_manager.GetAllUsers());
        }

     
        public ActionResult Edit(int UserID)
        {
            var user = _manager.GetUserByID(UserID);
            var userTypes = _manager.GetUserTypes();
            //var model = new MyViewModel();
            ViewBag.ItemsSelect = new SelectList(userTypes, "UserTypeID", "Name", user.UserTypeID);
            //Other initialization code
            return View(_manager.GetUserByID(UserID));
        }
        [HttpPost]
        public ActionResult Edit(User user, int UserTypeID)
        {
            _manager.UpdateUser(user, UserTypeID);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _manager.DeleteUserByID(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return RedirectToAction("Registration","LogIn");
        }
    }
}