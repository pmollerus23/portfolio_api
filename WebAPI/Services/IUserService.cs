using WebAPI.DTOs;

namespace WebAPI.Services
{
    public interface IUserService
    {
        Task<UserDto> GetByIdAsync(int id);
        Task<IEnumerable<UserDto>> GetAllAsync();
        // Task<string> AddAsync(SignupDto signupDto);
        Task UpdateAsync(UserDto userDto);
        Task DeleteAsync(int id);
        Task<UserDto> LoginUserServiceAsync(LoginDto loginDto);
    }
}

