﻿using ProjectManagerApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerApp2.Controllers.TaskController.Converter
{
    public class TaskDTOFactory
    {

        public static TaskDTO taskToTaskDTO(Task task)
        {
            TaskDTO taskDTO = new TaskDTO();
            taskDTO.TaskId = task.TaskId;
            taskDTO.Name = task.Name;
            taskDTO.Description = task.Description;
            taskDTO.DateLimit = task.DateLimit;
            taskDTO.State = task.State;

            if (task.DeveloperEntity != null)
                taskDTO.ApplicationUserId = task.DeveloperEntity.Id;
            if (task.project != null)
                taskDTO.ProjectId = task.project.ProjectId;

            if (task.DeveloperEntity != null)
                taskDTO.DeveloperEntityDTO = new AccountsController.DTO.UserDTO
                {
                    Id = task.DeveloperEntity.Id,
                    Email = task.DeveloperEntity.Email,
                    UserName = task.DeveloperEntity.UserName
                };
            if (task.project != null)
                taskDTO.ProjectDTO = new ProjectDTO
                {
                    Name = task.project.Name,
                    Budget = task.project.Budget,
                    ProjectId = task.project.ProjectId

                };

            return taskDTO;
        }

        public static List<TaskDTO> getTasksDTOList(ICollection<Task> listOfTask)
        {
            List<TaskDTO> taskDTOs = new List<TaskDTO>();

            foreach (Task task in listOfTask)
                taskDTOs.Add(taskToTaskDTO(task));

            return taskDTOs;
        }
       
    }
}