using FootballStatistics.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatistics.Data.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int Number { get; set; }

        public PlayerPosition PlayerPosition { get; set; }

        public Team Team { get; set; }

        public int TeamId { get; set; }

        public ICollection<PlayerStatistic> PlayerStatistics { get; set; } = new List<PlayerStatistic>();

        public ICollection<MatchEvent> MatchEvents { get; set; } = new List<MatchEvent>(); 
    }
}
