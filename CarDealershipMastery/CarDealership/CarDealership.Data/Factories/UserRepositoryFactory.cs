using CarDealership.Data.DatabaseIntegration;
using CarDealership.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Factories
{
    public class UserRepositoryFactory
    {
        public static IUserRepository GetRepository()
        {
            switch (Settings.GetRepositoryType())
            {
                case "QA":
                case "PROD":
                    return new UserRepositoryPROD();
                default:
                    throw new Exception("Could not find valid Mode configuration value");
            }
        }
    }
}
