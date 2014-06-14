using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AgileTaskKeeper.Models;

namespace AgileTaskKeeper.Controllers
{
    public class TaskController : ApiController
    {
        Task[] tasks = new Task[]
        {
            new Task("Task1", "Body1"),
            new Task("Task2", "Body2")
        };

        // GET api/Task
        public IEnumerable<Task> Get()
        {
            return tasks;
        }

        // GET api/Task/5
        public Task Get(String id)
        {
            foreach (Task task in tasks)
            {
                if (task.Title.Equals(id))
                    return task;
            }
            return new Task("NoTitle", "NoBody");
        }

        // POST api/Task
        public void Post(String id)
        {
           
        }

        //// PUT api/Task/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/Task/5
        //public void Delete(int id)
        //{
        //}
    }
}
