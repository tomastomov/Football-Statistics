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
    [Route("playerstatistics")]
    public class PlayerStatisticController : ControllerBase
    {
        private readonly IPlayerStatisticService playerStatisticService;

        public PlayerStatisticController(IPlayerStatisticService playerStatisticService)
        {
            this.playerStatisticService = playerStatisticService;
        }

        [HttpGet("{matchId}/{teamId}")]
        public ActionResult Get([FromRoute] PlayerStatisticsFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return new JsonResult(this.playerStatisticService.GetPlayersStatistics(model.MatchId, model.TeamId)
                .Select(stats => new PlayerStatisticsDTO()
                {
                    Id = stats.Id,
                    Dribbles = stats.Dribbles,
                    PassAccuracy = stats.PassAccuracy,
                    PlayerName = stats.PlayerName,
                    ShotAccuracy = stats.ShotAccuracy,
                    ShotsOnTarget = stats.ShotsOnTarget,
                    ShotsTaken = stats.ShotsTaken,
                    GoalsCount = stats.GoalsCount,
                    FoulsCount = stats.FoulsCount,
                    PlayerPosition = stats.PlayerPosition
                }));
        }
    }
}
