using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgileTaskKeeper.Models
{
    public class AgileTask
    {
        [Key]
        public String Title { get; set; }
        public String Body { get; set; }

        public AgileTask() { }

        public AgileTask(String title, String body)
        {
            this.Title = title;
            this.Body = body;
        }
    }
}