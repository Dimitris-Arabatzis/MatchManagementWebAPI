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
    public class MatchOddService : IMatchOddService
    {
        private readonly IMatchOddRepo _matchOddRepo;
        private readonly IMapper _mapper;
        private readonly IMatchRepo _matchRepo;
        private readonly IMatchService _matchService;

        public MatchOddService(IMatchOddRepo matchOddRepo, IMapper mapper, IMatchRepo matchRepo, IMatchService matchService)
        {
            _matchOddRepo = matchOddRepo;
            _mapper = mapper;
            _matchRepo = matchRepo;
            _matchService = matchService;
        }

        public IEnumerable<MatchOddReadDto> GetAllMatchOdds()
        {
            var matchOddItems = _matchOddRepo.GetMatchOdds();
            //foreach (var matchOdd in matchOddItems)
            //{
            //    matchOdd.Match = _matchRepo.GetMatchById(matchOdd.MatchId);
            //}
            return (_mapper.Map<IEnumerable<MatchOddReadDto>>(matchOddItems));
        }

        public MatchOdd GetMatchOddById(int id)
        {
            var matchOdd = _matchOddRepo.GetMatchOddById(id);
            //if (matchOdd != null)
            //{
            //    matchOdd.Match = _matchService.GetMatchById(matchOdd.MatchId);
            //}
            return (matchOdd);
        }

        public MatchOddReadDto CreateMatchOdd(MatchOddCreateDto matchOddCreateDto)
        {
            var matchOddModel = _mapper.Map<MatchOdd>(matchOddCreateDto);
            _matchOddRepo.CreateMatchOdd(matchOddModel);
            _matchOddRepo.SaveChanges();

            return (_mapper.Map<MatchOddReadDto>(matchOddModel));
        }

        public void PutMatchOdd(int matchOddId, MatchOddUpdateDto matchOddUpdateDto)
        {
            var matchOddModelFromRepo = _matchOddRepo.GetMatchOddById(matchOddId);
            if (matchOddModelFromRepo == null)
                return;

            var matchOddModelToUpdate = _mapper.Map(matchOddUpdateDto, matchOddModelFromRepo);

            _matchOddRepo.UpdateMatchOdd(matchOddModelToUpdate);

            _matchOddRepo.SaveChanges();

        }

        public void DeleteMatchOdd(int id)
        {
            var matchOddModelFromRepo = _matchOddRepo.GetMatchOddById(id);
            if (matchOddModelFromRepo == null)
                return;

            _matchOddRepo.DeleteMatchOdd(matchOddModelFromRepo);
            _matchOddRepo.SaveChanges();
        }

        public MatchOddReadDto MapMatchOddToMatchOddReadDto(MatchOdd matchOddItem)
        {
            return (_mapper.Map<MatchOddReadDto>(matchOddItem));
        }

        public MatchOddUpdateDto MapMatchOddToMatchOddUpdateDto(MatchOdd matchOddItem)
        {
            return (_mapper.Map<MatchOddUpdateDto>(matchOddItem));
        }

        public MatchOdd MapMatchOddUpdateDtoToMatchOdd(MatchOddUpdateDto matchOddUpdateDto)
        {
            return (_mapper.Map<MatchOdd>(matchOddUpdateDto));
        }

        public MatchOdd MapMatchOddCreateDtoToMatchOdd(MatchOddCreateDto matchOddToPatchUpdateDTO)
        {
            return (_mapper.Map<MatchOdd>(matchOddToPatchUpdateDTO));
        }

        public void UpdateMatchOdd(MatchOdd matchOddModelFromRepo)
        {
            _matchOddRepo.UpdateMatchOdd(matchOddModelFromRepo);

            _matchOddRepo.SaveChanges();
        }


        /// <summary>
        /// Gets a match by ID and checks if it already has all 3 odds (HomeTeamWins, X, GuestTeamWins) 
        ///  or the odd currently beeing added associated with it.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool CanAddMatchOdd(int id, Specifier specifier)
        {
            var matchOdds = _matchOddRepo.GetMatchOddsByMatchId(id);

            if (matchOdds.FirstOrDefault(x => x.Specifier == specifier) != null)
            {
                return false;//Cannot add match odd as it already exist.
            }

            return true;
        }

    }
}
