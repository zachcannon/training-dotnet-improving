using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileTaskKeeper.Models
{
    public interface IAgileTaskRepository
    {
        IEnumerable<AgileTask> GetAll();
        AgileTask AddTask(AgileTask task);
    }
}
