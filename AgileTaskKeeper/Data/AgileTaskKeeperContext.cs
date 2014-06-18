using AgileTaskKeeper.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgileTaskKeeper.Data
{
    public class AgileTaskKeeperContext : DbContext
    {
        public DbSet<AgileTask> AgileTasks { get; set; }

        public AgileTask AddTaskToDb(AgileTask task)
        {
            var taskToAdd = task;

            using (var db = new AgileTaskKeeperContext())
            {
                db.AgileTasks.Add(taskToAdd);
                db.SaveChanges();
                return task;
            }
        }

        public IEnumerable<AgileTask> GetAllTasks()
        {
            using (var db = new AgileTaskKeeperContext())
            {
                return db.AgileTasks.ToList();
            }
        }

        public AgileTask GetTaskFromDb(String taskName)
        {
            using (var db = new AgileTaskKeeperContext())
            {
                AgileTask task = db.AgileTasks.Find(taskName);
                if (task != null)
                    return task;
            }
            return new AgileTask("NoTaskFound", "NoTaskFound");
        }
    }
}