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
    [Route("players")]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService playerService;
        public PlayerController(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        [HttpGet]
        public ActionResult Get(int matchId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return new JsonResult(this.playerService.GetPlayersByMatchId(matchId)
                .Select(p => new PlayerDTO
                {
                    Id = p.Id,
                    Name = p.Name
                }));
        }
    }
}
