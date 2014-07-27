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
                List<AgileTask> foo = db.AgileTasks.ToList();
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

        public bool UpdateTask(AgileTask updateTask)
        {
            using (var db = new AgileTaskKeeperContext())
            {
                var taskToUpdate = db.AgileTasks.Find(updateTask.Title);
                if (taskToUpdate != null)
                {
                    taskToUpdate.Body = updateTask.Body;
                    taskToUpdate.MyStatus = updateTask.MyStatus;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public bool DeleteTask(AgileTask deletedTask)
        {
            using (var db = new AgileTaskKeeperContext())
            {
                var taskToDelete = db.AgileTasks.Find(deletedTask.Title);

                if (taskToDelete != null)
                {
                    db.AgileTasks.Remove(taskToDelete);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}