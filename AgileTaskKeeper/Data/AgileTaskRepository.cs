using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AgileTaskKeeper.Models;

namespace AgileTaskKeeper.Data
{
    public class AgileTaskRepository : IAgileTaskRepository
    {
        IEnumerable<AgileTask> IAgileTaskRepository.GetAll()
        {
            AgileTaskKeeperContext db = new AgileTaskKeeperContext();
            return db.GetAllTasks();
        }

        AgileTask IAgileTaskRepository.AddTask(AgileTask task)
        {
            AgileTaskKeeperContext data = new AgileTaskKeeperContext();
            return data.AddTaskToDb(task);
        }
    }
}