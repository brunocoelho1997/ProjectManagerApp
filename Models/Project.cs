using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagerApp2.Models
{
    public class Project
    {
        [Key]
        public int ProjectId{ get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The name cannot be longer than 50 characters.")]
        public string Name { get; set; }
        public double Budget { get; set; }

        public List<Task> Tasks { get; set; }

    }
}