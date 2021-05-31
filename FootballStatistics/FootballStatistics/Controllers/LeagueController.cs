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
    [Route("leagues")]
    public class LeagueController : ControllerBase
    {
        private ILeagueService leagueService;
        public LeagueController(ILeagueService leagueService)
        {
            this.leagueService = leagueService;
        }

        [HttpGet]
        public ActionResult Get()
            => new JsonResult(this.leagueService.GetAllLeagues()
                .Select(league => new LeagueDTO
                {
                    Id = league.Id,
                    Name = league.Name
                }));
    }
}
