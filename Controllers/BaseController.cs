using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using ProjectManagerApp2.Context;
using ProjectManagerApp2.Controllers.AccountsController.Converter;
using ProjectManagerApp2.Controllers.ApplicationUserController;
using ProjectManagerApp2.Controllers.RolesController.Converter;
using ProjectManagerApp2.Models;
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

        private UserDTOFactory _userDTOFactory;
        private RoleDTOFactory _roleDTOFactory;

        private ApplicationUserManager _AppUserManager = null;
        private ApplicationRoleManager _AppRoleManager = null;

        protected ApplicationRoleManager AppRoleManager
        {
            get
            {
                return _AppRoleManager ?? Request.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
        }
        protected ApplicationUserManager AppUserManager
        {
            get
            {
                return _AppUserManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        protected UserDTOFactory UserDTOFactory
        {
            get
            {
                if (_userDTOFactory == null)
                {
                    _userDTOFactory = new UserDTOFactory(this.Request, this.AppUserManager);
                }
                return _userDTOFactory;
            }
        }

        protected RoleDTOFactory RoleDTOFactory
        {
            get
            {
                if (RoleDTOFactory == null)
                {
                    _roleDTOFactory = new RoleDTOFactory(this.Request);
                }
                return RoleDTOFactory;
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