using CarDealership.Models;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class HomeViewModel
    {
        public List<Car> Featured { get; set; }
        public List<Special> Specials { get; set; }
    }
}