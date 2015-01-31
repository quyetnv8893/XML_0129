using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerManagement.Models;

namespace PlayerManagement.Models
{
    public interface ILeagueRepository
    {
        IEnumerable<League> GetMatches();
        League GetMatchByName(String name);
        void InsertLeague(League league);
        void DeleteLeague(String name);
        void EditLeague(League league);
    }
}
