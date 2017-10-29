using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace VegetableWebSite.Controllers.api
{
    public class UploadFileController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage UploadJsonFile()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    postedFile.SaveAs("C:\\Users\\user\\Desktop\\vagee4u\\VegetableWebSiteV2\\PROJECT\\TamatFinal\\TamatFinalProject\\src\\assets\\"
                   + postedFile.FileName);
                }
            }
            return response;

        }
    }
}
