using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Models.Queries
{
    public class SalesReportParameters
    {
        public string UserId { get; set; }
        public DateTime DateMin { get; set; }
        public DateTime DateMax { get; set; }

        public SalesReportParameters()
        {
            UserId = "";
            DateMin = DateTime.Parse("1/1/1900");
            DateMax = DateTime.Today.AddDays(1);
        }
    }
}
