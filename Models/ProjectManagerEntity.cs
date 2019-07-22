using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagerApp2.Models
{
    public class ProjectManagerEntity : ApplicationUser
    {
        public virtual ICollection<Project> Projects { get; set; }

    }
}