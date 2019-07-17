namespace ProjectManagerApp2.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using ProjectManagerApp2.Context;
    using ProjectManagerApp2.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProjectManagerApp2.Context.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ProjectManagerApp2.Context.DatabaseContext";
        }

        protected override void Seed(ProjectManagerApp2.Context.DatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DatabaseContext()));

            var user = new ApplicationUser()
            {
                UserName = "SuperPowerUser",
                Email = "taiseer.joudeh@mymail.com",
                EmailConfirmed = true,
                FullName = "Taiseer Ola"
            };

            manager.Create(user, "123");


            /*
             * 
             * ADD PROJECTS AND TASKS
             */

            var listOfTasks = new List<Task> {
                new Task {Name="Dehradun", DateLimit=DateTime.Now },
                new Task {Name="Rishikesh", Description="Olá Mundo", DateLimit=DateTime.Now}
            };
            /*
            System.Diagnostics.Debug.WriteLine("\n\n\n\n LIST OF TASKS:");
            foreach(Task task in listOfTasks)
                System.Diagnostics.Debug.WriteLine("\n" + task.ToString());
            */
            Project project = new Project();
            project.Name = "ProjectA";
            project.Budget = 200000;
            project.Tasks = listOfTasks;

            context.Projects.Add(project);
            /*
            var listOfRoles = new List<Role> {
                new Role {Name="ProjectManager"},
                new Role {Name="Developer"}
            };

            context.Roles.AddRange(listOfRoles);

            var listOfUsers = new List<User> {
                new User {Username = "projectmanager", Password = "123", Role=listOfRoles[0]},
                new User {Username = "dev", Password = "123", Role=listOfRoles[1]}
            };

            context.Users.AddRange(listOfUsers);
            */
            context.SaveChanges();

        }
    }
}
