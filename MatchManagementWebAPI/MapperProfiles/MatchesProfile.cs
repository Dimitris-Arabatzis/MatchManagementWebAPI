using AutoMapper;
using MatchManagementWebAPI.DTOs;
using MatchManagementWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementWebAPI.MapperProfiles
{
    public class MatchesProfile : Profile
    {
        public MatchesProfile()
        {
            CreateMap<Match, MatchReadDto>();
            CreateMap<MatchCreateDto, Match>();
            CreateMap<MatchUpdateDto, Match>().ReverseMap();
        }

        
    }
}
