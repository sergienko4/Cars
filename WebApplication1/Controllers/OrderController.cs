using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using BL;
using Dal.Model;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly Manager _manager = new Manager();
        private readonly Helper.Convertor _helper = new Helper.Convertor();
        // GET: Order
        public ActionResult Index()
        {
            var Identities = (ClaimsIdentity)User.Identity;
            var id = Convert.ToInt16(Identities.Claims.ToList()[1].Value);
            var user = _manager.GetUserByID(id);
            // if worker
            if (user.UserType.UserTypeID == 1)
            {
                return View("GetCarFromClient");
            }
            // if manager
            else if (user.UserType.UserTypeID == 3)
            {

            }
            // if client
            var orders = _manager.GetClientOrders(user.UserID);
            return View(orders);
        }

        [HttpPost]
        public ActionResult FindCarByNumCar(string carNum)
        {
            Car car = _manager.GetCarByCarNum(carNum);
            return View(car);
        }

        [HttpPost]
        public ActionResult GetCarBack(Car car)
        {
            _manager.GetCarBack(car);
            return View("Index");
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
