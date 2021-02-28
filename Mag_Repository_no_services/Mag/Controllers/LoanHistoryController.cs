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

                public LoanHistoryController(ILoanHistoryRepository loanHistoryRepository)
                {
                        this._loanHistoryRepository = loanHistoryRepository;
                }

                [HttpGet]
                public async Task<ActionResult> GetAllloanHistories()
                {

                        try
                        {
                                var result = await _loanHistoryRepository.GetAllLoanHistoriesAsync();
                                return Ok(result);
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
                public async Task<ActionResult<LoanHistory>> AddloanHistory(LoanHistory loanHistory)
                {
                        try
                        {
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

                public async Task<ActionResult<LoanHistory>> UpdateloanHistory(int Id, LoanHistory loanHistory)
                {
                        try
                        {
                                if (Id != loanHistory.Id)
                                {
                                        return BadRequest("User ID missmatch");
                                }
                                var userToUpdate = await _loanHistoryRepository.GetLoanHistoryAsync(Id);

                                if (userToUpdate == null)
                                {
                                        return NotFound($"User with Id={Id} not found");
                                }

                                return await _loanHistoryRepository.UpdateLoanHistoryAsync(loanHistory);

                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr updating data");
                        }
                }

                [HttpDelete("{Id:int}")]

                public async Task<ActionResult<LoanHistory>> DeleteloanHistory(int Id, LoanHistory loanHistory)
                {
                        try
                        {
                                if (Id != loanHistory.Id)
                                {
                                        return BadRequest("User ID missmatch");
                                }
                                var loanHistoryToDelete = await _loanHistoryRepository.GetLoanHistoryAsync(Id);

                                if (loanHistoryToDelete == null)
                                {
                                        return NotFound($"User with Id={Id} not found");
                                }

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
