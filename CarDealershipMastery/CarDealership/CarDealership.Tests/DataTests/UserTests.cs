using CarDealership.Data.DatabaseIntegration;
using CarDealership.Data.InMemoryIntegration;
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
    public class UserTests
    {
        private IUserRepository _repo;
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
            _repo = new UserRepositoryPROD();
        }

        [Test]
        public void CanGetUsers()
        {
            var found = _repo.GetUsers();

            Assert.AreEqual(7, found.Count());
        }

        [Test]
        public void CanGetSalesReports()
        {
            var param = new SalesReportParameters();

            var found = _repo.GetSalesReports(param);

            Assert.AreEqual(29000, found[0].TotalSales);
        }

        [Test]
        public void CanGetInventoryReport()
        {
            var found = _repo.GetNewInventoryReports();

            Assert.AreEqual(1, found.Count());
            Assert.AreEqual(42500M, found[0].StockValue);

            found = _repo.GetUsedInventoryReports();

            Assert.AreEqual(1, found.Count());
            Assert.AreEqual(4, found[0].Count);
        }
    }
}
