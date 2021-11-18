using MatchManagementWebAPI.DTOs;
using MatchManagementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementWebAPI.Services
{
    public interface IMatchService
    {

        public IEnumerable<MatchReadDto> GetAllMatches();

        public Match GetMatchById(int id);

        public void PutMatch(int matchId, MatchUpdateDto matchUpdateDto);

        public void DeleteMatch(int id);
        
        void UpdateMatch(Match matchModelFromRepo);

        public MatchReadDto MapMatchToMatchReadDto(Match matchItem);

        public MatchUpdateDto MapMatchToMatchUpdateDto(Match matchItem);

        public MatchReadDto CreateMatch(MatchCreateDto matchCreateDto);

        public Match MapMatchUpdateDtoToMatch(MatchUpdateDto matchToPatchUpdateDTO);
    }
}
