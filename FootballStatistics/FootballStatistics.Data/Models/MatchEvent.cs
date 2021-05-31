using FootballStatistics.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatistics.Data.Models
{
    public class MatchEvent
    {
        public int Id { get; set; }

        public MatchEventType MatchEventType { get; set; }

        public DateTime HappenedOn { get; set; }

        public Player Player { get; set; }

        public int PlayerId { get; set; }

        public Match Match { get; set; }

        public int MatchId { get; set; }
    }
}
