using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectManagerApp2.Context;
using ProjectManagerApp2.Controllers.TaskController.Converter;
using ProjectManagerApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ProjectManagerApp2.Controllers
{
    [Authorize]
    public class TasksController : BaseController
    {

        //Creating a method to return Json data
        [HttpGet]
        public IHttpActionResult findAll()
        {

            //RequestContext.Principal.Identity.Name; //get actual user which called the method

            
            try
            {
                //Prepare data to be returned using Linq as follows  
                var result = from task in db.Tasks 
                             select new TaskDTO
                             {
                                 TaskId = task.TaskId,
                                 Name = task.Name,
                                 Description= task.Description,
                                 State = task.State,
                                 DateLimit = task.DateLimit,
                                 ProjectId = task.project.ProjectId,
                                 ApplicationUserId = task.DeveloperEntity.Id
                             };

                return Ok(result);
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult findById(int taskId)
        {
            try
            {
                //Prepare data to be returned using Linq as follows  
                var result = from task in db.Tasks
                             where task.TaskId == taskId
                             select new TaskDTO
                             {
                                 TaskId = task.TaskId,
                                 Name = task.Name,
                                 Description = task.Description,
                                 State = task.State,
                                 DateLimit = task.DateLimit,
                                 ProjectId = task.project.ProjectId,
                                 ApplicationUserId = task.DeveloperEntity.Id
                             };

                return Ok(result);
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }
        }

        [Authorize(Roles = "ProjectManager")]
        [HttpPost]
        public async Task<IHttpActionResult> CreateTask(TaskDTO taskDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var projectTmp = this.db.Projects.Find(taskDTO.ProjectId);

                if (projectTmp == null)
                    return throwErrorMessage("Project not found");

                //var developerEntityTmp = (DeveloperEntity)this.AppUserManager.FindById(taskDTO.ApplicationUserId);

                var developerEntityTmp = (DeveloperEntity)this.db.Users.Find(taskDTO.ApplicationUserId);

                if (developerEntityTmp == null)
                    return throwErrorMessage("Developer not found");

                var task = new Models.Task
                {
                    Name = taskDTO.Name,
                    Description = taskDTO.Description,
                    DateLimit = taskDTO.DateLimit,
                    State = taskDTO.State,
                    //project = projectTmp,
                    DeveloperEntity = developerEntityTmp
                };

                //db.Tasks.Add(task);

                projectTmp.Tasks.Add(task);

                db.SaveChanges();

                return Ok(TaskDTOFactory.taskToTaskDTO(task));

            }catch (Exception e)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return throwErrorMessage("error message: " + e);
            }


        }

        [Authorize(Roles = "ProjectManager")]
        [HttpPut]
        public async Task<IHttpActionResult> EditTask(TaskDTO taskDTO)
        {
            try
            {
                //TaskDTO taskDTO = JsonConvert.DeserializeObject<TaskDTO>(jsonResult.ToString());

                if (isInvalidTask(taskDTO))
                {
                    throwErrorMessage("Task not found.");
                }

                Models.Task task = db.Tasks.Find(taskDTO.TaskId);
                task.Name = taskDTO.Name;
                task.State = taskDTO.State;
                task.DateLimit = taskDTO.DateLimit;
                task.Description = taskDTO.Description;
                
                db.SaveChanges();

                return Ok(task);
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return throwErrorMessage("Error Message");
            }
        }
        

        private bool isInvalidTask(TaskDTO taskDTO)
        {
            return false;
        }

        [Authorize(Roles = "ProjectManager")]
        [HttpDelete]
        public IHttpActionResult removeTask(int taskId)
        {
            try
            {
                Models.Task task = db.Tasks.Find(taskId);
                db.Tasks.Remove(task);
                db.SaveChanges();

                return Ok();
            }
            catch (Exception e)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return throwErrorMessage("Error Message: " + e);
            }
        }

        [Authorize(Roles = "Developer")]
        [HttpPut]
        public async Task<IHttpActionResult> SetTaskAsDone(TaskDTO taskDTO)
        {
            try
            {

                //RequestContext.Principal.Identity.Name; //get actual user which called the method


                //TaskDTO taskDTO = JsonConvert.DeserializeObject<TaskDTO>(jsonResult.ToString());

                if (taskDTO.TaskId == 0)
                    return NotFound();
                

                var task = db.Tasks.Find(taskDTO.TaskId);

                if(task == null)
                    return NotFound();

                //if(task.) //TODO: verify if the task belongs to the user which defined as done

                task.State = taskDTO.State;
                db.SaveChanges();

                return Ok(TaskDTOFactory.taskToTaskDTO(task));
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return throwErrorMessage("Error Message");
            }
        }
        
    }
}
