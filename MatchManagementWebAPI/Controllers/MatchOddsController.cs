using AutoMapper;
using MatchManagementWebAPI.Data;
using MatchManagementWebAPI.DTOs;
using MatchManagementWebAPI.Models;
using MatchManagementWebAPI.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchManagementWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchOddsController : ControllerBase
    {
        private readonly IMatchOddService _matchOddService;

        public MatchOddsController(IMatchOddService matchOddService)
        {
            _matchOddService = matchOddService;
        }

        // GET: api/<MatchesController>
        [HttpGet]
        public ActionResult<IEnumerable<MatchOdd>> GetAllMatchOdds()
        {
            return Ok(_matchOddService.GetAllMatchOdds());
        }

        // GET api/<MatchesController>/5
        [HttpGet("{id}",Name = "GetMatchOddById")]
        public ActionResult<MatchOddReadDto> GetMatchOddById(int id)
        {
            var matchOdd = _matchOddService.GetMatchOddById(id);
            if(matchOdd != null)
            {
                return Ok(_matchOddService.MapMatchOddToMatchOddReadDto(matchOdd));
            }
            return NotFound();
        }

        // POST api/<MatchesController>
        [HttpPost]
        public ActionResult<MatchOddReadDto> CreateMatchOdd([FromBody] MatchOddCreateDto matchOddCreateDto)
        {
            var matchOddModel = _matchOddService.MapMatchOddCreateDtoToMatchOdd(matchOddCreateDto);

            if (!_matchOddService.CanAddMatchOdd(matchOddModel.MatchId, matchOddModel.Specifier))
                return NotFound($"Match odd with specifier:{matchOddModel.Specifier} already exists");

            var matchOddReadDto = _matchOddService.CreateMatchOdd(matchOddCreateDto);

            return CreatedAtRoute(nameof(GetMatchOddById), new { Id = matchOddReadDto.Id }, matchOddReadDto);
        }

        // PUT api/<MatchesController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] MatchOddUpdateDto matchOddUpdateDto)
        {
            var matchOddModelFromRepo = _matchOddService.GetMatchOddById(id);
            if (matchOddModelFromRepo == null)
                return NotFound();

            _matchOddService.PutMatchOdd(id, matchOddUpdateDto);

            return NoContent();
        }

        // DELETE api/<MatchesController>/5
        [HttpPatch("{id}")]
        public ActionResult PartialMatchOddUpdate(int id, JsonPatchDocument<MatchOddUpdateDto> patchDocument)
        {
            var matchOddModelFromRepo = _matchOddService.GetMatchOddById(id);
            if (matchOddModelFromRepo == null)
                return NotFound();

            var matchOddToPatch = _matchOddService.MapMatchOddToMatchOddUpdateDto(matchOddModelFromRepo);

            patchDocument.ApplyTo(matchOddToPatch, ModelState);

            if (!TryValidateModel(matchOddToPatch))
                return ValidationProblem(ModelState);

            _matchOddService.PutMatchOdd(id, matchOddToPatch);
            
            return NoContent();
        }

        // DELETE api/<MatchesController>/5
        [HttpDelete("{id}")]
        public ActionResult DeleteMatchOdd(int id)
        {
            var matchOddModelFromRepo = _matchOddService.GetMatchOddById(id);
            if (matchOddModelFromRepo == null)
                return NotFound();

            _matchOddService.DeleteMatchOdd(id);

            return NoContent();
        }
    }
}
