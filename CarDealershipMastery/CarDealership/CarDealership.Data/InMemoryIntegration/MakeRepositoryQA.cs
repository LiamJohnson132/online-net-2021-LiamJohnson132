using CarDealership.Models.Interfaces;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.InMemoryIntegration
{
    public class MakeRepositoryQA : IMakeRepository
    {
        private List<Make> _makes = new List<Make>()
        {
            new Make()
            {
                MakeId = 0,
                Name = "Acura",
                DateAdded = new DateTime(2022, 1, 19),
                UserEmail = "test@example.com"
            },
            new Make()
            {
                MakeId = 1,
                Name = "Buick",
                DateAdded = new DateTime(2022, 1, 19),
                UserEmail = "test@example.com"
            },
            new Make()
            {
                MakeId = 2,
                Name = "Chrystler",
                DateAdded = new DateTime(2022, 1, 19),
                UserEmail = "test@example.com"
            },
        };
        public List<Make> GetAll()
        {
            return _makes;
        }

        public void Insert(Make make)
        {
            _makes.Add(make);
        }
    }
}
