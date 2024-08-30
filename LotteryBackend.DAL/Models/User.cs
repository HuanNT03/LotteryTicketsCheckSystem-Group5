using Microsoft.AspNetCore.Identity;

namespace LotteryBackend.Models
{
    public class User : IdentityUser
    {

        public DateTime? LastLoginDate { get; set; }

        public ICollection<CheckHistory> CheckHistories { get; set; }
        public List<RefreshToken> RefreshTokens { get; set; }
    }
}
