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
    public class MatchesController : ControllerBase
    {
        private readonly IMatchService _matchService;

        public MatchesController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        // GET: api/<MatchesController>
        /// <summary>
        /// Returns all matches.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Match>> GetAllMatches()
        {
            var matchItems = _matchService.GetAllMatches();

            return Ok(matchItems);
        }

        // GET api/<MatchesController>/5
        /// <summary>
        /// Returns a match item by its ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}",Name = "GetMatchById")]
        public ActionResult<MatchReadDto> GetMatchById(int id)
        {
            var matchItem = _matchService.GetMatchById(id);
            if(matchItem != null)
            {
                return Ok(_matchService.MapMatchToMatchReadDto(matchItem));
            }
            return NotFound();
        }

        // POST api/<MatchesController>
        /// <summary>
        /// Creates a match item in the DB
        /// </summary>
        /// <param name="matchCreateDto"></param>
        /// <remarks>
        /// Sample request: (Use this format) 
        /// 
        ///     POST /CreateMatch
        ///     {
        ///        "description": "This is a postman test3",
        ///        "matchDate": "2022-01-01T00:00:00",
        ///        "matchTime": "18:30:00",
        ///        "teamA": "Barcelona",
        ///        "teamB": "Manchester Utd.",
        ///        "sport": "basketball"
        ///     }
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<MatchReadDto> CreateMatch([FromBody] MatchCreateDto matchCreateDto)
        {
            var matchReadDto = _matchService.CreateMatch(matchCreateDto);

            return CreatedAtRoute(nameof(GetMatchById), new { Id = matchReadDto.Id }, matchReadDto);
        }

        // PUT api/<MatchesController>/5
        /// <summary>
        /// Updates the values of a match Item.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="matchUpdateDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] MatchUpdateDto matchUpdateDto)
        {
            var matchModelFromRepo = _matchService.GetMatchById(id);
            if (matchModelFromRepo == null)
                return NotFound();

            _matchService.PutMatch(id,matchUpdateDto);

            return NoContent();
        }

        // DELETE api/<MatchesController>/5
        /// <summary>
        /// Updates a specific value of a match Item.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDocument"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public ActionResult PartialMatchUpdate(int id, JsonPatchDocument<MatchUpdateDto> patchDocument)
        {
            var matchModelFromRepo = _matchService.GetMatchById(id);
            if (matchModelFromRepo == null)
                return NotFound();

            var matchToPatch = _matchService.MapMatchToMatchUpdateDto(matchModelFromRepo);

            patchDocument.ApplyTo(matchToPatch, ModelState);

            if (!TryValidateModel(matchToPatch))
                return ValidationProblem(ModelState);

            _matchService.PutMatch(id,matchToPatch);

            return NoContent();
        }

        // DELETE api/<MatchesController>/5
        /// <summary>
        /// Deletes a Match Item from DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var matchModelFromRepo = _matchService.GetMatchById(id);
            if (matchModelFromRepo == null)
                return NotFound();

            _matchService.DeleteMatch(id);

            return NoContent();
        }
    }
}
