using FootballStatistics.Data;
using FootballStatistics.Services.Contracts;
using FootballStatistics.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using FootballStatistics.Data.Models.Enums;

namespace FootballStatistics.Services.Implementation
{
    public class PlayerStatisticService : IPlayerStatisticService
    {
        private readonly FootballStatisticsDbContext db;
        public PlayerStatisticService(FootballStatisticsDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<PlayerStatisticServiceModel> GetPlayersStatistics(int matchId, int teamId)
            => this.db.PlayerStatistics.Include(m => m.Match).Include(d => d.Player.MatchEvents).Where(p => p.MatchId == matchId && p.Player.TeamId == teamId)
                .Select(stats => new PlayerStatisticServiceModel()
                {
                    Id = stats.Id,
                    Dribbles = stats.Dribbles,
                    PassAccuracy = stats.PassAccuracy,
                    PlayerName = stats.Player != null ? stats.Player.Name : null,
                    ShotAccuracy = stats.ShotAccuracy,
                    ShotsOnTarget = stats.ShotsOnTarget,
                    ShotsTaken = stats.ShotsTaken,
                    PlayerPosition = stats.Player.PlayerPosition.ToString(),
                    GoalsCount = stats.Player.MatchEvents.Count(m => m.MatchId == matchId && m.MatchEventType == MatchEventType.Goal),
                    FoulsCount = stats.Player.MatchEvents.Count(m => m.MatchId == matchId && m.MatchEventType == MatchEventType.Foul)
                });
    }
}
