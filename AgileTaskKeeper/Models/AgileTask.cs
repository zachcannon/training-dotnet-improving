using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgileTaskKeeper.Models
{
    public class AgileTask
    {
        public int AgileTaskId { get; set; }
        public String Title { get; set; }
        public String Body { get; set; }

        public virtual TaskStatus MyStatus { get; set; }

        public virtual ICollection<TeamMember> AssignedTeamMembers { get; set; }

        public AgileTask() { }
        public AgileTask(String title, String body)
        {
            this.Title = title;
            this.Body = body;
        }
    }
}