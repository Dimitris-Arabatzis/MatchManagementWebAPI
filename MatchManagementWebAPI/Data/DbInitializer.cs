using MatchManagementWebAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementWebAPI.Data
{
    public class DbInitializer
    {
        public static void PrepPolulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<MatchManagementContext>());
            }
        }

        public static void SeedData(MatchManagementContext context)
        {
            System.Console.WriteLine("Applying migrations..");

            context.Database.Migrate();
            System.Console.WriteLine("Migrated");

            AddMatchesIfNoExists(context);

            AddMatchOddsIfNoExists(context);

            context.SaveChanges();
        }

        private static void AddMatchesIfNoExists(MatchManagementContext context)
        {
            if (!context.Matches.Any())
            {
                System.Console.WriteLine("Adding data - Table: Matches");
                context.Matches.AddRange(
                    new Match()
                    {
                        Description = "Champions League",
                        MatchDate = new DateTime(2022, 1, 5),
                        MatchTime = new TimeSpan(19, 30, 00),
                        TeamA = "F.C Barcelona",
                        TeamB = "Real Madrid",
                        Sport = Sport.football
                    },
                    new Match()
                    {
                        Description = "Champions League",
                        MatchDate = new DateTime(2022, 2, 7),
                        MatchTime = new TimeSpan(20, 30, 00),
                        TeamA = "Manchester United",
                        TeamB = "Valencia",
                        Sport = Sport.football
                    },
                    new Match()
                    {
                        Description = "Champions League",
                        MatchDate = new DateTime(2022, 1, 5),
                        MatchTime = new TimeSpan(18, 30, 00),
                        TeamA = "Milwaukee Bucks",
                        TeamB = "Los Angeles Lakers",
                        Sport = Sport.basketball
                    }
                );
                context.SaveChanges();
                System.Console.WriteLine("Matches table seeded!");

            }
            else
            {
                System.Console.WriteLine("Matches table already contains data. Not seeding.");
            }
        }
        private static void AddMatchOddsIfNoExists(MatchManagementContext context)
        {
            if (!context.MatchOdds.Any())
            {
                System.Console.WriteLine("Adding data - Table: Match Odds");
                context.MatchOdds.AddRange(
                    new MatchOdd()
                    {
                        MatchId = 1,
                        Specifier = Specifier.HomeTeamWin,
                        Odd = 1.1
                    },
                    new MatchOdd()
                    {
                        MatchId = 1,
                        Specifier = Specifier.GuestTeamWin,
                        Odd = 2
                    },
                    new MatchOdd()
                    {
                        MatchId = 1,
                        Specifier = Specifier.X,
                        Odd = 3.20
                    },
                    new MatchOdd()
                    {
                        MatchId = 2,
                        Specifier = Specifier.HomeTeamWin,
                        Odd = 1.1
                    },
                    new MatchOdd()
                    {
                        MatchId = 2,
                        Specifier = Specifier.GuestTeamWin,
                        Odd = 2
                    },
                    new MatchOdd()
                    {
                        MatchId = 2,
                        Specifier = Specifier.X,
                        Odd = 3.20
                    },
                    new MatchOdd()
                    {
                        MatchId = 3,
                        Specifier = Specifier.HomeTeamWin,
                        Odd = 1.1
                    },
                    new MatchOdd()
                    {
                        MatchId = 3,
                        Specifier = Specifier.GuestTeamWin,
                        Odd = 2
                    },
                    new MatchOdd()
                    {
                        MatchId = 3,
                        Specifier = Specifier.X,
                        Odd = 3.20
                    }
                );
                context.SaveChanges();
                System.Console.WriteLine("Match Odds table seeded!");

            }
            else
            {
                System.Console.WriteLine("Matches table already contains data. Not seeding.");
            }
        }
    }
}
