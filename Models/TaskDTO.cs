﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerApp2.Models
{
    public class TaskDTO
    {
        
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateLimit { get; set; }

        public Boolean State { get; set; }

        public override string ToString()
        {
            return "ID: " + this.TaskId + "; Name: " + this.Name + " ; Description: " + Description + "; Date Limit " + this.DateLimit;
        }
    }
}