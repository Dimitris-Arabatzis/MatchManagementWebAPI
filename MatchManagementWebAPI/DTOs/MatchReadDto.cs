using MatchManagementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementWebAPI.DTOs
{
    public class MatchReadDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime MatchDate { get; set; }

        public TimeSpan MatchTime { get; set; }

        public string TeamA { get; set; }

        public string TeamB { get; set; }

        public Sport Sport { get; set; }

        public List<MatchOdd> MatchOdds { get; set; }
    }
}
