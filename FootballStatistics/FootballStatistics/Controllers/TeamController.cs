using FootballStatistics.Models;
using FootballStatistics.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballStatistics.Controllers
{
    [ApiController]
    [Route("teams")]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService teamService;
        public TeamController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        [HttpGet]
        public ActionResult Get(int matchId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return new JsonResult(this.teamService.GetTeamsForAMatch(matchId)
                .Select(team => new TeamDTO
                {
                    Id = team.Id,
                    Name = team.Name
                }));
        }
    }
}
