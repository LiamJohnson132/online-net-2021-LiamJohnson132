using CarDealership.Data.DatabaseIntegration;
using CarDealership.Data.InMemoryIntegration;
using CarDealership.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Factories
{
    public class OrderRepositoryFactory
    {
        public static IOrderRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "QA":
                    return new OrderRepositoryQA();
                case "PROD":
                    return new OrderRepositoryPROD();
                default:
                    throw new Exception("Could not find valid Mode configuration value");
            }
        }
    }
}
