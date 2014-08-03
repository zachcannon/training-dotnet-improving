using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgileTaskKeeper.Models
{
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }

        public TeamMember() { }

        public TeamMember(int Id, String name)
        {
            this.Id = Id;
            this.Name = name;
        }

    }
}