using MatchManagementWebAPI.DTOs;
using MatchManagementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementWebAPI.Services
{
    public interface IMatchOddService
    {
        public IEnumerable<MatchOddReadDto> GetAllMatchOdds();

        public MatchOdd GetMatchOddById(int id);

        public void PutMatchOdd(int matchOddId, MatchOddUpdateDto matchOddUpdateDto);

        public void DeleteMatchOdd(int id);
        
        void UpdateMatchOdd(MatchOdd matchOddModelFromRepo);

        public MatchOddReadDto MapMatchOddToMatchOddReadDto(MatchOdd matchOddItem);

        public MatchOddUpdateDto MapMatchOddToMatchOddUpdateDto(MatchOdd matchOddItem);

        public MatchOddReadDto CreateMatchOdd(MatchOddCreateDto matchOddCreateDto);

        public MatchOdd MapMatchOddUpdateDtoToMatchOdd(MatchOddUpdateDto matchOddToPatchUpdateDTO);

        public MatchOdd MapMatchOddCreateDtoToMatchOdd(MatchOddCreateDto matchOddCreateDto);

        public bool CanAddMatchOdd(int id, Specifier specifier);

    }
}
