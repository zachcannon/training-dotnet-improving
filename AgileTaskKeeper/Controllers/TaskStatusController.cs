using AgileTaskKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AgileTaskKeeper.Controllers
{
    public class TaskStatusController : ApiController
    {
        // GET api/TaskStatus
        public IEnumerable<SelectListItem> Get()
        {
            return EnumHelper.GetSelectList(typeof(TaskStatus));
        }
    }
}
