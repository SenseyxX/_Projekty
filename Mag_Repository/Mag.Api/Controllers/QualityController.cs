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
        public class QualityController:Controller
        {
                private readonly IQualityRepository _qualityRepository;
                private readonly IMapper _mapper;

                public QualityController(IQualityRepository qualityRepository,IMapper mapper )
                {
                        this._qualityRepository = qualityRepository;
                        this._mapper = mapper;
                }

                [HttpGet]
                public async Task<ActionResult> GetQualityUsers()
                {

                        try
                        {
                                var result = await _qualityRepository.GetAllQualityAsync();
                                var resultDto = _mapper.Map<IEnumerable<QualityGetDto>>(result);
                                return Ok(resultDto);
                        }
                        catch (Exception)
                        {
                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr retrieving data from the database");
                        }

                }

                [HttpGet("{Id:int}")]
                public async Task<ActionResult<QualityGetIdDto>> GetUser(int Id)
                {

                        try
                        {
                                var result = await _qualityRepository.GetQualityAsync(Id);
                                var resultDto = _mapper.Map<QualityGetIdDto>(result);

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
        }

}
