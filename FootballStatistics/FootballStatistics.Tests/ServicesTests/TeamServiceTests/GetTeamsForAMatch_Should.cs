using FootballStatistics.Data.Models;
using FootballStatistics.Services.Implementation;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballStatistics.Tests.ServicesTests.TeamServiceTests
{
    public class GetTeamsForAMatch_Should
    {
        [Test]
        public void ReturnTwoTeamsIfTheMatchExists()
        {
            using var db = Helpers.GetDbContext();

            var team1 = new Team() { Id = 1, Name = "Real Madrid" };
            var team2 = new Team() { Id = 2, Name = "Barcelona" };
            var match = new Match() { Id = 1, HomeTeam = team1, AwayTeam = team2 };

            db.Teams.Add(team1);
            db.Teams.Add(team2);
            db.Matches.Add(match);
            db.SaveChanges();

            var service = new TeamService(db);

            var teams = service.GetTeamsForAMatch(1);

            Assert.AreEqual(teams.Count(), 2);
        }

        [Test]
        public void ThrowExceptionIfTheMatchDoesntExist()
        {
            using var db = Helpers.GetDbContext();

            var match = new Match() { Id = 1 };
            db.Matches.Add(match);
            db.SaveChanges();

            var service = new TeamService(db);

            Assert.Throws<ArgumentNullException>(() => service.GetTeamsForAMatch(2));
        }
    }
}
