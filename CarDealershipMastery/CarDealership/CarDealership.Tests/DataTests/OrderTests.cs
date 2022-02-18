using CarDealership.Data.DatabaseIntegration;
using CarDealership.Data.InMemoryIntegration;
using CarDealership.Models.Interfaces;
using CarDealership.Models.Tables;
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
    public class OrderTests
    {
        private IOrderRepository _repo;
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
                    _repo = new OrderRepositoryPROD();
                    break;
                case "QA":
                    _repo = new OrderRepositoryQA();
                    break;
                default:
                    throw new Exception("Invalid mode key in App.config file");
            }
        }

        [Test]
        public void CanInsertGetByIdOrder()
        {
            var order = new Order()
            {
                OrderId = 2,
                Name = "John Doe",
                Email = "johndoe@example.com",
                Phone = "5557654321",
                StreetOne = "321 Main Street",
                City = "Minneapolis",
                StateId = "MN",
                Zipcode = "55401",
                PurchasePrice = 14000M,
                CarId = 2,
                PurchaseTypeId = 2,
                UserEmail = "test@example.com",
                DateAdded = new DateTime(2022, 2, 11)
            };

            _repo.Insert(order);

            var found = _repo.GetById(2);

            Assert.AreEqual(order.Name, found.Name);
        }
    }
}
