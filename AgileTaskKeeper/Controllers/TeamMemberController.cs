﻿using AgileTaskKeeper.Data;
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
            return _repository.GetAll();
        }

        [HttpPost]
        public void Post(TeamMember member)
        {
            _repository.AddTeamMember(member);
        }

        [Route("api/TeamMember/Delete")]
        [HttpPost]
        public void Delete(int id)
        {
            _repository.RemoveTeamMember(id);
        }
    }
}
