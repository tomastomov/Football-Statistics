using FootballStatistics.Data;
using FootballStatistics.Services.Contracts;
using FootballStatistics.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballStatistics.Services.Implementation
{
    public class TeamService : ITeamService
    {
        private readonly FootballStatisticsDbContext db;

        public TeamService(FootballStatisticsDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<TeamServiceModel> GetTeamsForAMatch(int matchId)
        {
            var match = this.db.Matches.FirstOrDefault(m => m.Id == matchId);

            if (match == null)
            {
                throw new ArgumentNullException($"No match with id {matchId} found");
            }

            return this.db.Teams.Where(team => team.HomeMatches.Contains(match) || team.AwayMatches.Contains(match))
                .Select(team => new TeamServiceModel
                {
                    Id = team.Id,
                    Name = team.Name
                });
        }
    }
}
