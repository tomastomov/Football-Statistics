using FootballStatistics.Data;
using FootballStatistics.Data.Models;
using FootballStatistics.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballStatistics.Tests.ServicesTests.LeagueServiceTests
{
    public class GetAllLeagues_Should
    {
        [Test]
        public void ReturnAllLeagues()
        {
           using var db = Helpers.GetDbContext();

            var laliga = new League() {Id = 1, Name = "La Liga" };
            var premierLeague = new League() { Id= 2, Name = "Premier League" };

            db.Leagues.Add(laliga);
            db.Leagues.Add(premierLeague);

            db.SaveChanges();

            var service = new LeagueService(db);

            var leagues = service.GetAllLeagues().ToList();

            Assert.AreEqual(leagues.Count, 2);
            Assert.AreEqual(leagues.FirstOrDefault().Id, laliga.Id);
            Assert.AreEqual(leagues.Skip(1).FirstOrDefault().Id, premierLeague.Id);
        }

        [Test]
        public void ReturnEmptyEnumerableWhenThereAreNoLeagues()
        {
            using var db = Helpers.GetDbContext();

            var service = new LeagueService(db);

            var leagues = service.GetAllLeagues().ToList();

            Assert.AreEqual(leagues.Count, 0);
        }
    }
}
