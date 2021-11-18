using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementWebAPI.Models
{
    public class Match
    {
        /// <summary>
        /// Match ID
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Description of the match
        /// </summary>
        [MaxLength(250)]
        public string Description { get; set; }

        /// <summary>
        /// What date will the match be played
        /// </summary>
        /// <example>12/01/2022</example>
        [Required]
        [Column(TypeName = "Date")]
        public DateTime MatchDate { get; set; }

        /// <summary>
        /// What time will the match be played
        /// </summary>
        /// <example>18:30</example>
        [Required]
        [Column(TypeName = "bigint")]
        public TimeSpan MatchTime { get; set; }

        /// <summary>
        /// Name of Home team
        /// </summary>
        [Required]
        public string TeamA { get; set; }

        /// <summary>
        /// Name of Guest Team
        /// </summary>
        [Required]
        public string TeamB { get; set; }

        /// <summary>
        /// Represents the type of sport. Example: Football, Basketball etc.
        /// </summary>
        [Required]
        [Column(TypeName = "nvarchar(24)")]
        public Sport Sport { get; set; }

        public List<MatchOdd> MatchOdds { get; set; }
    }

    
    public enum Sport
    {
        football,
        basketball
    }
}
