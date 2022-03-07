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
    public class ContactTests
    {
        private IContactRepository _repo;

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
                    _repo = new ContactRepositoryPROD();
                    break;
                case "QA":
                    _repo = new ContactRepositoryQA();
                    break;
                default:
                    throw new Exception("Invalid mode key in App.config file");
            }
        }

        [Test]
        public void CanAddGetByIdContact()
        {
            var contact = new Contact()
            {
                ContactId = 2,
                Name = "John Doe",
                Email = "johndoe@example.com",
                Phone = "5551234567",
                Message = "Test message."
            };

            _repo.Insert(contact);

            var found = _repo.GetById(2);

            Assert.AreEqual("John Doe", found.Name);
        }
    }
}
