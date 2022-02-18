using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class SalesReportViewModel
    {
        public List<SalesReportModel> Reports { get; set; }
        public SalesReportParameters Parameters { get; set; }
        public List<UserModel> Users { get; set; }
    }
}