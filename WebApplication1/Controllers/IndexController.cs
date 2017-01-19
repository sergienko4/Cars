using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using BL;
using WebApplication1.Models;
using Dal.Model;
using Microsoft.Owin;
using FormCollection = System.Web.Mvc.FormCollection;

namespace WebApplication1.Controllers
{
   
    public class IndexController : Controller
    {
        private BL.Manager _manager = new Manager();
        // GET: Index
        public ActionResult Index()
        {
            var list = new Helper.Convertor().GetListOfCarModels(_manager.GetCars());
            return View(list);
        }

        [HttpPost]
        [Authorize]
        public ActionResult ToRentCar(string CarNumber)
        {
            //_manager.RentCar(CarNumber);
            return View();

        }
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(SearchCar SearchCar)
        {
            var car = new Helper.Convertor().GetCarTypeFromSerachModel(SearchCar);
            var result = _manager.SearchCar(car);
            var cars = new Helper.Convertor().GetListOfCarModels(result);
            return View("Index", cars);
        }

    
        public ActionResult Details(string id)
        {

            //IOwinContext ctx = Request.GetOwinContext();
            //ClaimsPrincipal user = ctx.Authentication.User;
            //var _id  = user.Identity.Name;
            //ViewBag.UserName = user.Identity.Name;

            // TODO: Check user lpgined
            if (!string.IsNullOrWhiteSpace(id))
            {
                Car result = _manager.GetCarByCarNum(id);
                CarModel tempCar = new Helper.Convertor().GetCarModel(result);

                //TODO: Send user id 
                var order = new Helper.Convertor().GetOrderModelFromCarModel(tempCar);
                return View(order);
            }
            else
                return RedirectToAction("Index");
        }
        [HttpPost]
        [Authorize]
        public ActionResult Details(OrderModel order)
        {
            var t = (ClaimsIdentity)User.Identity;
            order.UserID = Convert.ToInt16(t.Claims.ToList()[1].Value);
            var NewOrder = new Helper.Convertor().getOrderFromOrderModel(order);
            _manager.MakeOrder(NewOrder);
            return RedirectToAction("Index");
        }
        
    }
}
