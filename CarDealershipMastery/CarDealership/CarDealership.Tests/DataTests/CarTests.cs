using CarDealership.Data.DatabaseIntegration;
using CarDealership.Data.InMemoryIntegration;
using CarDealership.Models;
using CarDealership.Models.Interfaces;
using CarDealership.Models.Queries;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Tests.DataTests
{
    [TestFixture]
    public class CarTests
    {
        private ICarRepository _repo;
        [SetUp]
        public void Init()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "PROD":
                    using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                    {
                        var cmd = new SqlCommand();
                        cmd.CommandText = "DbReset";
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Connection = cn;
                        cn.Open();

                        cmd.ExecuteNonQuery();
                    }
                    _repo = new CarRepositoryPROD();
                    break;
                case "QA":
                    _repo = new CarRepositoryQA();
                    break;
                default:
                    throw new Exception("Invalid mode key in App.config file");
            }
        }

        [Test]
        public void CanGetCarDetails()
        {
            var car = _repo.GetDetails(0);

            Assert.AreEqual("AAA11111B22222222", car.VIN);
            Assert.AreEqual("inventory-0.png", car.ImgFileName);
            Assert.AreEqual("A simple car for your simpler life", car.Description);
        }

        [Test]
        public void CanInsertGetByIdCar()
        {
            var repo = new CarRepositoryPROD();

            var car = new Car()
            {
                CarId = 6,
                VIN = "00000000000000000",
                ImgFileName = "inventory-6.png",
                Year = 2020,
                Mileage = 20000,
                Price = 20000.95M,
                MSRP = 22500.90M,
                Description = "Test car for testing",
                ModelId = 0,
                InteriorId = 0,
                ColorId = 0,
                TypeId = 0,
                TransmissionId = 0,
                BodyStyleId = 0
            };

            repo.Insert(car);

            var found = repo.GetById(6);

            Assert.AreEqual("inventory-6.png", found.ImgFileName);
            Assert.AreEqual("Test car for testing", found.Description);
            Assert.AreEqual(20000.95M, found.Price);
        }

        [Test]
        public void CanSearchAllCars()
        {
            var param = new SearchParameters();

            var found = _repo.SearchAll(param);

            Assert.AreEqual(4, found.Count());
        }

        [Test]
        public void CanSearchUsedCars()
        {
            var param = new SearchParameters();

            var found = _repo.SearchUsed(param);

            Assert.AreEqual(2, found.Count());
        }

        [Test]
        public void CanSearchNewCars()
        {
            var param = new SearchParameters();
            var found = _repo.SearchNew(param);

            Assert.AreEqual(2, found.Count());
        }

        [Test]
        public void CanDeleteCar()
        {
            _repo.Delete(0);

            var found = _repo.GetById(0);

            Assert.IsNull(found.Description);
        }

        [Test]
        public void CanUpdateCar()
        {
            var updated = new Car()
            {
                CarId = 0,
                VIN = "CCCCCCCCCCCCCCCCC",
                ImgFileName = "inventory-0.png",
                Year = 2020,
                Mileage = 15000,
                Price = 25000M,
                MSRP = 25000M,
                Description = "A simple car for your simple life.",
                IsSold = false,
                IsFeatured = true,
                ModelId = 0,
                InteriorId = 0,
                ColorId = 0,
                TypeId = 0,
                TransmissionId = 0,
                BodyStyleId = 0
            };

            _repo.Update(updated);

            var found = _repo.GetById(0);

            Assert.AreEqual("A simple car for your simple life.", found.Description);
            Assert.AreEqual("CCCCCCCCCCCCCCCCC", found.VIN);
        }

        [Test]
        public void CanGetFeatured()
        {
            var found = _repo.GetFeatured();

            Assert.AreEqual(3, found.Count());
        }
    }
}
