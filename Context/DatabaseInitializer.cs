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
            context.SaveChanges();

        }
    }
}