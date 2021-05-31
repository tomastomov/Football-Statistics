using FootballStatistics.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballStatistics.Services.Contracts
{
    public interface ILeagueService
    {
        IEnumerable<LeagueServiceModel> GetAllLeagues(); 
    }
}
