using ProjectManagerApp2.Models;
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
            taskDTO.ApplicationUserId = task.applicationUser.Id;
            taskDTO.ProjectId = task.project.ProjectId;
            return taskDTO;
        }

        public static List<TaskDTO> getTasksDTOList(List<Task> listOfTask)
        {
            List<TaskDTO> taskDTOs = new List<TaskDTO>();

            foreach (Task task in listOfTask)
                taskDTOs.Add(taskToTaskDTO(task));

            return taskDTOs;
        }
       
    }
}