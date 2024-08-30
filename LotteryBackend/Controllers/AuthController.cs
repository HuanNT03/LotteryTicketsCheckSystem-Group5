using LotteryBackend.Data;
using LotteryBackend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public AuthenticationController(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext context,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("register-user")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerVm)
        {
            var userExists = await _userManager.FindByEmailAsync(registerVm.Email);

            if (userExists != null)
            {
                return BadRequest($"User {registerVm.Email} already exists!");
            }

            var newUser = new User()
            {
                UserName = registerVm.Username,
                Email = registerVm.Email,
                SecurityStamp = new Guid().ToString()
            };

            var result = await _userManager.CreateAsync(newUser, registerVm.Password);

            if (!result.Succeeded)
            {

                return BadRequest("User could not created");
            }

            return Created(nameof(Register), $"User {registerVm.Email} created!");
        }

        [HttpPost("login-user")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please, provide all property!");
            }

            var user = await _userManager.FindByEmailAsync(loginVm.Email);

            if (user != null && await _userManager.CheckPasswordAsync(user, loginVm.Password))
            {
                var tokenValue = await GenerateJwtToken(user);

                return Ok(tokenValue);
            }

            return Unauthorized("Email or Password is invalid");
        }

        private async Task<AuthResultDto> GenerateJwtToken(User user)
        {
            var authClaims = new List<Claim>()
            {
                new Claim("userName", user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var authSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.UtcNow.AddMinutes(5), // 5 - 10mins
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);

            var refreshToken = new RefreshToken()
            {
                JwtId = token.Id,
                IsRevoked = false,
                UserId = user.Id,
                DateAdded = DateTime.UtcNow,
                DateExpire = DateTime.UtcNow.AddMonths(6),
                Token = Guid.NewGuid().ToString() + "-" + Guid.NewGuid().ToString()
            };

            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();

            var response = new AuthResultDto()
            {
                Token = jwtToken,
                RefreshToken = refreshToken.Token,
                ExpiresAt = token.ValidTo
            };

            return response;

        }

        [HttpGet]
        [Route("get-id-current-user")]
        public async Task<IActionResult> getLoggedInUserID()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return Ok(new { userId = id });
        }
    }
}
