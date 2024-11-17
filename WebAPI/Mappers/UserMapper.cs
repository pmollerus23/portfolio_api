using System.Collections.ObjectModel;
using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(UserModel user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };
        }

        public static UserModel ToModel(UserDto userDto)
        {
            return new UserModel()
            {
                Id = userDto.Id,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.Password
            };
        }

        public static UserModel ToModel(SignupDto signupDtoDto)
        {
            return new UserModel()
            {
                FirstName = signupDtoDto.FirstName,
                LastName = signupDtoDto.LastName,
                Email = signupDtoDto.Email,
                Password = signupDtoDto.Password
            };
        }
    }
}