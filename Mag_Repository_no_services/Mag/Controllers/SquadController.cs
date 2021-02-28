using Mag.Entities;
using Mag.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class SquadController : Controller
        {
                private readonly ISquadRepository _squadRepository;

                public SquadController(ISquadRepository squadRepository)
                {
                        _squadRepository = squadRepository;
                }

                [HttpGet]
                public async Task<ActionResult> GetAllSquads()
                {

                        try
                        {
                                var result = await _squadRepository.GetAllSquadsAsync();
                                return Ok(result);
                        }
                        catch (Exception)
                        {
                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr retrieving data from the database");
                        }

                }

                [HttpGet("{Id:int}")]
                public async Task<ActionResult<Squad>> GetSquad(int Id)
                {

                        try
                        {
                                var result = await _squadRepository.GetSquadAsync(Id);

                                if (result == null)
                                {
                                        return NotFound();
                                }

                                return Ok(result);
                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr retrieving data from the database");
                        }
                }

                [HttpPost]
                public async Task<ActionResult<Squad>> AddSquad(Squad squad)
                {
                        try
                        {
                                if (squad == null)
                                {
                                        return BadRequest();
                                }

                                var createdsquad = await _squadRepository.AddSquadAsync(squad);
                                return CreatedAtAction(nameof(GetSquad), new { Id = createdsquad.Id },
                                        createdsquad);
                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr retrieving data from the database");
                        }

                }

                [HttpPut("{Id:int}")]

                public async Task<ActionResult<Squad>> UpdateSquad(int Id, Squad squad)
                {
                        try
                        {
                                if (Id != squad.Id)
                                {
                                        return BadRequest("User ID missmatch");
                                }
                                var squadToUpdate = await _squadRepository.GetSquadAsync(Id);

                                if (squadToUpdate == null)
                                {
                                        return NotFound($"User with Id={Id} not found");
                                }

                                return await _squadRepository.UpdateSquadAsync(squad);

                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr updating data");
                        }
                }

                [HttpDelete("{Id:int}")]

                public async Task<ActionResult<Squad>> DeleteSquad(int Id, Squad squad)
                {
                        try
                        {
                                if (Id != squad.Id)
                                {
                                        return BadRequest("User ID missmatch");
                                }
                                var squadToDelete = await _squadRepository.GetSquadAsync(Id);

                                if (squadToDelete == null)
                                {
                                        return NotFound($"User with Id={Id} not found");
                                }

                                return await _squadRepository.DelateSquadAsync(Id);

                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr deleting data");
                        }
                }

        }
}
