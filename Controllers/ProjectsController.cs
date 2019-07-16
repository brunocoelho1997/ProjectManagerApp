using ProjectManagerApp2.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectManagerApp2.Controllers
{
    public class ProjectsController : ApiController
    {

        //Creating Instance of DatabaseContext class  
        private DatabaseContext db = new DatabaseContext();

        //Creating a method to return Json data   
        [HttpGet]
        public IHttpActionResult findAll()
        {
            try
            {
                //Prepare data to be returned using Linq as follows  
                var result = from project in db.Projects
                             select new
                             {
                                 project.ProjectId,
                                 project.Name,
                                 project.Budget,
                                 project.Tasks
                             };

                return Ok(result);
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }
        }
    }
}
