using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjectManagerApp2.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The name cannot be longer than 50 characters.")]
        public string Name { get; set; }
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateLimit { get; set; }

        public Boolean State{ get; set; }

        public override string ToString()
        {
            return "ID: " + this.TaskId + "; Name: " + this.Name + " ; Description: " + Description + "; Date Limit " + this.DateLimit;
        }
    }
}