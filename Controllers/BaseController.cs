using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ProjectManagerApp2.Controllers
{
    public class BaseController : ApiController
    {
        public IHttpActionResult throwErrorMessage(string v)
        {
            return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, v));
        }
    }
}