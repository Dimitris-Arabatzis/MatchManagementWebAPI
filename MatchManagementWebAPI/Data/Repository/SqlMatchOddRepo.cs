using MatchManagementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementWebAPI.Data
{
    public class SqlMatchOddRepo : IMatchOddRepo
    {
        private readonly MatchManagementContext _context;

        public SqlMatchOddRepo(MatchManagementContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void CreateMatchOdd(MatchOdd matchOdd)
        {
            if (matchOdd == null)
            {
                throw new ArgumentNullException(nameof(matchOdd));
            }
            _context.MatchOdds.Add(matchOdd);
        }

        public MatchOdd GetMatchOddById(int id)
        {
            return _context.MatchOdds.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<MatchOdd> GetMatchOdds()
        {
            return _context.MatchOdds.ToList();
        }

        public void UpdateMatchOdd(MatchOdd matchOdd)
        {
            //No need to implement the update here
        }

        public void DeleteMatchOdd(MatchOdd matchOdd)
        {
            if (matchOdd == null)
            {
                throw new ArgumentNullException(nameof(matchOdd));
            }
            _context.MatchOdds.Remove(matchOdd);
        }

        public IEnumerable<MatchOdd> GetMatchOddsByMatchId(int id)
        {
            return _context.MatchOdds.Where(x => x.MatchId == id).ToList();            
        }
    }
}
