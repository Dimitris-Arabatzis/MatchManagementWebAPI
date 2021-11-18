using MatchManagementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementWebAPI.DTOs
{
    public class MatchOddUpdateDto
    {
        [Required]
        [ForeignKey("MatchId")]
        [Range(0, Int32.MaxValue, ErrorMessage = "The field MatchId must be greater than zero.")]
        public int MatchId { get; set; }

        [Required]
        public Specifier Specifier { get; set; }

        [Required]
        public double Odd { get; set; }
    }
}
