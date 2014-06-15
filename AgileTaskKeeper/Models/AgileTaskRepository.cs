using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AgileTaskKeeper.Models
{
    public class AgileTaskRepository : IAgileTaskRepository
    {
        IEnumerable<AgileTask> IAgileTaskRepository.GetAll()
        {
            TaskContext db = new TaskContext();
            return db.GetAllTasks();
        }

        AgileTask IAgileTaskRepository.AddTask(AgileTask task)
        {
            TaskContext data = new TaskContext();
            return data.AddTaskToDb(task);
        }
    }

    public class TaskContext : DbContext
    {
        public DbSet<AgileTask> AgileTasks { get; set; }

        public AgileTask AddTaskToDb(AgileTask task)
        {
            var taskToAdd = task;

            using (var db = new TaskContext())
            {
                db.AgileTasks.Add(taskToAdd);
                db.SaveChanges();
                return task;
            }
        }

        public IEnumerable<AgileTask> GetAllTasks()
        {
            using (var db = new TaskContext())
            {
                return db.AgileTasks.ToList();
            }
        }

        public AgileTask GetTaskFromDb(String taskName)
        {
            using (var db = new TaskContext())
            {
                AgileTask task = db.AgileTasks.Find(taskName);
                if (task != null)
                    return task;
            }
            return new AgileTask("NoTaskFound", "NoTaskFound");
        }
    }
}