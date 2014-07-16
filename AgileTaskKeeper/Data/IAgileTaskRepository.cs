using AgileTaskKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileTaskKeeper.Data
{
    public interface IAgileTaskRepository
    {
        IEnumerable<AgileTask> GetAll();
        AgileTask AddTask(AgileTask task);
        bool UpdateTask(AgileTask updatedTask);
        bool DeleteTask(AgileTask deletedTask);
    }
}
