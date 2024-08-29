using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

public class AuthService
{
    private readonly IRepository<User> _userRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IRepository<User> userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    public async Task<User> Register(string username, string email, string password)
    {
        using var hmac = new HMACSHA512();
        var user = new User
        {
            Username = username,
            Email = email,
            PasswordHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password))),
            PasswordSalt = Convert.ToBase64String(hmac.Key),
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };


        await _userRepository.Add(user);
        return user;
    }

    public async Task<User> Login(string email, string password)
    {
        var user = (await _userRepository.GetAll()).FirstOrDefault(u => u.Email == email);
        if (user == null) return null;

        var saltBytes = Convert.FromBase64String(user.PasswordSalt);
        using var hmac = new HMACSHA512(saltBytes);
        var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        var computedHashString = Convert.ToBase64String(computedHash);

        if (computedHashString != user.PasswordHash) return null;

        return user;
    }

    public string GenerateJwtToken(User user)
    {
        var role = user.UserRoles?.FirstOrDefault()?.Role.RoleName;
        if (string.IsNullOrEmpty(role))
        {
            role = "User"; // Hoặc gán một vai trò mặc định nếu người dùng không có vai trò nào
        }

        var claims = new[]
        {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
        new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
        new Claim(ClaimTypes.Role, role)
    };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(7),
            SigningCredentials = creds,
            Issuer = _configuration["JWT:Issuer"],
            Audience = _configuration["JWT:Audience"]
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
