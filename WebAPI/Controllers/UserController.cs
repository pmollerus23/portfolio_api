using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.DTOs;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = this._userService.GetAllAsync().Result.ToList();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var userDto = await _userService.GetByIdAsync(id);
            if (userDto == null)
            {
                return NotFound();
            }
            return Ok(userDto);
        }

        
        // [HttpPost("signup")]
        // public async Task<ActionResult> AddUser([FromBody] SignupDto signupDto)
        // {
        //     await _userService.AddAsync(signupDto);
        //     return CreatedAtAction(nameof(AddUser), new { email = signupDto.Email }, signupDto); 
        // }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> LoginUser([FromBody] LoginDto loginDto)
        {
            var login = await _userService.LoginUserServiceAsync(loginDto);
            if (login == null)
            {
                return Unauthorized();
            } 
            return Ok($"Logged into user: {loginDto.Email}");
        }
    }
}