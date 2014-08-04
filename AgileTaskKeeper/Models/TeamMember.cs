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