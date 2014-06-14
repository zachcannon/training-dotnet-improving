using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AgileTaskKeeper.Models;
using System.Data.Entity;

namespace AgileTaskKeeper.Controllers
{
    public class AgileTaskController : ApiController
    {

        // GET api/Task
        public IEnumerable<AgileTask> Get()
        {
            TaskContext db = new TaskContext();
            return db.GetAllTasks();
        }

        // GET api/Task/5
        public AgileTask Get(String id)
        {
            TaskContext db = new TaskContext();

            foreach (AgileTask task in db.GetAllTasks())
            {
                if (task.Title.Equals(id))
                    return task;
            }
            return new AgileTask("NoTitle", "NoBody");
        }

        // POST api/Task
        public void Post(AgileTask task)
        {
            TaskContext data = new TaskContext();
            data.AddTaskToDb(task);
        }
    }

    public class TaskContext : DbContext
    {
        public DbSet<AgileTask> AgileTasks { get; set; }

        public void AddTaskToDb(AgileTask task)
        {
            var taskToAdd = task;

            using (var db = new TaskContext())
            {
                db.AgileTasks.Add(taskToAdd);
                db.SaveChanges();
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
