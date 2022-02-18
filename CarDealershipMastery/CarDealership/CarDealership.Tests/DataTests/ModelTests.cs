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
    public class ModelTests
    {
        private IModelRepository _repo;
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
                    _repo = new ModelRepositoryPROD();
                    break;
                case "QA":
                    _repo = new ModelRepositoryQA();
                    break;
                default:
                    throw new Exception("Invalid mode key in App.config file");
            }
        }

        [Test]
        public void CanGetAllModels()
        {
            var repo = new ModelRepositoryPROD();

            var found = repo.GetAll();

            Assert.AreEqual(3, found.Count());
        }

        [Test]
        public void CanGetModelsByMake()
        {
            var found = _repo.GetByMake(0);

            Assert.AreEqual(1, found.Count());
        }

        [Test]
        public void CanInsertModel()
        {
            var model = new Model()
            {
                Name = "Pacifica",
                UserEmail = "test@example.com",
                MakeId = 2
            };

            _repo.Insert(model);

            var found = _repo.GetByMake(2);

            Assert.AreEqual(2, found.Count());
            Assert.AreEqual("Pacifica", found[1].Name);
        }
    }
}
