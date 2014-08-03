using AgileTaskKeeper.Data;
using AgileTaskKeeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AgileTaskKeeper.Controllers
{
    public class TeamMemberController : ApiController
    {
        private ITeamMemberRepository _repository;

        public TeamMemberController(ITeamMemberRepository repository)
        {
            this._repository = repository;
        }

        public IEnumerable<TeamMember> Get()
        {
            List<TeamMember> foo = new List<TeamMember>();
            foo.Add(new TeamMember(1, "Jackson Badass"));
            foo.Add(new TeamMember(2, "Jackson Smartass"));

            return foo;
        }

        [HttpPost]
        public void Post(TeamMember memberToAdd)
        {
            _repository.AddTeamMember(memberToAdd);
        }
    }
}
