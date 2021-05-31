using FootballStatistics.Data;
using FootballStatistics.Services.Contracts;
using FootballStatistics.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace FootballStatistics.Services.Implementation
{
    public class MatchService : IMatchService
    {
        private readonly FootballStatisticsDbContext db;
        public MatchService(FootballStatisticsDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<MatchServiceModel> GetMatches(int leagueId, DateTime date)
            => this.db.Matches.Where(m => m.StartTime.Day == date.Day && m.HomeTeam.LeagueId == leagueId)
                .Select(m => new MatchServiceModel
                {
                    Id = m.Id,
                    HomeTeam = m.HomeTeam,
                    AwayTeam = m.AwayTeam,
                    MatchEvents = m.MatchEvents,
                    MatchResult = m.MatchResult,
                    StartTime = m.StartTime,
                    AwayTeamGoalsCount = m.MatchEvents.Count(me => m.AwayTeam.Players.Contains(me.Player)),
                    HomeTeamGoalsCount = m.MatchEvents.Count(me => m.HomeTeam.Players.Contains(me.Player))
                });
    }
}
