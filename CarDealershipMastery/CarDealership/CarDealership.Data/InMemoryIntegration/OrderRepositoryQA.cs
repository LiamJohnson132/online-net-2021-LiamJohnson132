using CarDealership.Models.Interfaces;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.InMemoryIntegration
{
    public class OrderRepositoryQA : IOrderRepository
    {
        private List<Order> _orders = new List<Order>()
        {
            new Order()
            {
                OrderId = 0,
                Name = "Jane Doe",
                Email = "janedoe@example.com",
                Phone = "5551234567",
                StreetOne = "123 Main Street",
                City = "Minneapolis",
                Zipcode = "55401",
                PurchasePrice = 19500,
                UserEmail = "test@example.com",
                PurchaseTypeId = 1,
                StateId = "MN",
                DateAdded = new DateTime(2022, 1, 19)
            }
        };

        public Order GetById(int id)
        {
            return _orders.Where(m => m.OrderId == id).FirstOrDefault();
        }

        public void Insert(Order order)
        {
            _orders.Add(order);
        }
    }
}
