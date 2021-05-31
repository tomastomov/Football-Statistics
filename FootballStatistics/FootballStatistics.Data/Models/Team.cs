using System.Collections;
using System.Collections.Generic;

namespace FootballStatistics.Data.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public League League { get; set; }

        public int LeagueId { get; set; }

        public ICollection<Player> Players { get; set; } = new List<Player>(); 

        public ICollection<Match> HomeMatches { get; set; } = new List<Match>(); 

        public ICollection<Match> AwayMatches { get; set; } = new List<Match>(); 
    }
}