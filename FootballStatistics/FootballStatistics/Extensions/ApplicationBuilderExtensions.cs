using FootballStatistics.Data;
using FootballStatistics.Data.Models;
using FootballStatistics.Data.Models.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballStatistics.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UpdateDatabase(this IApplicationBuilder builder)
        {
            using var scope = builder.ApplicationServices.CreateScope();

            var context = scope.ServiceProvider.GetService<FootballStatisticsDbContext>();

            context.Database.Migrate();

            var laLiga = new League() { Name = "La Liga Santander" };
            var premierLeague = new League() { Name = "Premier League"};

            context.Leagues.Add(laLiga);
            context.Leagues.Add(premierLeague);

            var realMadrid = new Team() { Name = "Real Madrid", League = laLiga };
            var barcelona = new Team() { Name = "Barcelona", League = laLiga };
            var athleticoMadrid = new Team() { Name = "Atletico Madrid", League = laLiga };
            var chelsea = new Team() { Name = "Chelsea", League = premierLeague };
            var liverpool = new Team() { Name = "Liverpool", League = premierLeague };

            var laligaTeams = new List<Team>() { realMadrid, barcelona};
            var premierLeagueTeams = new List<Team>() { chelsea, liverpool };

            laLiga.Teams.Add(realMadrid);
            laLiga.Teams.Add(barcelona);
            laligaTeams.Add(athleticoMadrid);
            premierLeague.Teams.Add(chelsea);
            premierLeague.Teams.Add(liverpool);

            var random = new Random();

            laligaTeams.ForEach(SeedPlayers);
            premierLeagueTeams.ForEach(SeedPlayers);

            var laligaMatch = GenerateMatch(realMadrid, barcelona);
            var premierLeagueMatch = GenerateMatch(chelsea, liverpool);
            var laligaMatch2 = GenerateMatch(barcelona, athleticoMadrid);

            context.Matches.Add(laligaMatch);
            context.Matches.Add(premierLeagueMatch);
            context.Matches.Add(laligaMatch2);

            GenerateMatchEvents(laligaMatch, realMadrid, barcelona, random, context);
            GenerateMatchEvents(premierLeagueMatch, chelsea, liverpool, random, context);
            GenerateMatchEvents(laligaMatch2, athleticoMadrid, barcelona, random, context);

            context.SaveChanges();
        }

        private static Match GenerateMatch(Team homeTeam, Team awayTeam)
        {
            return new Match() { HomeTeam = homeTeam, AwayTeam = awayTeam, MatchResult = MatchResult.TBD, StartTime = DateTime.UtcNow };
        }

        private static void GenerateMatchEvents(Match match, Team homeTeam, Team awayTeam, Random random, FootballStatisticsDbContext context)
        {
            foreach (var player in homeTeam.Players.Concat(awayTeam.Players))
            {
                context.MatchEvents.Add(new MatchEvent() { Match = match, HappenedOn = DateTime.UtcNow, MatchEventType = player.PlayerPosition == PlayerPosition.Attacker ?  MatchEventType.Goal : MatchEventType.Foul, Player = player });

                context.PlayerStatistics.Add(new PlayerStatistic() { Dribbles = random.Next(100), PassAccuracy = 0.35m, ShotsOnTarget = random.Next(50), ShotAccuracy = 0.25m, ShotsTaken = random.Next(40), Player = player, Match = match });
            }
        }

        private static void SeedPlayers(Team team)
        {
            for (int i = 0; i < 11; i++)
            {
                team.Players.Add(new Player() { Name = $"{team.Name} player {i}", Age = 20 + i, Number = i, PlayerPosition = i % 2 == 0 ? PlayerPosition.Attacker : PlayerPosition.Defender, Team = team });
            }
        }
    }
}
