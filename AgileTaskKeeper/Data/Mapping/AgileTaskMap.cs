using AgileTaskKeeper.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace AgileTaskKeeper.Mapping
{
    public class AgileTaskMap : EntityTypeConfiguration<AgileTask>
    {
        public AgileTaskMap()
        {
            ToTable("AgileTasks");

            HasMany(at => at.AssignedTeamMembers)
            .WithMany(tm => tm.AgileTasks)
            .Map(m => {
                m.ToTable("TeamMemberAgileTasks");
                m.MapLeftKey("TeamMemberId");
                m.MapRightKey("AgileTaskId");
            });

            HasKey(at => at.AgileTaskId);

            Property(at => at.MyStatus).HasColumnName("TaskStatusId");
        }
    }
}