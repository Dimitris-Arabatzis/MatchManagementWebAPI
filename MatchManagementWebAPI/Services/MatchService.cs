using AutoMapper;
using MatchManagementWebAPI.Data;
using MatchManagementWebAPI.DTOs;
using MatchManagementWebAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementWebAPI.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepo _matchRepo;       
        private readonly IMapper _mapper;
        private readonly IMatchOddRepo _matchOddRepo;

        public MatchService(IMatchRepo matchRepo, IMapper mapper, IMatchOddRepo matchOddRepo)
        {
            _matchRepo = matchRepo;
            _mapper = mapper;
            _matchOddRepo = matchOddRepo;
        }

        public IEnumerable<MatchReadDto> GetAllMatches()
        {

            var matchItems = _matchRepo.GetMatches();
            foreach (var match in matchItems)
            {
                match.MatchOdds = _matchOddRepo.GetMatchOdds().Where(x => x.MatchId == match.Id).ToList();
            }

            return (_mapper.Map<IEnumerable<MatchReadDto>>(matchItems));
        }

        public Match GetMatchById(int id)
        {
            var match = _matchRepo.GetMatchById(id);
            match.MatchOdds = _matchOddRepo.GetMatchOdds().Where(x => x.MatchId == match.Id).ToList();
            return (match);
        }

        public MatchReadDto CreateMatch(MatchCreateDto matchCreateDto)
        {
            var matchModel = _mapper.Map<Match>(matchCreateDto);
            _matchRepo.CreateMatch(matchModel);
            _matchRepo.SaveChanges();

            return (_mapper.Map<MatchReadDto>(matchModel));
        }

        public void PutMatch(int matchId, MatchUpdateDto matchUpdateDto)
        {
            var matchModelFromRepo = _matchRepo.GetMatchById(matchId);
            if (matchModelFromRepo == null)
                return;

            var matchModelToUpdate = _mapper.Map(matchUpdateDto, matchModelFromRepo);

            _matchRepo.UpdateMatch(matchModelToUpdate);

            _matchRepo.SaveChanges();

        }

        public void DeleteMatch(int id)
        {
            var matchModelFromRepo = _matchRepo.GetMatchById(id);
            if (matchModelFromRepo == null)
                return;

            _matchRepo.DeleteMatch(matchModelFromRepo);
            _matchRepo.SaveChanges();
        }

        public MatchReadDto MapMatchToMatchReadDto(Match matchItem)
        {
            return (_mapper.Map<MatchReadDto>(matchItem));
        }

        public MatchUpdateDto MapMatchToMatchUpdateDto(Match matchItem)
        {
            return (_mapper.Map<MatchUpdateDto>(matchItem));
        }

        public Match MapMatchUpdateDtoToMatch(MatchUpdateDto matchUpdateDto)
        {
            return (_mapper.Map<Match>(matchUpdateDto));
        }

        public void UpdateMatch(Match matchModelFromRepo)
        {
            _matchRepo.UpdateMatch(matchModelFromRepo);

            _matchRepo.SaveChanges();
        }


    }
}
