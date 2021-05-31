using FootballStatistics.Data.Models;
using FootballStatistics.Services.Implementation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballStatistics.Tests.ServicesTests.PlayerServiceTests
{
    public class GetPlayersByMatchId_Should
    {
        [Test]
        public void ReturnPlayersFromBothTeamsIfTheMatchIdIsValid()
        {
            using var db = Helpers.GetDbContext();

            var team1 = new Team() { Id = 1 };
            var team2 = new Team() { Id = 2 };
            var player1 = new Player { Id = 1, Name = "tester", Team = team1 };
            var player2 = new Player { Id = 2, Name = "tester2", Team = team2 };
            var match = new Match() { Id = 1, HomeTeam = team1, AwayTeam = team2 };

            db.Teams.Add(team1);
            db.Teams.Add(team2);
            db.Players.Add(player1);
            db.Players.Add(player2);
            db.Matches.Add(match);
            db.SaveChanges();

            var service = new PlayerService(db);

            var players = service.GetPlayersByMatchId(1);

            Assert.AreEqual(players.Count(), 2);
        }

        [Test]
        public void ThrowExceptionIfTheMatchIsNotFound()
        {
            using var db = Helpers.GetDbContext();

            var match = new Match() { Id = 1};

            db.Matches.Add(match);
            db.SaveChanges();

            var service = new PlayerService(db);

            Assert.Throws<ArgumentNullException>(() => service.GetPlayersByMatchId(2));
        }
    }
}
