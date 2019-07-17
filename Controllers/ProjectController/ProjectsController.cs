using ProjectManagerApp2.Context;
using ProjectManagerApp2.Controllers.ProjectController.Converter;
using ProjectManagerApp2.Controllers.TaskController.Converter;
using ProjectManagerApp2.Models;
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

                /*var projects = from project in db.Projects
                               select new
                               {
                                   project.ProjectId,
                                   project.Name,
                                   project.Budget,
                                   
                                   Task = from task in db.Tasks
                                                   where task.project.ProjectId == project.ProjectId
                                                   select new
                                                   {
                                                       task.TaskId,
                                                       task.Name,
                                                       task.Description,
                                                       task.State
                                                   }
                                                   
                               };
*/

                List<ProjectDTO> projects = (from project in db.Projects
                               select new ProjectDTO
                               {
                                   ProjectId = project.ProjectId,
                                   Name = project.Name,
                                   Budget = project.Budget,

                                   TasksDTO = (from task in db.Tasks
                                          where task.project.ProjectId == project.ProjectId
                                          select new TaskDTO
                                          {
                                              TaskId = task.TaskId,
                                              Name = task.Name,
                                              Description = task.Description,
                                              State = task.State
                                          }).ToList()
                               }).ToList();

                return Ok(projects);
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }
        }


        

        

    }
}
