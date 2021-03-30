using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mag.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class SquadController : Controller
        {
                private readonly ISquadRepository _squadRepository;
                private readonly IMapper _mapper;

                public SquadController(ISquadRepository squadRepository,IMapper mapper)
                {
                        this._squadRepository = squadRepository;
                        this._mapper = mapper;
                }

                [HttpGet]
                public async Task<ActionResult> GetAllSquads()
                {

                        try
                        {
                                var result = await _squadRepository.GetAllSquadsAsync();
                                var resultDto = _mapper.Map<IEnumerable<SquadGetDto>>(result);
                                return Ok(resultDto);
                        }
                        catch (Exception)
                        {
                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr retrieving data from the database");
                        }

                }

                [HttpGet("{Id:int}")]
                public async Task<ActionResult<SquadGetIdDto>> GetSquad(int Id)
                {

                        try
                        {
                                var result = await _squadRepository.GetSquadAsync(Id);
                                var resultDto = _mapper.Map<SquadGetIdDto>(result);

                                if (result == null)
                                {
                                        return NotFound();
                                }

                                return Ok(resultDto);
                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr retrieving data from the database");
                        }
                }

                [HttpPost]
                public async Task<ActionResult> AddSquad(SquadAddDto squadAddDto)
                {

                        try
                        {
                                var squad = _mapper.Map<Squad>(squadAddDto);
                                if (squad == null)
                                {
                                        return BadRequest();
                                }

                                var createdsquad = await _squadRepository.AddSquadAsync(squad);
                                return CreatedAtAction(nameof(GetSquad), new { Id = createdsquad.Id },
                                        createdsquad);
                        }
                        catch (Exception e)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr adding data to the database");
                        }

                }

                [HttpPut("{Id:int}")]

                public async Task<ActionResult<Squad>> UpdateSquad(int Id, SquadUpdateDto squadUpdateDto)
                {
                        try
                        {                                
                                var squadToUpdate = await _squadRepository.GetSquadAsync(Id);
                                if (squadToUpdate == null)
                                {
                                        return NotFound($"User with Id={Id} not found");
                                }

                                _mapper.Map(squadUpdateDto, squadToUpdate);
                                await _squadRepository.UpdateSquadAsync(squadToUpdate);
                                return NoContent();

                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr updating data");
                        }
                }

                [HttpDelete("{Id:int}")]

                public async Task<ActionResult<Squad>> DeleteSquad(int Id)
                {
                        try
                        {
                                
                                var squadToDelete = await _squadRepository.GetSquadAsync(Id);
                                if (squadToDelete == null)
                                {
                                        return NotFound($"User with Id={Id} not found");
                                }
                                _mapper.Map<SquadDeleteDto>(squadToDelete);
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
