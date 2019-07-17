﻿using ProjectManagerApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerApp2.Controllers.TaskController.Converter
{
    public class TaskDTOFactory
    {
        public static Task taskDTOToTask(TaskDTO taskDTO)
        {
            Task task = new Task();
            task.Name = taskDTO.Name;
            task.Description = taskDTO.Description;
            task.DateLimit = taskDTO.DateLimit;
            task.State = taskDTO.State;
            return task;
        }

        public static TaskDTO taskToTaskDTO(Task task)
        {
            TaskDTO taskDTO = new TaskDTO();
            taskDTO.TaskId = task.TaskId;
            taskDTO.Name = task.Name;
            taskDTO.Description = task.Description;
            taskDTO.DateLimit = task.DateLimit;
            taskDTO.State = task.State;
            return taskDTO;
        }

        public static List<TaskDTO> getTasksDTOList(List<Task> listOfTask)
        {
            List<TaskDTO> taskDTOs = new List<TaskDTO>();

            foreach (Task task in listOfTask)
                taskDTOs.Add(taskToTaskDTO(task));

            return taskDTOs;
        }
        public static List<Task> getTasksList(List<TaskDTO> listOfTask)
        {
            List<Task> tasks = new List<Task>();

            foreach (TaskDTO taskDTO in listOfTask)
                tasks.Add(taskDTOToTask(taskDTO));

            return tasks;
        }

    }
}