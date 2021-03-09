using AutoMapper;
using Mag.Dtos;
using Mag.Dtos.UserDtos;
using Mag.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Services
{
        public sealed class UserService : IUserService

        {
                private readonly IUserRepository _userRepository;
                private readonly IMapper _mapper;

                public UserService(IUserRepository userRepository, IMapper mapper)
                {
                        _userRepository = userRepository;
                        _mapper = mapper;
                }

                public Task<IEnumerable<UserGetDto>> AddUserAsync(UserGetDto userGetDto)
                {
                        throw new NotImplementedException();
                }

                public Task<IEnumerable<UserGetDto>> DelateUserAsync(int Id)
                {
                        throw new NotImplementedException();
                }

                public async Task<IEnumerable<UserGetDto>> GetAllUsersAsync()
                { 
                        var result = await _userRepository.GetAllUsersAsync();
                        var resultDto = _mapper.Map<IEnumerable<UserGetDto>>(result);
                        return resultDto;
                        
                       
                }                

                public async Task<IEnumerable<UserGetIdDto>> GetUserAsync(int id)
                {
                        var result = await _userRepository.GetUserAsync(id);
                        var resultDto = _mapper.Map<UserGetIdDto>(result);
                        return (IEnumerable<UserGetIdDto>)resultDto;
                }

                public Task<IEnumerable<UserGetDto>> UpdateUserAsync(UserGetDto user)
                {
                        throw new NotImplementedException();
                }
              
        }       
}
