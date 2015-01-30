using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XML_0129_1008_QuyetNV.Models;

namespace MatchManagement.Models
{
    public interface IMatchRepository
    {
        IEnumerable<Match> GetMatches();
        Match GetMatchByID(String id);
        IEnumerable<Match> GetMatchesByLeagueName(String leagueName);
        void InsertMatch(Match match);
        void DeleteMatch(String id);
        void EditMatch(Match match);
    }
}
