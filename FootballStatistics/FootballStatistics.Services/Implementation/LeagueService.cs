using FootballStatistics.Data;
using FootballStatistics.Services.Contracts;
using FootballStatistics.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballStatistics.Services.Implementation
{
    public class LeagueService : ILeagueService
    {
        private readonly FootballStatisticsDbContext db;

        public LeagueService(FootballStatisticsDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<LeagueServiceModel> GetAllLeagues()
            => this.db.Leagues.Select(league => new LeagueServiceModel()
            {
                Id = league.Id,
                Name = league.Name
            });

    }
}
