using FootballStatistics.Data;
using FootballStatistics.Services.Contracts;
using FootballStatistics.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballStatistics.Services.Implementation
{
    public class PlayerService : IPlayerService
    {
        private readonly FootballStatisticsDbContext db;
        public PlayerService(FootballStatisticsDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<PlayerServiceModel> GetPlayersByMatchId(int matchId)
        {
            var match = this.db.Matches.SingleOrDefault(m => m.Id == matchId);

            if (match == null)
            {
                throw new ArgumentNullException($"No match with id: {matchId} exists");
            }

            return this.db.Players.Where(p => p.Team.HomeMatches.Contains(match) || p.Team.AwayMatches.Contains(match))
                .Select(p => new PlayerServiceModel
                {
                    Id = p.Id,
                    Name = p.Name
                });
        }
    }
}
