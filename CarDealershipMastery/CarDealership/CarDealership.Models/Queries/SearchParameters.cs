using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class SearchParameters
    {
        public string Parameter { get; set; }
        public int YearParameter { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
        public int YearMin { get; set; }
        public int YearMax { get; set; }

        public SearchParameters()
        {
            YearParameter = 0;
            Parameter = "";
            PriceMin = 0M;
            PriceMax = 100000.00M;
            YearMin = 0;
            YearMax = 9999;
        }
    }
}
