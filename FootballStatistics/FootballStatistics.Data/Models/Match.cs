using FootballStatistics.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatistics.Data.Models
{
    public class Match
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public Team HomeTeam { get; set; }

        public int HomeTeamId { get; set; }

        public Team AwayTeam { get; set; }

        public int AwayTeamId { get; set; }

        public MatchResult MatchResult { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; } = new List<PlayerStatistic>();

        public ICollection<MatchEvent> MatchEvents { get; set; } = new List<MatchEvent>();
    }
}
