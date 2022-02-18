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
    public class ModelRepositoryFactory
    {
        public static IModelRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "QA":
                    return new ModelRepositoryQA();
                case "PROD":
                    return new ModelRepositoryPROD();
                default:
                    throw new Exception("Could not find valid Mode configuration value");
            }
        }
    }
}
