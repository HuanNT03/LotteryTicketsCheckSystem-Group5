using LotteryBackend.Models;

public interface IAuthService
{
    Task<User> Authenticate(string username, string password);
    Task Register(User user);
    string HashPassword(string password);
}
