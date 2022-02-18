using CarDealership.Models;
using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class InventoryViewModel
    {
        public List<Car> Cars { get; set; }
        public SearchParameters Parameters { get; set; }
        public List<decimal> PriceRanges { get; set; }
        public List<int> YearRanges { get; set; }

        public InventoryViewModel()
        {
            PriceRanges = new List<decimal>()
            {
                2500M, 5000M, 7500M, 10000M, 12500M, 15000M, 17500M, 20000M, 22500M, 25000M, 27500M, 30000M, 32500M, 35000M, 37500M, 40000M, 42500M, 45000M, 47500M, 50000M
            };
            YearRanges = new List<int>();
            for (int i = 1990; i <= (DateTime.Today.Year + 1); i++)
            {
                YearRanges.Add(i);
            }
        }
    }
}