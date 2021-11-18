using AutoMapper;
using MatchManagementWebAPI.DTOs;
using MatchManagementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementWebAPI.MapperProfiles
{
    public class MatchOddsProfile : Profile
    {
        public MatchOddsProfile()
        {
            CreateMap<MatchOdd, MatchOddReadDto>();
            CreateMap<MatchOddCreateDto, MatchOdd>();
            CreateMap<MatchOddUpdateDto, MatchOdd>().ReverseMap();
        }

        
    }
}
