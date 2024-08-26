namespace LotteryBackend.Models
{
    public class CheckHistory
    {
        public int Id { get; set; }
        public DateTime CheckDate { get; set; }
        public string Result { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}
