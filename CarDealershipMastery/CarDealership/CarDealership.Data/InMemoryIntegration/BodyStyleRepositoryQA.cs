using CarDealership.Models;
using CarDealership.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.InMemoryIntegration
{
    public class BodyStyleRepositoryQA : IBodyStyleRepository
    {
        private List<BodyStyle> _bodyStyles = new List<BodyStyle>()
        {
            new BodyStyle()
            {
                BodyStyleId = 0,
                Name = "Sedan"
            },
            new BodyStyle()
            {
                BodyStyleId = 1,
                Name = "Wagon"
            },
            new BodyStyle()
            {
                BodyStyleId = 2,
                Name = "SUV"
            },
            new BodyStyle()
            {
                BodyStyleId = 3,
                Name = "Truck"
            },
            new BodyStyle()
            {
                BodyStyleId = 4,
                Name = "Van"
            },
        };
        public List<BodyStyle> GetAll()
        {
            return _bodyStyles;
        }
    }
}
