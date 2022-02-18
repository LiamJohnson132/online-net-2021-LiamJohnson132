using CarDealership.Data.Factories;
using CarDealership.Models.Queries;
using CarDealership.Models.Tables;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    [Authorize(Roles = "Admin, Sales")]
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult Index()
        {
            var model = new InventoryViewModel();

            return View(model);
        }

        public ActionResult Purchase(int id)
        {
            var model = new PurchaseViewModel();

            model.Car = CarRepositoryFactory.GetRepository().GetDetails(id);
            model.PurchaseTypes = PurchaseTypeRepositoryFactory.GetRepository().GetAll();
            model.States = StateRepositoryFactory.GetRepository().GetAll();
            model.Order = new Order()
            {
                CarId = id,
                UserEmail = User.Identity.Name
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Purchase(PurchaseViewModel model)
        {
            var carRepo = CarRepositoryFactory.GetRepository();

            model.Car = carRepo.GetDetails(model.Order.CarId);
            // validate
            if (ModelState.IsValid)
            {
                // edit car IsSold to true
                model.Car.IsSold = true;
                carRepo.Update(model.Car);

                // add Order to DB
                model.Order.Phone = model.Order.Phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(".", "").Replace(" ", "");
                OrderRepositoryFactory.GetRepository().Insert(model.Order);

                return RedirectToAction("Index", "Sales");
            }

            model.PurchaseTypes = PurchaseTypeRepositoryFactory.GetRepository().GetAll();
            model.States = StateRepositoryFactory.GetRepository().GetAll();

            return View(model);
        }
    }
}