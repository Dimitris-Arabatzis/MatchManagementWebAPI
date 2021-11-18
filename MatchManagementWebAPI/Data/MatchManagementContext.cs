using MatchManagementWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementWebAPI.Data
{
    public class MatchManagementContext : DbContext
    {
        public MatchManagementContext(DbContextOptions<MatchManagementContext> opt) : base(opt)
        {

        }

        public DbSet<Match> Matches { get; set; }
        public DbSet<MatchOdd> MatchOdds { get; set; }

    }
}
