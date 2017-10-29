using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Helpers;
using System.Web.Http;
using VegetableWebSite.Models;

namespace VegetableWebSite.Controllers.api
{
    public class ContactController : ApiController
    { 

        [HttpPost]
        public IHttpActionResult CreateNewEmail(ClassEmail email)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(email.From);
            mail.To.Add("vagee4u@gmail.com");
            mail.Subject = email.Subject;
            mail.Body = email.Body;
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("vagee4u@gmail.com", "j123456e");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            return Ok();
        }
    }
}
