using MatchManagementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementWebAPI.DTOs
{
    public class MatchCreateDto
    {
        [MaxLength(250)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime MatchDate { get; set; }

        [Required]
        [Column(TypeName = "bigint")]
        public TimeSpan MatchTime { get; set; }

        [Required]
        public string TeamA { get; set; }

        [Required]
        public string TeamB { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(24)")]
        public Sport Sport { get; set; }
    }
}
