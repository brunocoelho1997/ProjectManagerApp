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
using System.Web.Http;

namespace ProjectManagerApp2.Controllers
{
    public class TasksController : BaseController
    {

        //Creating a method to return Json data   
        //[Authorize]
        [HttpGet]
        public IHttpActionResult findAll()
        {
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
                                 DateLimit = task.DateLimit
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
                                 DateLimit = task.DateLimit
                             };

                return Ok(result);
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult addTask(JObject jsonResult)
        {
            try
            {
                TaskDTO item = JsonConvert.DeserializeObject<TaskDTO>(jsonResult.ToString());

                db.Tasks.Add(TaskDTOFactory.taskDTOToTask(item));
                db.SaveChanges();

                return Ok(jsonResult);
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return throwErrorMessage("error message");
            }
        }

        [HttpPut]
        public IHttpActionResult editTask(JObject jsonResult)
        {
            try
            {
                TaskDTO taskDTO = JsonConvert.DeserializeObject<TaskDTO>(jsonResult.ToString());

                if (isInvalidTask(taskDTO))
                {
                    throwErrorMessage("Task not found.");
                }

                Task task = db.Tasks.Find(taskDTO.TaskId);
                task.Name = taskDTO.Name;
                task.State = taskDTO.State;
                task.DateLimit = taskDTO.DateLimit;
                task.Description = taskDTO.Description;
                
                db.SaveChanges();

                return Ok(jsonResult);
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

        [HttpDelete]
        public IHttpActionResult removeTask(int taskId)
        {
            try
            {
                Task task = db.Tasks.Find(taskId);
                db.Tasks.Remove(task);
                db.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {
                //If any exception occurs Internal Server Error i.e. Status Code 500 will be returned  
                return throwErrorMessage("Error Message");
            }
        }
    }
}
