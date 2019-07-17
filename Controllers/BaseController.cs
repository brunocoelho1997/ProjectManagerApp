using ProjectManagerApp2.Context;
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
        //Creating Instance of DatabaseContext class  
        protected DatabaseContext db;

        public BaseController()
        {
            this.db = new DatabaseContext();
        }

        public IHttpActionResult throwErrorMessage(string v)
        {
            return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, v));
        }
    }
}