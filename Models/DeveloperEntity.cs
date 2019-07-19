using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerApp2.Models
{
    public class DeveloperEntity : ApplicationUser
    {
        public List<Task> Tasks { get; set; }
    }
}