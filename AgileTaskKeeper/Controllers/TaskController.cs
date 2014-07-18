using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AgileTaskKeeper.Data;
using AgileTaskKeeper.Models;
using System.Text;

namespace AgileTaskKeeper.Controllers
{
    public class AgileTaskController : ApiController
    {
        private IAgileTaskRepository _repository;

        public AgileTaskController(IAgileTaskRepository repository)
        {
            this._repository = repository;
        }

        // GET api/Task
        public IEnumerable<AgileTask> Get()
        {
            return _repository.GetAll();
        }

        // POST api/Task
        [HttpPost]
        public AgileTask Post(AgileTask task)
        {
            return _repository.AddTask(task);
        }

        // HACK: IIS Express will not allow a HTTP DELETE request
        // I made this a POST request with a custom route to get around DELETE block
        [Route("api/AgileTask/Delete")]
        [HttpPost]
        public HttpResponseMessage DeleteAStory([FromBody] AgileTask storyToDelete)
        {
            bool result = _repository.DeleteTask(storyToDelete);

            if (result)
                return Request.CreateResponse(HttpStatusCode.OK, "value");
            else
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, "value");
        }

        // Update api/Task
        public HttpResponseMessage Put(AgileTask task)
        {
            bool result = _repository.UpdateTask(task);

            if (result)
                return Request.CreateResponse(HttpStatusCode.OK, "value");
            else
                return Request.CreateResponse(HttpStatusCode.ExpectationFailed, "value");
        }
    }
}
