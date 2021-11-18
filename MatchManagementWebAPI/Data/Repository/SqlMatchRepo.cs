using MatchManagementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementWebAPI.Data
{
    public class SqlMatchRepo : IMatchRepo
    {
        private readonly MatchManagementContext _context;

        public SqlMatchRepo(MatchManagementContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void CreateMatch(Match match)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }
            _context.Matches.Add(match);
        }

        public Match GetMatchById(int id)
        {
            return _context.Matches.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Match> GetMatches()
        {
            return _context.Matches.ToList();
        }

        public void UpdateMatch(Match match)
        {
            //No need to implement the update here
        }

        public void DeleteMatch(Match match)
        {
            if (match == null)
            {
                throw new ArgumentNullException(nameof(match));
            }
            _context.Matches.Remove(match);
        }
    }
}
