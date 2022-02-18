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
    public class SpecialTests
    {
        private ISpecialRepository _repo;
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
                    _repo = new SpecialRepositoryPROD();
                    break;
                case "QA":
                    _repo = new SpecialRepositoryQA();
                    break;
                default:
                    throw new Exception("Invalid mode key in App.config file");
            }
        }

        [Test]
        public void CanInsertGetAllSpecials()
        {
            var special = new Special()
            {
                Title = "Test Special",
                Description = "This special is for testing."
            };

            _repo.Insert(special);

            var found = _repo.GetAll();

            Assert.AreEqual("Test Special", found[1].Title);
            Assert.AreEqual(2, found.Count());
        }

        [Test]
        public void CanDeleteGetAllSpecial()
        {
            _repo.Delete(0);

            var found = _repo.GetAll();

            Assert.AreEqual(0, found.Count());
        }
    }
}
