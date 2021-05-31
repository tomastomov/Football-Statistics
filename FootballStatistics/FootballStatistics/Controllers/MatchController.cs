using FootballStatistics.Data.Models.Enums;
using FootballStatistics.Models;
using FootballStatistics.Services.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballStatistics.Controllers
{
    [ApiController]
    [Route("matches")]
    public class MatchController : ControllerBase
    {
        private readonly IMatchService matchService;
        public MatchController(IMatchService matchService)
        {
            this.matchService = matchService;
        }

        [HttpGet("{leagueId}/{date}")]
        public ActionResult GetMatch([FromRoute] MatchFormModel model)
        {
            if (model.Date == default)
            {
                model.Date = DateTime.UtcNow;
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return new JsonResult(this.matchService.GetMatches(model.LeagueId, model.Date)
                .Select(m => new MatchDTO()
                {
                    Id = m.Id,
                    HomeTeam = m.HomeTeam,
                    AwayTeam = m.AwayTeam,
                    MatchEvents = m.MatchEvents,
                    MatchResult = m.MatchResult,
                    StartTime = m.StartTime,
                    AwayTeamGoalsCount = m.AwayTeamGoalsCount,
                    HomeTeamGoalsCount = m.HomeTeamGoalsCount
                }));
        }
    }
}
