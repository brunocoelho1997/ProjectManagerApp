using ProjectManagerApp2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjectManagerApp2.Context
{
    public class DatabaseInitializer : DropCreateDatabaseAlways<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            base.Seed(context);

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