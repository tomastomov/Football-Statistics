using FootballStatistics.Data.Models;
using FootballStatistics.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatistics.Services.Models
{
    public class MatchServiceModel
    {
        public int Id { get; set; }

        public int HomeTeamGoalsCount { get; set; }

        public int AwayTeamGoalsCount { get; set; }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        public DateTime StartTime { get; set; }

        public MatchResult MatchResult { get; set; }

        public ICollection<MatchEvent> MatchEvents { get; set; }
    }
}
