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
    [Authorize(Roles = "Admin")]
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Sales()
        {
            var model = new SalesReportViewModel();

            model.Users = UserRepositoryFactory.GetRepository().GetUsers();

            return View(model);
        }

        public ActionResult Inventory()
        {
            var model = new InventoryReportViewModel();
            var repo = UserRepositoryFactory.GetRepository();

            model.NewReports = repo.GetNewInventoryReports();
            model.UsedReports = repo.GetUsedInventoryReports();

            return View(model);
        }
    }
}