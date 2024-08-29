using System.ComponentModel.DataAnnotations;

namespace LotteryBackend.Models
{
    public class LotteryResult
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime LotteryDate { get; set; }

        [Required]
        public string WinningNumbers { get; set; } = null!;
    }
}
