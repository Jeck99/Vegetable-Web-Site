using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VegetableWebSite.Models;

namespace VegetableWebSite.Controllers
{
    [RoutePrefix("api/latestorders")]
    public class LatestOrdersController : ApiController
    {
        ApplicationDbContext myDataBase = new ApplicationDbContext();
        [Authorize]
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetLatestOrders(string userName)
        {
            List<Orders> LatestOrders = new List<Orders>();

            var LatestOrdersOfUser = myDataBase.Orders.Where(x => x.UserEmail == userName);

            return Ok(LatestOrdersOfUser);
        }

    }
}
