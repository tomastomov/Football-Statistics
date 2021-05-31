using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballStatistics.Models
{
    public class PlayerStatisticsDTO
    {
        public int Id { get; set; }

        public string PlayerName { get; set; }

        public int Dribbles { get; set; }

        public decimal PassAccuracy { get; set; }

        public decimal ShotAccuracy { get; set; }

        public int ShotsTaken { get; set; }

        public int ShotsOnTarget { get; set; }

        public string PlayerPosition { get; set; }

        public int GoalsCount { get; set; }

        public int FoulsCount { get; set; }
    }
}
