using ProjectManagerApp2.Controllers.AccountsController.DTO;
using ProjectManagerApp2.Controllers.TaskController.Converter;
using ProjectManagerApp2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerApp2.Controllers.ProjectController.Converter
{
    public class ProjectDTOFactory
    {
        public static ProjectDTO projectToProjectDTO(Project project)
        {
            ProjectDTO projectDTO = new ProjectDTO();
            projectDTO.ProjectId = project.ProjectId;
            projectDTO.Name = project.Name;
            projectDTO.Budget = project.Budget;
            projectDTO.TasksDTO = TaskDTOFactory.getTasksDTOList(project.Tasks);
            projectDTO.UserDTO = new UserDTO
            {
                Id = project.ProjectManagerEntity.Id,
                UserName = project.ProjectManagerEntity.FullName,
                Email = project.ProjectManagerEntity.Email
            };
            return projectDTO;
        }

    }
}