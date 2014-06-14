using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileTaskKeeper.Models
{
    public class Task
    {
        public String Title { get; set; }
        public String Body { get; set; }

        public Task(String title, String body)
        {
            this.Title = title;
            this.Body = body;
        }
    }
}