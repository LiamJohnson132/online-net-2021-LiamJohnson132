using CarDealership.Models.Interfaces;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.InMemoryIntegration
{
    public class PurchaseTypeRepositoryQA : IPurchaseTypeRepository
    {
        private List<PurchaseType> _purchaseTypes = new List<PurchaseType>()
        {
            new PurchaseType()
            {
                PurchaseTypeId = 0,
                Name = "Bank Finance"
            },
            new PurchaseType()
            {
                PurchaseTypeId = 1,
                Name = "Cash"
            },
            new PurchaseType()
            {
                PurchaseTypeId = 2,
                Name = "Dealer Finance"
            },
        };
        public List<PurchaseType> GetAll()
        {
            return _purchaseTypes;
        }
    }
}
