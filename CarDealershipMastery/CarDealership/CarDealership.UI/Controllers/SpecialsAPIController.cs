using CarDealership.Data.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealership.UI.Controllers
{
    public class SpecialsAPIController : ApiController
    {
        [Route("api/specials/delete/{id}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult DeleteSpecial(int id)
        {
            try
            {
                SpecialRepositoryFactory.GetRepository().Delete(id);
                return Ok();
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
