using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Tables
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string StreetOne { get; set; }
        public string StreetTwo { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string ZipcodeExtension { get; set; }
        public decimal PurchasePrice { get; set; }
        public string UserEmail { get; set; }
        public int CarId { get; set; }
        public int PurchaseTypeId { get; set; }
        public string StateId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
