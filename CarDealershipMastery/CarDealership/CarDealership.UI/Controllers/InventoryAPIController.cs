using CarDealership.Data.Factories;
using CarDealership.Models;
using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealership.UI.Controllers
{
    public class InventoryAPIController : ApiController
    {
        [Route("api/inventory/searchall")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchAll(string parameter, decimal? priceMin, decimal? priceMax, int? yearMin, int? yearMax)
        {
            try
            {
                var param = new SearchParameters()
                {
                    Parameter = parameter
                };

                if (int.TryParse(param.Parameter, out int yearParam))
                {
                    param.YearParameter = yearParam;
                }
                if (string.IsNullOrEmpty(param.Parameter))
                {
                    param.Parameter = "";
                }
                if (priceMin.HasValue)
                {
                    param.PriceMin = (decimal)priceMin;
                }
                if (priceMax.HasValue)
                {
                    param.PriceMax = (decimal)priceMax;
                }
                if (yearMin.HasValue)
                {
                    param.YearMin = (int)yearMin;
                }
                if (yearMax.HasValue)
                {
                    param.YearMax = (int)yearMax;
                }

                var result = CarRepositoryFactory.GetRepository().SearchAll(param);

                return Ok(result);
            } 
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/inventory/searchnew")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchNew(string parameter, decimal? priceMin, decimal? priceMax, int? yearMin, int? yearMax)
        {
            try
            {
                var param = new SearchParameters()
                {
                    Parameter = parameter
                };

                if (int.TryParse(param.Parameter, out int yearParam))
                {
                    param.YearParameter = yearParam;
                }
                if (string.IsNullOrEmpty(param.Parameter))
                {
                    param.Parameter = "";
                }
                if (priceMin.HasValue)
                {
                    param.PriceMin = (decimal)priceMin;
                }
                if (priceMax.HasValue)
                {
                    param.PriceMax = (decimal)priceMax;
                }
                if (yearMin.HasValue)
                {
                    param.YearMin = (int)yearMin;
                }
                if (yearMax.HasValue)
                {
                    param.YearMax = (int)yearMax;
                }

                var result = CarRepositoryFactory.GetRepository().SearchNew(param);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/inventory/searchused")]
        [AcceptVerbs("GET")]
        public IHttpActionResult SearchUsed(string parameter, decimal? priceMin, decimal? priceMax, int? yearMin, int? yearMax)
        {
            try
            {
                var param = new SearchParameters()
                {
                    Parameter = parameter
                };

                if (int.TryParse(param.Parameter, out int yearParam))
                {
                    param.YearParameter = yearParam;
                }
                if (string.IsNullOrEmpty(param.Parameter))
                {
                    param.Parameter = "";
                }
                if (priceMin.HasValue)
                {
                    param.PriceMin = (decimal)priceMin;
                }
                if (priceMax.HasValue)
                {
                    param.PriceMax = (decimal)priceMax;
                }
                if (yearMin.HasValue)
                {
                    param.YearMin = (int)yearMin;
                }
                if (yearMax.HasValue)
                {
                    param.YearMax = (int)yearMax;
                }

                var result = CarRepositoryFactory.GetRepository().SearchUsed(param);

                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("api/inventory/delete/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int id)
        {
            var car = CarRepositoryFactory.GetRepository().GetById(id);

            try
            {
                var filePath = @"C:\Users\liamj\OneDrive\Documents\GitHub\online-net-2021-LiamJohnson132\CarDealershipMastery\CarDealership\CarDealership.UI\Images\" + car.ImgFileName;

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                CarRepositoryFactory.GetRepository().Delete(car.CarId);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
