using ProjectManagerApp2.Controllers.AccountsController.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerApp2.Models
{
    public class ProjectDTO
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public double Budget { get; set; }
        public List<TaskDTO> TasksDTO { get; set; }

        public UserDTO UserDTO { get; set; }
    }
}