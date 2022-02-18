using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership.UI.Models
{
    public class InventoryReportViewModel
    {
        public List<InventoryReportModel> NewReports { get; set; }
        public List<InventoryReportModel> UsedReports { get; set; }
    }
}