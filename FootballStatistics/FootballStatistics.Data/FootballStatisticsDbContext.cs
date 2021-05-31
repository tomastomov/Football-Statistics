using FootballStatistics.Data.Configurations;
using FootballStatistics.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatistics.Data
{
    public class FootballStatisticsDbContext : DbContext
    {
        public FootballStatisticsDbContext(DbContextOptions<FootballStatisticsDbContext> options) : base (options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new PlayerConfiguration());
            builder.ApplyConfiguration(new MatchConfiguration());
            builder.ApplyConfiguration(new TeamConfiguration());
        }

        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Match> Matches { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<League> Leagues { get; set; }

        public DbSet<MatchEvent> MatchEvents { get; set; }
    }
}
