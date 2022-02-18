using CarDealership.Models.Interfaces;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.InMemoryIntegration
{
    public class ModelRepositoryQA : IModelRepository
    {
        private List<Model> _models = new List<Model>()
        {
            new Model()
            {
                ModelId = 0,
                MakeId = 0,
                Name = "Integra",
                DateAdded = new DateTime(2022, 1, 19),
                UserEmail = "test@example.com"
            },
            new Model()
            {
                ModelId = 1,
                MakeId = 1,
                Name = "Encore",
                DateAdded = new DateTime(2022, 1, 19),
                UserEmail = "test@example.com"
            },
            new Model()
            {
                ModelId = 2,
                MakeId = 2,
                Name = "300C",
                DateAdded = new DateTime(2022, 1, 19),
                UserEmail = "test@example.com"
            },
        };
        public List<Model> GetAll()
        {
            return _models;
        }

        public List<Model> GetByMake(int makeId)
        {
            return _models.Where(m => m.MakeId == makeId).ToList();
        }

        public void Insert(Model model)
        {
            _models.Add(model);
        }
    }
}
