using AutoMapper;
using Mag.Dtos;
using Mag.Dtos.LoanHistoryDtos;
using Mag.Entities;
using Mag.Repositories.IRepository;
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
        public class LoanHistoryController : Controller
        {
                private readonly ILoanHistoryRepository _loanHistoryRepository;
                private readonly IMapper _mapper;

                public LoanHistoryController(ILoanHistoryRepository loanHistoryRepository,IMapper mapper)
                {
                        this._loanHistoryRepository = loanHistoryRepository;
                        this._mapper = mapper;
                }

                [HttpGet]
                public async Task<ActionResult> GetAllloanHistories()
                {

                        try
                        {
                                var result = await _loanHistoryRepository.GetAllLoanHistoriesAsync();
                                var resultDto = _mapper.Map<IEnumerable<LoanHistoryGetDto>>(result);
                                return Ok(resultDto);
                        }
                        catch (Exception)
                        {
                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr retrieving data from the database");
                        }

                }

                [HttpGet("{Id:int}")]
                public async Task<ActionResult<LoanHistory>> GetloanHistory(int Id)
                {

                        try
                        {
                                var result = await _loanHistoryRepository.GetLoanHistoryAsync(Id);
                                var resultDto = _mapper.Map<LoanHistoryGetIdDto>(result);

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
                public async Task<ActionResult> AddloanHistory(LoanHistoryAddDto loanHistoryAddDto)
                {
                        try
                        {
                                var loanHistory = _mapper.Map<LoanHistory>(loanHistoryAddDto);
                                if (loanHistory == null)
                                {
                                        return BadRequest();
                                }

                                var createdloanHistory = await _loanHistoryRepository.AddLoanHistoryAsync(loanHistory);
                                return CreatedAtAction(nameof(GetloanHistory), new { Id = createdloanHistory.Id },
                                        createdloanHistory);
                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr retrieving data from the database");
                        }

                }

                [HttpPut("{Id:int}")]

                public async Task<ActionResult<LoanHistory>> UpdateloanHistory(int Id, LoanHistoryUpdateDto loanHistoryUpdateDto)
                {
                        try
                        {
                                
                                var loanHistoryToUpdate = await _loanHistoryRepository.GetLoanHistoryAsync(Id);

                                if (loanHistoryToUpdate == null)
                                {
                                        return NotFound($"User with Id={Id} not found");
                                }

                                _mapper.Map(loanHistoryUpdateDto, loanHistoryToUpdate);
                                await _loanHistoryRepository.UpdateLoanHistoryAsync(loanHistoryToUpdate);
                                return NoContent();

                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr updating data");
                        }
                }

                [HttpDelete("{Id:int}")]

                public async Task<ActionResult<LoanHistory>> DeleteloanHistory(int Id)
                {
                        try
                        {
                               
                                var loanHistoryToDelete = await _loanHistoryRepository.GetLoanHistoryAsync(Id);

                                if (loanHistoryToDelete == null)
                                {
                                        return NotFound($"User with Id={Id} not found");
                                }

                                _mapper.Map<LoanHistoryDeleteDto>(loanHistoryToDelete);
                                return await _loanHistoryRepository.DelateLoanHisotryAsync(Id);

                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr deleting data");
                        }
                }
        }
}
