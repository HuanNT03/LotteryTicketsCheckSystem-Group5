using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LotteryBackend.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string PasswordHash { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Role { get; set; } = null!;

        [Required]
        public string Salt { get; set; } = null!;

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
        public ICollection<CheckHistory> CheckHistories { get; set; } = new List<CheckHistory>();
    }
}
