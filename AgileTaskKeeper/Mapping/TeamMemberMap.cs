using AgileTaskKeeper.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AgileTaskKeeper.Mapping
{
    public class TeamMemberMap : EntityTypeConfiguration<TeamMember>
    {
        public TeamMemberMap()
        {
            ToTable("TeamMembers");

            HasMany(tm => tm.AgileTasks)
            .WithMany(at => at.AssignedTeamMembers)
            .Map(m => {
                m.ToTable("TeamMemberAgileTasks");
                m.MapLeftKey("AgileTaskId");
                m.MapRightKey("TeamMemberId");
            });
        }
    }
}