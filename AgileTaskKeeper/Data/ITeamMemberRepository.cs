using AgileTaskKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileTaskKeeper.Data
{
    public interface ITeamMemberRepository
    {
        IEnumerable<TeamMember> GetAll();
        void AddTeamMember(TeamMember member);
        void RemoveTeamMember(int idToRemove);
    }
}
