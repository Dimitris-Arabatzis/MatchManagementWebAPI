using MatchManagementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementWebAPI.Data
{
    public interface IMatchRepo
    {
        bool SaveChanges();

        IEnumerable<Match> GetMatches();
        Match GetMatchById(int id);
        void CreateMatch(Match match);
        void UpdateMatch(Match match);
        void DeleteMatch(Match match);

    }
}
