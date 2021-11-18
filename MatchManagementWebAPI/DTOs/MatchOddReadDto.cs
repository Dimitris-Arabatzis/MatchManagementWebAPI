using MatchManagementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementWebAPI.DTOs
{
    public class MatchOddReadDto
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("MatchId")]
        public int MatchId { get; set; }
        //public Match Match { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(24)")]
        public Specifier Specifier { get; set; }

        [Required]
        public double Odd { get; set; }
    }
}
