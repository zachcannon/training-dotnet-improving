using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AgileTaskKeeper.Models
{
    public class TaskStatus
    {
        [Key]
        public int TaskStatusId { get; set; }
        public String StatusText { get; set; }

        public TaskStatus() { }

        public TaskStatus(int TaskStatusId, String StatusText)
        {
            this.TaskStatusId = TaskStatusId;
            this.StatusText = StatusText;
        }
    }
}