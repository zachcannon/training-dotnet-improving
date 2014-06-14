using AgileTaskKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileTaskKeeper.Data
{
    class ApplicationContext : DbContext
    {
        public DbSet<AgileTask> AgileTasks { get; set; }

        public void AddTaskToDb(AgileTask task)
        {
            using (var db = new ApplicationContext())
            {
                db.AgileTasks.Add(task);
                db.SaveChanges();
            }
        }

        public AgileTask GetTaskFromDb(String taskName)
        {
            using (var db = new ApplicationContext())
            {
                AgileTask task = db.AgileTasks.Find(taskName);
                if (task != null)
                    return task;
            }
            return new AgileTask("NoTaskFound", "NoTaskFound");
        }
    }
}
