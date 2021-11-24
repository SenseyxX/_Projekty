using Mag.Dtos;
using Mag.Dtos.UserDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mag.Services
{
            public sealed class UserService : IUserService

            {
                    private readonly IUserRepository _userRepository;
                    private readonly IMapper _mapper;

                public UserService(IUserRepository userRepository,IMapper mapper)
                {
                    _userRepository = userRepository;
                    _mapper = mapper;
                }

                public async Task<UserGetDto> AddUserAsync(UserAddDto userAddDto)
                {
                    var user = _mapper.Map<User>(userAddDto);
                    var createdUser = await _userRepository.AddUserAsync(user);
                    return (UserGetDto) createdUser;
                }

                public async Task DelateUserAsync(int userId)
                {
                    var userToDelete = await _userRepository.GetUserAsync(userId);                    
                    _mapper.Map<UserDeleteDto>(userToDelete);
                    await _userRepository.DelateUserAsync(userId);
                }

                public async Task<IEnumerable<UserGetDto>> GetAllUsersAsync()
                {
                    var result = await _userRepository.GetAllUsersAsync();
                    var resultDto = _mapper.Map<IEnumerable<UserGetDto>>(result);
                    return resultDto;
                 }

                public async Task<UserGetDto> GetUserAsync(int userId)
                {
                var result = await _userRepository.GetUserAsync(userId);

                        if (result == null)
                        {
                            return null;
                        }

                        return (UserGetDto) result;

                }                

                public async Task<UserGetDto> UpdateUserAsync(int userId, UserUpdateDto userUpdateDto)
                {
                    var userToUpdate = await _userRepository.GetUserAsync(userId);
                    await _userRepository.UpdateUserAsync(userToUpdate);
                    return null;
                }
               
    }       
}
