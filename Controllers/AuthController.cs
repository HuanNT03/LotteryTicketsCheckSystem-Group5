using LotteryBackend.Models;
using Microsoft.AspNetCore.Mvc;

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
        //
        if (loginDto == null || string.IsNullOrEmpty(loginDto.Password))
        {
            return BadRequest("Invalid login request.");
        }
        //
        if (user == null)
        {
            return Unauthorized();
        }

        return Ok();
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
        return Ok();
    }
}