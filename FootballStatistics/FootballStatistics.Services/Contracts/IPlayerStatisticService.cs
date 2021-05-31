using FootballStatistics.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatistics.Services.Contracts
{
    public interface IPlayerStatisticService
    {
        IEnumerable<PlayerStatisticServiceModel> GetPlayersStatistics(int teamId, int playerId);
    }
}
