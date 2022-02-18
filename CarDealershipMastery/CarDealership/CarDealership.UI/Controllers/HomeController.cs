using CarDealership.Data.Factories;
using CarDealership.Models.Tables;
using CarDealership.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership.UI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new HomeViewModel();

            model.Featured = CarRepositoryFactory.GetRepository().GetFeatured();
            model.Specials = SpecialRepositoryFactory.GetRepository().GetAll();

            return View(model);
        }

        public ActionResult Contact(string vin = "")
        {
            var model = new ContactAddViewModel()
            {
                VIN = vin
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Contact(ContactAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = ContactRepositoryFactory.GetRepository();

                model.Contact.Phone = model.Contact.Phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(".", "").Replace(" ", "");

                try
                {
                    repo.Insert(model.Contact);

                    return RedirectToAction("Index");
                } 
                catch (Exception e)
                {
                    throw e;
                }
            }

            return View(model);
        }

        public ActionResult Specials()
        {
            var repo = SpecialRepositoryFactory.GetRepository();

            return View(repo.GetAll());
        }
    }
}