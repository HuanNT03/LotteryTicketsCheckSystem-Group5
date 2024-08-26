using Moq;
using Xunit;
using System.Threading.Tasks;
using LotteryBackend.Models;
using LotteryBackend.Repositories;

public class AuthServiceTests
{
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly IAuthService _authService;

    public AuthServiceTests()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _authService = new AuthService(_mockUserRepository.Object);
    }

    [Fact]
    public async Task Authenticate_ValidCredentials_ReturnsUser()
    {
        // Arrange
        var username = "testuser";
        var password = "password";
        var hashedPassword = _authService.HashPassword(password);

        _mockUserRepository.Setup(repo => repo.GetUserByUsernameAsync(username))
            .ReturnsAsync(new User { Username = username, PasswordHash = hashedPassword });

        var user = await _authService.Authenticate(username, password);

        Assert.NotNull(user); 
        Assert.Equal(username, user.Username);
    }
}
