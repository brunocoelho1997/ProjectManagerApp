using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectManagerApp2.Context;
using ProjectManagerApp2.Controllers.ProjectController.Converter;
using ProjectManagerApp2.Controllers.TaskController.Converter;
using ProjectManagerApp2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProjectManagerApp2.Controllers
{
    public class ProjectsController : BaseController
    {

        //Creating a method to return Json data   
        [HttpGet]
        public IHttpActionResult FindAll()
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
                                              State = task.State,
                                              DateLimit = task.DateLimit
                                              
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

        [Authorize(Roles = "ProjectManager")]
        [HttpPost]
        public async Task<IHttpActionResult> AddProject(ProjectDTO projectDTO)
        {
            try
            {
                string nameOfCurrentUser = System.Web.HttpContext.Current.User.Identity.Name;

                ApplicationUser tmp = this.db.Users.Where(x => x.UserName == nameOfCurrentUser).First();

                ProjectManagerEntity projectManagerEntity = (ProjectManagerEntity)tmp;

                Project project = new Project()
                {
                    Name = projectDTO.Name,
                    Budget = projectDTO.Budget,
                    ProjectManagerEntityId = projectManagerEntity.Id
                };

                project = this.db.Projects.Add(project);

                this.db.SaveChanges();

                return Ok(project);
            }
            catch (Exception e)
            {
                Console.Write("" + e.Message);

                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned 
                return throwErrorMessage("error message");
            }
        }

    }
}
