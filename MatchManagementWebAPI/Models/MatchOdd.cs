using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementWebAPI.Models
{
    public class MatchOdd
    {
        /// <summary>
        /// Odd Id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Represents the matchID this odd is associated with.
        /// </summary>
        [Required]
        public int MatchId { get; set; }

        /// <summary>
        /// Represents the result of the match that this odd is about. 
        /// Example: Home Team Wins / Tie / Guest team wins.
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(24)")]
        public Specifier Specifier { get; set; }

        /// <summary>
        /// The actual odd number.
        /// </summary>
        [Required]
        public double Odd { get; set; }
    }

    public enum Specifier
    {
        HomeTeamWin,
        X,
        GuestTeamWin
    }
}
