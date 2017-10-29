using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using VegetableWebSite.Models;
using VegetableWebSite.Utils;

namespace VegetableWebSite.Controllers
{
    public class UsersController : ApiController
    {
        ApplicationDbContext myDataBasa = new ApplicationDbContext();

        bool validationIsOk(string some_string)
        {
            return !string.IsNullOrEmpty(some_string);
        }
        [Authorize]
        [HttpGet]
        public IHttpActionResult Get_Users(long id)
        {
            Users Users_tem = myDataBasa.UsersTable.Find(id);
            if (Users_tem == null)
            {
                return NotFound();
            }
            return Ok(Users_tem);
        }
        [Authorize]
        [HttpGet]
        public IHttpActionResult GetUser(long id)
        {
            Users Users_tem = myDataBasa.UsersTable.Find(id);
            if (Users_tem == null)
            {
                return NotFound();
            }
            return Ok(Users_tem);
        }
       // [Authorize]
        [HttpPost]
        public IHttpActionResult CreateUsers(Users newOne)
        {
            var userExist = myDataBasa.UsersTable.FirstOrDefault(user => user.userEmail == newOne.userEmail);
            
            if (!validationIsOk(newOne.userEmail))
            {
                return BadRequest();
            }
            if (userExist != null)
            {
                return Ok(GeneralUtilis.isAdmin(userExist.Role));
            }
            else
            {
                newOne.Role = "user";
                myDataBasa.UsersTable.Add(newOne);
                myDataBasa.SaveChanges();
                return CreatedAtRoute("DefaultApi", new { id = newOne.Id }, GeneralUtilis.isAdmin(newOne.Role));
            }
        }
    }
}
