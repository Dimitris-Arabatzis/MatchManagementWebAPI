using MatchManagementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementWebAPI.Data
{
    public interface IMatchOddRepo
    {
        bool SaveChanges();

        IEnumerable<MatchOdd> GetMatchOdds();
        MatchOdd GetMatchOddById(int id);
        void CreateMatchOdd(MatchOdd match);
        void UpdateMatchOdd(MatchOdd match);
        void DeleteMatchOdd(MatchOdd match);
        IEnumerable<MatchOdd> GetMatchOddsByMatchId(int id);
    }
}
