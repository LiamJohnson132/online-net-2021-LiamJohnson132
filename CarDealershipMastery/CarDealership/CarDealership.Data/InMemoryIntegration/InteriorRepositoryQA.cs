using CarDealership.Models.Interfaces;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.InMemoryIntegration
{
    public class InteriorRepositoryQA : IInteriorRepository
    {
        private List<Interior> _interiors = new List<Interior>()
        {
            new Interior()
            {
                InteriorId = 0,
                Name = "Black"
            },
            new Interior()
            {
                InteriorId = 1,
                Name = "White"
            },
            new Interior()
            {
                InteriorId = 2,
                Name = "Beige"
            },
            new Interior()
            {
                InteriorId = 3,
                Name = "Gray"
            },
        };
        public List<Interior> GetAll()
        {
            return _interiors;
        }
    }
}
