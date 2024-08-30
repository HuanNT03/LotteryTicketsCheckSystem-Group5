namespace LotteryBackend.Models
{
    public class LotteryResult
    {
        public int Id { get; set; }
        public int TicketId { get; set; }

        public DateTime LotteryDate { get; set; }
        public string PrizeCategory { get; set; }
        public string WinningNumber { get; set; }

        // Navigation property
        public Ticket Ticket { get; set; }
    }
}
