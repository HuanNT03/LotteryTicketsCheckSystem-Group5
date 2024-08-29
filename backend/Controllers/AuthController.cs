using LotteryBackend.DTOs;
using LotteryBackend.Models;
using LotteryBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace LotteryBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var user = await _authService.Authenticate(loginDto.Username, loginDto.Password);
            if (user == null)
                return Unauthorized();

            return Ok(new { message = "Login successful" });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var user = new User
            {
                Username = registerDto.Username,
                PasswordHash = registerDto.Password,
                Email = registerDto.Email,
                Role = "User"
            };
            await _authService.Register(user);

            return Ok(new { message = "Registration successful" });
        }
    }
}
