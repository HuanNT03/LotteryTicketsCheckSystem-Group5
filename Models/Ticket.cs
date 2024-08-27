using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LotteryBackend.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TicketNumber { get; set; } = null!;

        [Required]
        public DateTime LotteryDate { get; set; }

        public string? Result { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public ICollection<CheckHistory> CheckHistories { get; set; } = new List<CheckHistory>();
    }
}
