using CarDealership.Data.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealership.UI.Controllers
{
    public class MakeModelAPIController : ApiController
    {
        [Route("api/makes/getmodels/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetModels(int id)
        {
            var repo = ModelRepositoryFactory.GetRepository();

            try
            {
                var result = repo.GetByMake(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
