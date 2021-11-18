using MatchManagementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementWebAPI.Data
{
    public class MockMatchRepo : IMatchRepo
    {
        public void CreateMatch(Match match)
        {
            throw new NotImplementedException();
        }

        public void DeleteMatch(Match match)
        {
            throw new NotImplementedException();
        }

        public Match GetMatchById(int id)
        {
            return new Match { Id = id, 
                Description = "Test Match", 
                MatchDate = new DateTime(2022, 1, 1), 
                MatchTime = new TimeSpan(18, 30, 0), 
                Sport = Sport.basketball,
                TeamA = "Barcelona",
                TeamB = "Manchester Utd.",
            };
            
        }

        public IEnumerable<Match> GetMatches()
        {
            var mathes = new List<Match>
            {
                    new Match { Id = 0,
                    Description = "Test Match 1",
                    MatchDate = new DateTime(2022, 1, 1),
                    MatchTime = new TimeSpan(18, 30, 0),
                    Sport = Sport.football,
                    TeamA = "Barcelona",
                    TeamB = "Manchester Utd.",
                },
                new Match
                {
                    Id = 1,
                    Description = "Test Match 2",
                    MatchDate = new DateTime(2022, 1, 2),
                    MatchTime = new TimeSpan(20, 45, 0),
                    Sport = Sport.basketball,
                    TeamA = "PANATHINAIKOS",
                    TeamB = "OLYMPIACOS",
                },
                new Match
                {
                    Id = 2,
                    Description = "Test Match 3",
                    MatchDate = new DateTime(2022, 1, 3),
                    MatchTime = new TimeSpan(21, 00, 0),
                    Sport = Sport.football,
                    TeamA = "PAOK",
                    TeamB = "AEK",
                }
            };

            return mathes;
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateMatch(Match match)
        {
            throw new NotImplementedException();
        }
    }
}
