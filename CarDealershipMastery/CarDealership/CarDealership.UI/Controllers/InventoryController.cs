using CarDealership.Data.Factories;
using CarDealership.Models.Queries;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    [AllowAnonymous]
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult New()
        {
            var model = new InventoryViewModel();
            return View(model);
        }

        public ActionResult Used()
        {
            var model = new InventoryViewModel();

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var car = CarRepositoryFactory.GetRepository().GetDetails(id);

            return View(car);
        }
    }
}