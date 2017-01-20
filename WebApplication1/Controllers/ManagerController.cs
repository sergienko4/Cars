using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;

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
            return View(_manager.GetUserByID(UserID));
        }
    }
}