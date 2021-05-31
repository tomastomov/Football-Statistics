using FootballStatistics.Data.Models;
using FootballStatistics.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballStatistics.Models
{
    public class MatchDTO
    {
        public int Id { get; set; }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public DateTime StartTime { get; set; }

        public MatchResult MatchResult { get; set; }

        public int HomeTeamGoalsCount { get; set; }

        public int AwayTeamGoalsCount { get; set; }

        public ICollection<MatchEvent> MatchEvents { get; set; }
    }
}
