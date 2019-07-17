using Microsoft.AspNet.Identity.EntityFramework;
using ProjectManagerApp2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectManagerApp2.Context
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext() : base("DefaultConnection") { }

        public static DatabaseContext Create()
        {
            return new DatabaseContext();
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Task> Tasks { get; set; }
        /*
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        */

    }
}