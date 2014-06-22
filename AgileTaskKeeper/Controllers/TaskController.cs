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
        public AgileTask Post(AgileTask task)
        {
            return _repository.AddTask(task);
        }

        // Update api/Task
        public HttpResponseMessage Put(AgileTask task)
        {
            bool result = _repository.UpdateTask(task);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, "value");

            if (result) {
                response.Content = new StringContent("pass", Encoding.Unicode);
            } else {
                response.Content = new StringContent("fail", Encoding.Unicode);
            }

            return response;
        }
    }
}
