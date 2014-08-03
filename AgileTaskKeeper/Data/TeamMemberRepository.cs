using AgileTaskKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileTaskKeeper.Data
{
    public class TeamMemberRepository : ITeamMemberRepository
    {
        private AgileTaskKeeper db = new AgileTaskKeeper();

        public IEnumerable<TeamMember> GetAll()
        {
            return db.GetAllTeamMembers();
        }

        public void AddTeamMember(TeamMember member)
        {
            db.AddATeamMember(member);
        }
    }
}