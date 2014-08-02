using AgileTaskKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgileTaskKeeper.Controllers
{
    public class TaskStatusController : ApiController
    {
        // GET api/TaskStatus
        public IEnumerable<String> Get()
        {
            return Enum.GetNames(typeof(TaskStatus));
        }
    }
}
