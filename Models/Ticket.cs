namespace LotteryBackend.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string TicketNumber { get; set; }
        public DateTime LotteryDate { get; set; }
        public string Result { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
