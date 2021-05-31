using FootballStatistics.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatistics.Services.Contracts
{
    public interface IPlayerService
    {
        IEnumerable<PlayerServiceModel> GetPlayersByMatchId(int matchId);
    }
}
