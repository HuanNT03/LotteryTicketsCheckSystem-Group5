using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LotteryBackend.Models
{
    public class CheckHistory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CheckDate { get; set; }

        [Required]
        public string Result { get; set; } = null!;

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        [ForeignKey("Ticket")]
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; } = null!;
    }
}
