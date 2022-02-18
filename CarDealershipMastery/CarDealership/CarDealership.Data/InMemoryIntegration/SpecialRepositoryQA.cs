using CarDealership.Models.Interfaces;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.InMemoryIntegration
{
    public class SpecialRepositoryQA : ISpecialRepository
    {
        private List<Special> _specials = new List<Special>()
        {
            new Special()
            {
                SpecialId = 0,
                Title = "Example Special",
                Description = "Lorem ipsum dolor sit amet, et cetera"
            }
        };
        public void Delete(int specialId)
        {
            _specials.Remove(_specials.Where(s => s.SpecialId == specialId).FirstOrDefault());
        }

        public List<Special> GetAll()
        {
            return _specials;
        }

        public void Insert(Special special)
        {
            _specials.Add(special);
        }
    }
}
