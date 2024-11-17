using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTOs;
using WebAPI.Mappers;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user != null ? UserMapper.ToDto(user) : null;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(UserMapper.ToDto);
        }

        // public async Task<ActionResult> AddAsync(SignupDto signupDto)
        // {
        //     bool userAlreadyExists = await _userRepository.ExistsByEmailAsync(signupDto.Email);
        //     if (userAlreadyExists) {
        //         return new Conflict("already exists");
        //     } 
        //     UserModel user = UserMapper.ToModel(signupDto);
        //     user.Roles.Add("ROLE_USER");
        //     bool userCreated = await _userRepository.AddAsync(user);
        //     if (userCreated) {
        //         return new OkObjectResult("user created successfully");
        //     } 

        //     return Exception;
        // }

        public async Task UpdateAsync(UserDto userDto)
        {
            var user = UserMapper.ToModel(userDto);
            await _userRepository.UpdateAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<UserDto> LoginUserServiceAsync(LoginDto loginDto)
        {
            var existingUser = await _userRepository.FindByEmailAsync(loginDto.Email);
            if (existingUser.Email == loginDto.Email && existingUser.Password == loginDto.Password)
            {
                return existingUser != null ? UserMapper.ToDto(existingUser) : null;
            }
            else
            {
                return null;
            }
        }

        // Task<string> IUserService.AddAsync(SignupDto signupDto)
        // {
        //     throw new NotImplementedException();
        // }
    }
}

