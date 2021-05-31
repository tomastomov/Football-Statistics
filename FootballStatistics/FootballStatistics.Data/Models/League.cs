﻿using System.Collections.Generic;

namespace FootballStatistics.Data.Models
{
    public class League
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}