using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BL;
using WebApplication1.Models;

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
        public ActionResult ToRentCar(int CarNumber)
        {
            var car = new Helper.Convertor().GetCarModel(_manager.GetCarByCarID(CarNumber));
            return View(car);

        }
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(SearchCar SearchCar)
        {
            var car = new Helper.Convertor().GetCarTypeFromSerachModel(SearchCar);
            var result = _manager.SearchCar(car, SearchCar.Start, SearchCar.Finish);
            return View();
        }
        //[HttpPost]
        //public ActionResult Search(string IsManual, string Year, string Brand)
        //{
        //    return View();
        //}

        // GET: Index/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Index/Create
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

        // GET: Index/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Index/Edit/5
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

        // GET: Index/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Index/Delete/5
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
