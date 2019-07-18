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

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DatabaseContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new DatabaseContext()));


            /*
             * 
             * ADD ROLES
             * 
             */
            string[] roles = new string[] { RoleEnum.ProjectManager.ToString(), RoleEnum.Developer.ToString(), RoleEnum.Admin.ToString() };
            foreach (var roleName in roles)
            {
                IdentityResult roleResult;
                // Check to see if Role Exists, if not create it
                if (!roleManager.RoleExists(roleName))
                {
                    roleResult = roleManager.Create(new IdentityRole(roleName));
                }
            }

            var projectManagerUser = new ApplicationUser()
            {
                UserName = "projectmanager",
                Email = "projectmanager@mymail.com",
                EmailConfirmed = true,
                FullName = "Project Manager"
            };
            var developerUser = new ApplicationUser()
            {
                UserName = "developer",
                Email = "developer@mymail.com",
                EmailConfirmed = true,
                FullName = "Developer User"
            };

            var adminUser = new ApplicationUser()
            {
                UserName = "admin",
                Email = "admin@mymail.com",
                EmailConfirmed = true,
                FullName = "Admin User"
            };


            userManager.Create(projectManagerUser, "1234567890");
            var currentUser = userManager.FindByName(projectManagerUser.UserName);
            userManager.AddToRole(currentUser.Id, RoleEnum.ProjectManager.ToString());
            
            userManager.Create(developerUser, "1234567890");
            currentUser = userManager.FindByName(developerUser.UserName);
            userManager.AddToRole(currentUser.Id, RoleEnum.Developer.ToString());

            userManager.Create(adminUser, "1234567890");
            currentUser = userManager.FindByName(adminUser.UserName);
            //userManager.AddToRoles(adminUser.Id, new string[] { "SuperAdmin", "Admin" })
            userManager.AddToRole(currentUser.Id, RoleEnum.Admin.ToString());

            /*
             * 
             * ADD PROJECTS AND TASKS
             * 
             */
            developerUser = userManager.FindByName(developerUser.UserName);

            var listOfTasks = new List<Task> {
                new Task {Name="Dehradun", DateLimit=DateTime.Now},
                new Task {Name="Rishikesh", Description="Olá Mundo", DateLimit=DateTime.Now}
            };
            
            Project project = new Project();
            project.Name = "ProjectA";
            project.Budget = 200000;
            project.Tasks = listOfTasks;

            context.Projects.Add(project);
            
            context.SaveChanges();

        }
    }
}
