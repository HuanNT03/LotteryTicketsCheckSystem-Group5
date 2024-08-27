using System.Security.Cryptography;
using LotteryBackend.Models;
using LotteryBackend.Repositories;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace LotteryBackend.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> Authenticate(string username, string password)
        {
            var user = await _userRepository.GetUserByUsernameAsync(username);
            if (user == null || !VerifyPassword(password, user.PasswordHash, user.Salt))
            {
                return null;
            }

            return user;
        }

        public async Task Register(User user)
        {
            user.Salt = GenerateSalt();
            user.PasswordHash = HashPassword(user.PasswordHash, user.Salt);
            await _userRepository.AddUserAsync(user);
        }

        public string HashPassword(string password, string salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }

        public string GenerateSalt()
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return Convert.ToBase64String(salt);
        }

        private bool VerifyPassword(string password, string storedHash, string salt)
        {
            return storedHash == HashPassword(password, salt);
        }
    }
}
