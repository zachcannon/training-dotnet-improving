using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AgileTaskKeeper.Models
{
    public class TeamMember
    {
        [Required, Key]
        public int TeamMemberId { get; set; }
        public String Name { get; set; }

        public virtual ICollection<AgileTask> TaskList { get; set; }

        public TeamMember() { }
        public TeamMember(int Id, String name)
        {
            this.TeamMemberId = Id;
            this.Name = name;
        }

    }
}