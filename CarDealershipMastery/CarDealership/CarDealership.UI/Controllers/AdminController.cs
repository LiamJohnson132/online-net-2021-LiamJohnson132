using CarDealership.Data.Factories;
using CarDealership.Models.Queries;
using CarDealership.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CarDealership.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        // GET: Admin
        public ActionResult Vehicles()
        {
            var model = new InventoryViewModel();

            model.Parameters = new SearchParameters();
            model.Cars = CarRepositoryFactory.GetRepository().SearchAll(model.Parameters);

            return View(model);
        }

        [HttpPost]
        public ActionResult Vehicles(InventoryViewModel model)
        {
            if (int.TryParse(model.Parameters.Parameter, out int yearParam))
            {
                model.Parameters.YearParameter = yearParam;
            }
            if (string.IsNullOrEmpty(model.Parameters.Parameter))
            {
                model.Parameters.Parameter = "";
            }

            model.Cars = CarRepositoryFactory.GetRepository().SearchAll(model.Parameters);

            return View(model);
        }

        public ActionResult AddVehicle()
        {
            var model = new VehicleAddViewModel();

            model.Makes = MakeRepositoryFactory.GetRepository().GetAll();
            model.Types = TypeRepositoryFactory.GetRepository().GetAll();
            model.BodyStyles = BodyStyleRepositoryFactory.GetRepository().GetAll();
            model.Transmissions = TransmissionRepositoryFactory.GetRepository().GetAll();
            model.Colors = ColorRepositoryFactory.GetRepository().GetAll();
            model.Interiors = InteriorRepositoryFactory.GetRepository().GetAll();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddVehicle(VehicleAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = CarRepositoryFactory.GetRepository();

                model.Car.VIN = model.Car.VIN.ToUpper();

                try
                {
                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savePath = Server.MapPath("~/Images");

                        string fileName = "inventory-";
                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        var filePath = Path.Combine(savePath, fileName + repo.GetNextCarId().ToString() + extension);

                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }

                        model.ImageUpload.SaveAs(filePath);

                        model.Car.ImgFileName = Path.GetFileName(filePath);
                    }

                    repo.Insert(model.Car);

                    return RedirectToAction("EditVehicle", new { id = model.Car.CarId });
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            model.Makes = MakeRepositoryFactory.GetRepository().GetAll();
            model.Types = TypeRepositoryFactory.GetRepository().GetAll();
            model.BodyStyles = BodyStyleRepositoryFactory.GetRepository().GetAll();
            model.Transmissions = TransmissionRepositoryFactory.GetRepository().GetAll();
            model.Colors = ColorRepositoryFactory.GetRepository().GetAll();
            model.Interiors = InteriorRepositoryFactory.GetRepository().GetAll();

            return View(model);
        }

        public ActionResult EditVehicle(int id)
        {
            var model = new VehicleEditViewModel();

            model.Car = CarRepositoryFactory.GetRepository().GetById(id);
            model.MakeId = model.Car.MakeId;
            model.Makes = MakeRepositoryFactory.GetRepository().GetAll();
            model.Types = TypeRepositoryFactory.GetRepository().GetAll();
            model.BodyStyles = BodyStyleRepositoryFactory.GetRepository().GetAll();
            model.Transmissions = TransmissionRepositoryFactory.GetRepository().GetAll();
            model.Colors = ColorRepositoryFactory.GetRepository().GetAll();
            model.Interiors = InteriorRepositoryFactory.GetRepository().GetAll();

            return View(model);
        }

        [HttpPost]

        public ActionResult EditVehicle(VehicleEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var repo = CarRepositoryFactory.GetRepository();

                try
                {
                    var oldCar = repo.GetById(model.Car.CarId);
                    model.Car.IsSold = false;

                    if (model.ImageUpload != null && model.ImageUpload.ContentLength > 0)
                    {
                        var savePath = Server.MapPath("~/Images");

                        string fileName = "inventory-" + model.Car.CarId.ToString();
                        string extension = Path.GetExtension(model.ImageUpload.FileName);

                        var filePath = Path.Combine(savePath, fileName + extension);
                        
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }
                        model.ImageUpload.SaveAs(filePath);

                        model.Car.ImgFileName = Path.GetFileName(filePath);
                    } else
                    {
                        model.Car.ImgFileName = oldCar.ImgFileName;
                    }

                    repo.Update(model.Car);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            model.Makes = MakeRepositoryFactory.GetRepository().GetAll();
            model.Types = TypeRepositoryFactory.GetRepository().GetAll();
            model.BodyStyles = BodyStyleRepositoryFactory.GetRepository().GetAll();
            model.Transmissions = TransmissionRepositoryFactory.GetRepository().GetAll();
            model.Colors = ColorRepositoryFactory.GetRepository().GetAll();
            model.Interiors = InteriorRepositoryFactory.GetRepository().GetAll();

            return View(model);
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ActionResult Users()
        {
            var model = UserRepositoryFactory.GetRepository().GetUsers();

            return View(model);
        }

        public ActionResult AddUser()
        {
            var model = new UserAddViewModel();

            model.Roles = UserRepositoryFactory.GetRepository().GetRoles();

            return View(model);
        }

        [HttpPost]
        public ActionResult AddUser(UserAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userToAdd = new ApplicationUser()
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = model.UserModel.Email,
                    Email = model.UserModel.Email,
                    FirstName = model.UserModel.FirstName,
                    LastName = model.UserModel.LastName
                };

                var result = UserManager.Create(userToAdd, model.UserModel.Password);

                if (result.Succeeded)
                {
                    result = UserManager.AddToRole(userToAdd.Id, model.UserModel.Role);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Users");
                    }
                }
            }

            model.Roles = UserRepositoryFactory.GetRepository().GetRoles();

            return View(model);
        }

        public ActionResult EditUser(string id)
        {
            if (id == null)
            {
                return RedirectToAction("Users");
            }
            
            var model = new UserEditViewModel();
            model.UserModel = new UserModel();
            model.Roles = UserRepositoryFactory.GetRepository().GetRoles();

            model.User = UserManager.FindById(id);

            model.UserModel.UserId = model.User.Id;
            model.UserModel.FirstName = model.User.FirstName;
            model.UserModel.LastName = model.User.LastName;
            model.UserModel.Email = model.User.Email;

            model.CurrentRole = UserManager.GetRoles(model.UserModel.UserId).FirstOrDefault();
            model.UserModel.Role = model.CurrentRole;

            return View(model);
        }

        [HttpPost]
        public ActionResult EditUser(UserEditViewModel model)
        {
            var updatedUser = UserManager.FindByIdAsync(model.UserModel.UserId).Result;
            updatedUser.UserName = model.UserModel.Email;
            updatedUser.Email = model.UserModel.Email;
            updatedUser.FirstName = model.UserModel.FirstName;
            updatedUser.LastName = model.UserModel.LastName;
            updatedUser.Id = model.UserModel.UserId;

            model.Roles = UserRepositoryFactory.GetRepository().GetRoles();
            model.CurrentRole = UserManager.GetRoles(model.UserModel.UserId).FirstOrDefault();

            if (ModelState.IsValid)
            {
                var result = UserManager.Update(updatedUser);

                if (!string.IsNullOrEmpty(model.UserModel.Password))
                {
                    UserManager.RemovePassword(model.User.Id);
                    UserManager.AddPassword(model.User.Id, model.UserModel.Password);
                }

                if (model.UserModel.Role != model.CurrentRole)
                {
                    UserManager.RemoveFromRole(updatedUser.Id, model.CurrentRole);
                    UserManager.AddToRole(updatedUser.Id, model.UserModel.Role);
                }

                return RedirectToAction("Users");
            }

            model.UserModel.Role = model.CurrentRole;

            return View(model);
        }

        public ActionResult Makes()
        {
            var model = new MakesViewModel();

            model.Makes = MakeRepositoryFactory.GetRepository().GetAll();

            return View(model);
        }

        [HttpPost]
        public ActionResult Makes(MakesViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.NewMake.UserEmail = User.Identity.Name;
                MakeRepositoryFactory.GetRepository().Insert(model.NewMake);
            }
            model.Makes = MakeRepositoryFactory.GetRepository().GetAll();
            return View(model);
        }

        public ActionResult Models()
        {
            var model = new ModelsViewModel();

            model.Makes = MakeRepositoryFactory.GetRepository().GetAll();
            model.Models = ModelRepositoryFactory.GetRepository().GetAll();

            return View(model);
        }

        [HttpPost]
        public ActionResult Models(ModelsViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.NewModel.UserEmail = User.Identity.Name;
                ModelRepositoryFactory.GetRepository().Insert(model.NewModel);
            }
            model.Makes = MakeRepositoryFactory.GetRepository().GetAll();
            model.Models = ModelRepositoryFactory.GetRepository().GetAll();
            return View(model);
        }

        public ActionResult Specials()
        {
            var model = new SpecialsViewModel();

            model.Specials = SpecialRepositoryFactory.GetRepository().GetAll();

            return View(model);
        }

        [HttpPost]
        public ActionResult Specials(SpecialsViewModel model)
        {
            var repo = SpecialRepositoryFactory.GetRepository();

            if (ModelState.IsValid)
            {
                repo.Insert(model.NewSpecial);
            }

            model.Specials = repo.GetAll();
            
            return RedirectToAction("Specials");
        }
    }
}