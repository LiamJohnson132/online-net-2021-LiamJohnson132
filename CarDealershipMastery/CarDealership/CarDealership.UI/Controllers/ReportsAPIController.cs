using CarDealership.Data.Factories;
using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealership.UI.Controllers
{
    public class ReportsAPIController : ApiController
    {
        [Route("api/reports/sales/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchSales(string id, string dateMin, string dateMax)
        {
            try
            {
                var repo = UserRepositoryFactory.GetRepository();

                var param = new SalesReportParameters();

                param.UserId = id;
                
                if (DateTime.TryParse(dateMin, out var dateMinParsed))
                {
                    param.DateMin = dateMinParsed;
                } else
                {
                    if (!string.IsNullOrEmpty(dateMin))
                        throw new Exception("Please provide a valid date");
                }
                if (DateTime.TryParse(dateMax, out var dateMaxParsed))
                {
                    param.DateMax = dateMaxParsed;
                } else
                {
                    if (!string.IsNullOrEmpty(dateMax))
                        throw new Exception("Please provide a valid date");
                }

                var result = repo.GetSalesReports(param);

                return Ok(result);
            } 
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
