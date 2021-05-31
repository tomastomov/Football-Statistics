using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatistics.Data.Models
{
    public class PlayerStatistic
    {
        public int Id { get; set; }

        public int Dribbles { get; set; }

        public decimal PassAccuracy { get; set; }

        public decimal ShotAccuracy { get; set; }

        public int ShotsTaken { get; set; }

        public int ShotsOnTarget { get; set; }

        public Player Player { get; set; }

        public int PlayerId { get; set; }

        public Match Match { get; set; }

        public int MatchId { get; set; }
    }
}
