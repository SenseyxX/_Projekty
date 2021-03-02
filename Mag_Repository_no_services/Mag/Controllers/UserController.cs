using Mag.Dtos;
using Mag.Entities;
using Mag.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mag.Services;
using AutoMapper;
using Mag.Dtos.UserDtos;

namespace Mag.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public sealed class UserController : Controller
        {
                private readonly IUserRepository _userRepository;
                private readonly IMapper _mapper;

                public UserController(IUserRepository userRepository,IMapper mapper)
                {
                        this._userRepository = userRepository;
                        this._mapper = mapper;
                }

                [HttpGet]
                public async Task<ActionResult> GetAllUsers()
                {

                        try
                        {
                                var result = await _userRepository.GetAllUsersAsync();
                                var resultDto = _mapper.Map<IEnumerable<UserGetDto>>(result);
                                return Ok(resultDto);
                        }
                        catch (Exception)
                        {
                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr retrieving data from the database");
                        }

                }

                [HttpGet("{Id:int}")]
                public async Task<ActionResult<UserGetDto>> GetUser(int Id)
                {

                        try
                        {
                                var result = await _userRepository.GetUserAsync(Id);
                                var resultDto = _mapper.Map<UserGetDto>(result);

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
                public async Task<ActionResult> AddUser(UserGetDto userDto)
                {
                        var user = _mapper.Map<User>(userDto);
                        try
                        {
                                if (user == null)
                                {
                                        return BadRequest();
                                }

                                var createdUser = await _userRepository.AddUserAsync(user);
                                return CreatedAtAction(nameof(GetUser), new { Id = createdUser.Id },
                                        createdUser);
                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr retrieving data from the database");
                        }

                }

                [HttpPut("{Id:int}")]// Dodać Mapper do http put
                public async Task<ActionResult<User>> UpdateUser(int Id, UserGetDto userDto)
                {
                        try
                        {
                                if (Id != userDto.Id)
                                {
                                        return BadRequest("User ID missmatch");
                                }

                                var userToUpdate = await _userRepository.GetUserAsync(Id);

                                if (userToUpdate == null)
                                {
                                        return NotFound($"User with Id={Id} not found");
                                }

                                _mapper.Map(userDto, userToUpdate);
                                await _userRepository.UpdateUserAsync(userToUpdate);
                                return NoContent(); 

                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr updating data");
                        }
                }

                [HttpDelete("{Id:int}")] //Dodać Mapper do http delete
                public async Task<ActionResult<User>> DeleteUser(int Id)
                {
                        try
                        {                                
                                var userToDelete = await _userRepository.GetUserAsync(Id);

                                if (userToDelete==null)
                                {
                                        return NotFound($"User with Id={Id} not found");
                                }
                                _mapper.Map<UserDeleteDto>(userToDelete);
                                return await _userRepository.DelateUserAsync(Id);

                        }
                        catch (Exception)
                        {

                                return StatusCode(StatusCodes.Status500InternalServerError,
                                         "Erorr deleting data");
                        }
                }



        }
}
