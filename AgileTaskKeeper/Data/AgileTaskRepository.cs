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
        private AgileTaskKeeperContext db = new AgileTaskKeeperContext();

        IEnumerable<AgileTask> IAgileTaskRepository.GetAll()
        {
            return db.GetAllTasks();
        }

        AgileTask IAgileTaskRepository.AddTask(AgileTask task)
        {
            return db.AddTaskToDb(task);
        }

        bool IAgileTaskRepository.UpdateTask(AgileTask updatedTask)
        {
            return db.UpdateTask(updatedTask);
        }

        bool IAgileTaskRepository.DeleteTask(AgileTask deletedTask)
        {
            return db.DeleteTask(deletedTask);
        }
    }
}