using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class SpecialsViewModel
    {
        public List<Special> Specials { get; set; }
        public Special NewSpecial { get; set; }
        public bool ConfirmDelete { get; set; }
    }
}