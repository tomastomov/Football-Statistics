using FootballStatistics.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatistics.Tests
{
    public static class Helpers
    {
        public static FootballStatisticsDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<FootballStatisticsDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new FootballStatisticsDbContext(options);
        }
    }
}
