using CarDealership.Models.Interfaces;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.InMemoryIntegration
{
    public class TypeRepositoryQA : ITypeRepository
    {
        private List<VehicleType> _types = new List<VehicleType>()
        {
            new VehicleType()
            {
                TypeId = 0,
                Name = "New"
            },
            new VehicleType()
            {
                TypeId = 1,
                Name = "Used"
            }
        };
        public List<VehicleType> GetAll()
        {
            return _types;
        }
    }
}
