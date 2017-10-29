using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VegetableWebSite.Models;

namespace VegetableWebSite.Controllers
{
    [RoutePrefix("api/order")]
    public class OrderController : ApiController
    {
        ApplicationDbContext myDataBase = new ApplicationDbContext();

        bool validationIsOk(string some_string)
        {
            return !string.IsNullOrEmpty(some_string);
        }
        [Authorize]
        [Route("")]
        [HttpPost]
        public IHttpActionResult CreateBlog(Orders newOne)
        {
            if (!validationIsOk(newOne.OrderPrice.ToString()) || !validationIsOk(newOne.ProductId.ToString()) || !validationIsOk(newOne.UserEmail.ToString())) { return BadRequest(); }
            // newOne.OrderDate = DateTime.Now.ToString("yy-mm-dd");
            myDataBase.Orders.Add(newOne);
            myDataBase.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = newOne.Id }, newOne);
        }
        [Authorize]
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get_Orders()
        {
            return Ok(myDataBase.Orders);
        }
        [Authorize]
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get_Order(long id)
        {
            Orders Orders_tem = myDataBase.Orders.Find(id);
            if (Orders_tem == null)
            {
                return NotFound();
            }
            return Ok(Orders_tem);
        }
    }
}
