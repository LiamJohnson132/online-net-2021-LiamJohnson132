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
    public class MakeTests
    {
        private IMakeRepository _repo;
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
                    _repo = new MakeRepositoryPROD();
                    break;
                case "QA":
                    _repo = new MakeRepositoryQA();
                    break;
                default:
                    throw new Exception("Invalid mode key in App.config file");
            }
        }

        [Test]
        public void CanLoadMakes()
        {
            var found = _repo.GetAll();

            Assert.AreEqual(3, found.Count());
        }

        [Test]
        public void CanInsertMake()
        {
            var make = new Make()
            {
                Name = "Dodge",
                UserEmail = "test@example.com"
            };

            _repo.Insert(make);

            var found = _repo.GetAll();

            Assert.AreEqual("Dodge", found[3].Name);
        }
    }
}
