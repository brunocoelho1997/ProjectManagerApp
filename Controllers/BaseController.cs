using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ProjectManagerApp2.Context;
using ProjectManagerApp2.Controllers.AccountsController.Converter;
using ProjectManagerApp2.Controllers.ApplicationUserController;
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

        private UserDTOFactory _modelFactory;
        private ApplicationUserManager _AppUserManager = null;

        protected ApplicationUserManager AppUserManager
        {
            get
            {
                return _AppUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        protected UserDTOFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new UserDTOFactory(this.Request, this.AppUserManager);
                }
                return _modelFactory;
            }
        }

        public BaseController()
        {
            this.db = new DatabaseContext();
        }

        public IHttpActionResult throwErrorMessage(string v)
        {
            return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, v));
        }

        protected IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}